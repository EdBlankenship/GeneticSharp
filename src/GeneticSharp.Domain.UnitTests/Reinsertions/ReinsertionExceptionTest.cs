﻿using System;
using System.Reflection;
using System.Runtime.Serialization;
using NUnit.Framework;
using NSubstitute;

namespace GeneticSharp.Domain.UnitTests.Chromosomes
{
    [TestFixture]
    [Category("Reinsertions")]
    public class ReinsertionExceptionTest
    {
        [Test]
        public void Constructor_NoArgs_DefaultValue()
        {
            var target = new ReinsertionException();
            Assert.IsTrue(target.Message.Contains("ReinsertionException"));
        }

        [Test]
        public void Constructor_Message_Message()
        {
            var target = new ReinsertionException("1");
            Assert.AreEqual("1", target.Message);
        }

        [Test]
        public void Constructor_MessageAndInnerException_MessageAndInnerExcetion()
        {
            var target = new ReinsertionException("1", new Exception("2"));
            Assert.AreEqual("1", target.Message);
            Assert.AreEqual("2", target.InnerException.Message);
        }

        [Test]
        public void Constructor_ReinsertionAndMessage_ReinsertionAndMessage([Values] bool nullReinsertion)
        {
            var target = new ReinsertionException(nullReinsertion ? null : Substitute.For<IReinsertion>(), "1");
            Assert.AreEqual(nullReinsertion, target.Reinsertion == null);
            Assert.AreEqual(nullReinsertion ? ": 1" : $"{target.Reinsertion.GetType().Name}: 1", target.Message);
            Assert.IsNull(target.InnerException);
        }

        [Test]
        public void Constructor_ReinsertionAndMessageAndInnerException_ReinsertionAndMessageAndInnerExcetion([Values] bool nullReinsertion)
        {
            var target = new ReinsertionException(nullReinsertion ? null : Substitute.For<IReinsertion>(), "1", new Exception("2"));
            Assert.AreEqual(nullReinsertion, target.Reinsertion == null);
            Assert.AreEqual(nullReinsertion ? ": 1" : $"{target.Reinsertion.GetType().Name}: 1", target.Message);
            Assert.AreEqual("2", target.InnerException.Message);
        }

        [Test]
        public void Constructor_InfoAndContext_InfoAndContext()
        {
            var constructor = typeof(ReinsertionException).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)[0];

            var serializationInfo = new SerializationInfo(typeof(int), Substitute.For<IFormatterConverter>());
            serializationInfo.AddValue("ClassName", "ReinsertionException");
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
                new StreamingContext() }) as ReinsertionException;

            Assert.AreEqual("2", target.InnerException.Message);
        }

        [Test]
        public void GetObjectData_InfoAndContext_Property()
        {
            var propertyValue = Substitute.For<IReinsertion>();
            var target = new ReinsertionException(propertyValue, "1");
            var serializationInfo = new SerializationInfo(typeof(int), Substitute.For<IFormatterConverter>());
            target.GetObjectData(serializationInfo, new StreamingContext());

            Assert.AreEqual(propertyValue, serializationInfo.GetValue("Reinsertion", typeof(IReinsertion)));
        }
    }
}