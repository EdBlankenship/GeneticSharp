﻿using System;
using System.Reflection;
using System.Runtime.Serialization;
using NUnit.Framework;
using NSubstitute;

namespace GeneticSharp.Domain.UnitTests.Chromosomes
{
    [TestFixture]
    [Category("Selections")]
    public class SelectionExceptionTest
    {
        [Test]
        public void Constructor_NoArgs_DefaultValue()
        {
            var target = new SelectionException();
            Assert.IsTrue(target.Message.Contains("SelectionException"));
        }

        [Test]
        public void Constructor_Message_Message()
        {
            var target = new SelectionException("1");
            Assert.AreEqual("1", target.Message);
        }

        [Test]
        public void Constructor_MessageAndInnerException_MessageAndInnerExcetion()
        {
            var target = new SelectionException("1", new Exception("2"));
            Assert.AreEqual("1", target.Message);
            Assert.AreEqual("2", target.InnerException.Message);
        }

        [Test]
        public void Constructor_SelectionAndMessage_SelectionAndMessage([Values] bool nullSelection)
        {
            var target = new SelectionException(nullSelection ? null : Substitute.For<ISelection>(), "1");
            Assert.AreEqual(nullSelection, target.Selection == null);
            Assert.AreEqual(nullSelection ? ": 1" : $"{target.Selection.GetType().Name}: 1", target.Message);
            Assert.IsNull(target.InnerException);
        }

        [Test]
        public void Constructor_SelectionAndMessageAndInnerException_SelectionAndMessageAndInnerExcetion([Values] bool nullSelection)
        {
            var target = new SelectionException(nullSelection ? null : Substitute.For<ISelection>(), "1", new Exception("2"));
            Assert.AreEqual(nullSelection, target.Selection == null);
            Assert.AreEqual(nullSelection ? ": 1" : $"{target.Selection.GetType().Name}: 1", target.Message);
            Assert.AreEqual("2", target.InnerException.Message);
        }

        [Test]
        public void Constructor_InfoAndContext_InfoAndContext()
        {
            var constructor = typeof(SelectionException).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)[0];

            var serializationInfo = new SerializationInfo(typeof(int), Substitute.For<IFormatterConverter>());
            serializationInfo.AddValue("ClassName", "SelectionException");
            serializationInfo.AddValue("Message", "1");
            serializationInfo.AddValue("InnerException", new Exception("2"));
            serializationInfo.AddValue("HelpURL", "");
            serializationInfo.AddValue("StackTraceString", "");
            serializationInfo.AddValue("RemoteStackTraceString", "");
            serializationInfo.AddValue("RemoteStackIndex", 1);
            serializationInfo.AddValue("ExceptionMethod", 1);
            serializationInfo.AddValue("HResult", 1);
            serializationInfo.AddValue("Source", 1);

            var target = constructor.Invoke(new object[] {
                serializationInfo,
                new StreamingContext() }) as SelectionException;

            Assert.AreEqual("2", target.InnerException.Message);
        }

        [Test]
        public void GetObjectData_InfoAndContext_Property()
        {
            var propertyValue = Substitute.For<ISelection>();
            var target = new SelectionException(propertyValue, "1");
            var serializationInfo = new SerializationInfo(typeof(int), Substitute.For<IFormatterConverter>());
            target.GetObjectData(serializationInfo, new StreamingContext());

            Assert.AreEqual(propertyValue, serializationInfo.GetValue("Selection", typeof(ISelection)));
        }
    }
}