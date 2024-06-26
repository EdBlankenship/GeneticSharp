﻿using System;
using NUnit.Framework;

namespace GeneticSharp.Domain.UnitTests.Selections
{
    [TestFixture()]
    [Category("Selections")]
    public class SelectionServiceTest
    {
        [Test()]
        public void GetSelectionTypes_NoArgs_AllAvailableSelections()
        {
            var actual = SelectionService.GetSelectionTypes();

            Assert.AreEqual(6, actual.Count);
            Assert.AreEqual(typeof(EliteSelection), actual[0]);
            Assert.AreEqual(typeof(RankSelection), actual[1]);
            Assert.AreEqual(typeof(RouletteWheelSelection), actual[2]);
            Assert.AreEqual(typeof(StochasticUniversalSamplingSelection), actual[3]);
            Assert.AreEqual(typeof(TournamentSelection), actual[4]);
            Assert.AreEqual(typeof(TruncationSelection), actual[5]);
        }

        [Test()]
        public void GetSelectionNames_NoArgs_AllAvailableSelectionsNames()
        {
            var actual = SelectionService.GetSelectionNames();

            Assert.AreEqual(6, actual.Count);
            Assert.AreEqual("Elite", actual[0]);
            Assert.AreEqual("Rank", actual[1]);
            Assert.AreEqual("Roulette Wheel", actual[2]);
            Assert.AreEqual("Stochastic Universal Sampling", actual[3]);
            Assert.AreEqual("Tournament", actual[4]);
            Assert.AreEqual("Truncation", actual[5]);
        }

        [Test()]
        public void CreateSelectionByName_InvalidName_Exception()
        {
            Assert.Catch<ArgumentException>(() =>
            {
                SelectionService.CreateSelectionByName("Test");
            }, "There is no ISelection implementation with name 'Test'.");
        }

        [Test()]
        public void CreateSelectionByName_ValidNameButInvalidConstructorArgs_Exception()
        {
            Assert.Catch<ArgumentException>(() =>
            {
                SelectionService.CreateSelectionByName("Elite", 1, 2);
            }, "A ISelection's implementation with name 'Elite' was found, but seems the constructor args were invalid.");
        }

        [Test()]
        public void CreateSelectionByName_ValidName_SelectionCreated()
        {
            ISelection actual = SelectionService.CreateSelectionByName("Elite") as EliteSelection;
            Assert.IsNotNull(actual);

            actual = SelectionService.CreateSelectionByName("Rank") as RankSelection;
            Assert.IsNotNull(actual);

            actual = SelectionService.CreateSelectionByName("Roulette Wheel") as RouletteWheelSelection;
            Assert.IsNotNull(actual);

            actual = SelectionService.CreateSelectionByName("Tournament") as TournamentSelection;
            Assert.IsNotNull(actual);

            actual = SelectionService.CreateSelectionByName("Stochastic Universal Sampling") as StochasticUniversalSamplingSelection;
            Assert.IsNotNull(actual);
        }

        [Test()]
        public void GetSelectionTypeByName_InvalidName_Exception()
        {
            Assert.Catch<ArgumentException>(() =>
            {
                SelectionService.GetSelectionTypeByName("Test");
            }, "There is no ISelection implementation with name 'Test'.");
        }

        [Test()]
        public void GetSelectionTypeByName_ValidName_SelectionTpe()
        {
            var actual = SelectionService.GetSelectionTypeByName("Elite");
            Assert.AreEqual(typeof(EliteSelection), actual);

            actual = SelectionService.GetSelectionTypeByName("Rank");
            Assert.AreEqual(typeof(RankSelection), actual);

            actual = SelectionService.GetSelectionTypeByName("Roulette Wheel");
            Assert.AreEqual(typeof(RouletteWheelSelection), actual);

            actual = SelectionService.GetSelectionTypeByName("Tournament");
            Assert.AreEqual(typeof(TournamentSelection), actual);

            actual = SelectionService.GetSelectionTypeByName("Stochastic Universal Sampling");
            Assert.AreEqual(typeof(StochasticUniversalSamplingSelection), actual);
        }
    }
}