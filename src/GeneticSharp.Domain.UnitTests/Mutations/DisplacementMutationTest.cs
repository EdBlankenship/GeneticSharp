﻿using NUnit.Framework;
using NSubstitute;

namespace GeneticSharp.Domain.UnitTests.Mutations
{
    [TestFixture()]
    [Category("Mutations")]
    class DisplacementMutationTest
    {
        [TearDown]
        public void Cleanup()
        {
            RandomizationProvider.Current = new BasicRandomization();
        }

        [Test()]
        public void Mutate_LessThanThreeGenes_Exception()
        {
            var target = new DisplacementMutation();
            var chromosome = Substitute.For<ChromosomeBase>(2);
            chromosome.ReplaceGenes(0, new Gene[]
                                    {
                new Gene(1),
            });

            Assert.Catch<MutationException>(() =>
            {
                target.Mutate(chromosome, 0);
            }, "A chromosome should have, at least, 3 genes. {0} has only 2 gene.".With(chromosome.GetType().Name));
        }

        [Test()]
        public void Mutate_NoProbality_NoDisplacement()
        {
            var target = new DisplacementMutation();
            var chromosome = Substitute.For<ChromosomeBase>(4);
            chromosome.ReplaceGenes(0, new Gene[]
                                    {
                new Gene(1),
                new Gene(2),
                new Gene(3),
                new Gene(4),
            });

            var rnd = Substitute.For<IRandomization>();
            rnd.GetDouble().Returns(0.1);
            RandomizationProvider.Current = rnd;

            target.Mutate(chromosome, 0);

            Assert.AreEqual(4, chromosome.Length);
            Assert.AreEqual(1, chromosome.GetGene(0).Value);
            Assert.AreEqual(2, chromosome.GetGene(1).Value);
            Assert.AreEqual(3, chromosome.GetGene(2).Value);
            Assert.AreEqual(4, chromosome.GetGene(3).Value);
        }

        [Test()]
        public void Mutate_ValidChromosome_Displacement_To_Left()
        {
            var target = new DisplacementMutation();
            var chromosome = Substitute.For<ChromosomeBase>(8);
            chromosome.ReplaceGenes(0, new Gene[]
                                    {
                new Gene(1),
                new Gene(2),
                new Gene(3),
                new Gene(4),
                new Gene(5),
                new Gene(6),
                new Gene(7),
                new Gene(8),
            });

            var rnd = Substitute.For<IRandomization>();
            rnd.GetUniqueInts(2, 0, 8).Returns(new int[] { 1, 6 });
            rnd.GetInt(0, 5).Returns(1);
            rnd.GetDouble().Returns(0);
            RandomizationProvider.Current = rnd;
            target.Mutate(chromosome, 1);

            Assert.AreEqual(8, chromosome.Length);
            Assert.AreEqual(1, chromosome.GetGene(0).Value);
            Assert.AreEqual(4, chromosome.GetGene(1).Value);
            Assert.AreEqual(5, chromosome.GetGene(2).Value);
            Assert.AreEqual(6, chromosome.GetGene(3).Value);
            Assert.AreEqual(7, chromosome.GetGene(4).Value);
            Assert.AreEqual(2, chromosome.GetGene(5).Value);
            Assert.AreEqual(3, chromosome.GetGene(6).Value);
            Assert.AreEqual(8, chromosome.GetGene(7).Value);
        }

        [Test()]
        public void Mutate_ValidChromosome_Displacement_To_Right()
        {
            var target = new DisplacementMutation();
            var chromosome = Substitute.For<ChromosomeBase>(8);
            chromosome.ReplaceGenes(0, new Gene[]
                                    {
                new Gene(1),
                new Gene(2),
                new Gene(3),
                new Gene(4),
                new Gene(5),
                new Gene(6),
                new Gene(7),
                new Gene(8),
            });

            var rnd = Substitute.For<IRandomization>();
            rnd.GetUniqueInts(2, 0, 8).Returns(new int[] { 1, 6 });
            rnd.GetInt(0, 5).Returns(1);
            rnd.GetDouble().Returns(1);
            RandomizationProvider.Current = rnd;
            target.Mutate(chromosome, 1);

            Assert.AreEqual(8, chromosome.Length);
            Assert.AreEqual(1, chromosome.GetGene(0).Value);
            Assert.AreEqual(6, chromosome.GetGene(1).Value);
            Assert.AreEqual(7, chromosome.GetGene(2).Value);
            Assert.AreEqual(2, chromosome.GetGene(3).Value);
            Assert.AreEqual(3, chromosome.GetGene(4).Value);
            Assert.AreEqual(4, chromosome.GetGene(5).Value);
            Assert.AreEqual(5, chromosome.GetGene(6).Value);
            Assert.AreEqual(8, chromosome.GetGene(7).Value);
        }
    }
}
