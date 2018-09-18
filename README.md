
![](docs/logo/logo-medium.png)

[![Join the chat at https://gitter.im/GeneticSharp/Lobby](https://badges.gitter.im/GeneticSharp/Lobby.svg)](https://gitter.im/GeneticSharp/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
[![Build status](https://ci.appveyor.com/api/projects/status/h9ptxpyj30ah3mva/branch/master?svg=true)](https://ci.appveyor.com/project/giacomelli/geneticsharp)
[![Coverage Status](https://coveralls.io/repos/giacomelli/GeneticSharp/badge.svg?branch=master&service=github)](https://coveralls.io/github/giacomelli/GeneticSharp?branch=master)
[![License](http://img.shields.io/:license-MIT-blue.svg)](https://raw.githubusercontent.com/giacomelli/GeneticSharp/master/LICENSE)
[![Nuget](https://img.shields.io/nuget/v/GeneticSharp.svg)](https://www.nuget.org/packages/GeneticSharp/)
[![Stack Overflow](https://img.shields.io/badge/stackoverflow-GeneticSharp-orange.svg)](http://stackoverflow.com/questions/tagged/GeneticSharp)


GeneticSharp is a fast, extensible, multi-platform and multithreading C# Genetic Algorithm library that simplifies the development of applications using Genetic Algorithms (GAs).

Can be used in any kind of .NET Core and .NET Framework apps, like ASP .NET MVC, ASP .NET Core, Web Forms, UWP, Windows Forms, GTK#, Xamarin and Unity3D games.

--------

## Projects, papers, journals, books and tutorials using GeneticSharp
* [AeroVision: aircraft trajectories optimization and visualization (paper)](https://github.com/giacomelli/GeneticSharp/blob/master/docs/mentioning-GeneticSharp/AeroVision-Aircraft-trajectories-optimization-and-visualization.pdf)
* [Analysis and comparison between Black-Scholes and Merton and Corrado-Su for options pricing (paper)](https://github.com/giacomelli/GeneticSharp/blob/master/docs/mentioning-GeneticSharp/Analysis-and-comparison-between-Black-Scholes-and-Merton-and-Corrado-Su-for-options-pricing.pdf)
* [Context-Sensitive Code Completion: improving predictions with genetic algorithms (paper)](https://github.com/giacomelli/GeneticSharp/blob/master/docs/mentioning-GeneticSharp/Context-Sensitive-Code-Completion-improving-predictions-with-genetic-algorithms.pdf) [(Github)](https://github.com/godtopus/GeneCSCC)
* [Deriving Functions for Pareto Optimal Fronts Using Genetic Programming (paper/book)](https://books.google.com.br/books?id=w_lcDwAAQBAJ&lpg=PA473&ots=Rv7O6FhCSM&dq=%22GeneticSharp%22&hl=pt-BR&pg=PA464#v=onepage&q=%22GeneticSharp%22&f=false)
* [Designing and creating a self managing distributed file system (paper)](https://github.com/giacomelli/GeneticSharp/blob/master/docs/mentioning-GeneticSharp/Designing-and-creating-a-self-managing-distributed-file-system.pdf)
* [Developing trading strategies with genetic algorithms (forum)](https://www.quantconnect.com/forum/discussion/2396/developing-trading-strategies-with-genetic-algorithms) [(paper)](https://github.com/giacomelli/GeneticSharp/blob/master/docs/mentioning-GeneticSharp/Developing-Trading-Strategies-with-Genetic-Algorithms.pdf)
* [Function optimization with GeneticSharp (tutorial)](http://diegogiacomelli.com.br/function-optimization-with-geneticsharp/)
* [GeneticSharp Car2D (sample)](http://diegogiacomelli.com.br/GeneticSharp-Car2D/)
* [Genetic Scheduler: a genetic algorithm for scheduling tasks with temporal restriction in distributed systems (paper)](https://github.com/giacomelli/GeneticSharp/blob/master/docs/mentioning-GeneticSharp/Genetic-Scheduler.pdf)
* [Lean Optimization: genetic optimization using LEAN (GitHub)](https://github.com/Jay-Jay-D/LeanOptimization) 
* [Overload journal 142: Evolutionary computing frameworks for optimisation (journal)](https://accu.org/var/uploads/journals/Overload142.pdf)
* [Path Finding with Genetic Algorithms (project)](https://yoloprogramming.com/post/2017/01/11/path-finding-with-genetic-algorithms)
* [SurvivorAI: some experiments of survival scenarios (project)](https://github.com/giacomelli/SurvivorAI)
* [TSP with GeneticSharp and Unity3D (tutorial)](http://diegogiacomelli.com.br/tsp-with-GeneticSharp-and-Unity3d/)
* Are you using GeneticSharp in your project? Please, [let me know!](https://twitter.com/ogiacomelli)

## Features

### [Chromosomes](src/GeneticSharp.Domain/Chromosomes)
  - [FloatingPointChromosome](src/GeneticSharp.Domain/Chromosomes/FloatingPointChromosome.cs)
  - [IntegerChromosome](src/GeneticSharp.Domain/Chromosomes/IntegerChromosome.cs)
  - Add your own chromosome representation implementing [IChromosome](src/GeneticSharp.Domain/Chromosomes/IChromosome.cs) / [IBinaryChromosome](src/GeneticSharp.Domain/Chromosomes/IBinaryChromosome.cs) interfaces or extending [ChromosomeBase](src/GeneticSharp.Domain/Chromosomes/ChromosomeBase.cs) / [BinaryChromosomeBase](src/GeneticSharp.Domain/Chromosomes/BinaryChromosomeBase.cs).
   
### [Fitness](src/GeneticSharp.Domain/Fitnesses)
Add your own fitness evaluation, implementing [IFitness](src/GeneticSharp.Domain/Fitnesses/IFitness.cs) interface.

### [Populations](src/GeneticSharp.Domain/Populations)
   - [Generation](src/GeneticSharp.Domain/Populations/Generation.cs)
   - [Generation strategy](src/GeneticSharp.Domain/Populations/IGenerationStrategy.cs)
     - [Performance strategy](src/GeneticSharp.Domain/Populations/PerformanceGenerationStrategy.cs)
     - [Tracking strategy](src/GeneticSharp.Domain/Populations/TrackingGenerationStrategy.cs)  

### [Selections](src/GeneticSharp.Domain/Selections)
   - [Elite](src/GeneticSharp.Domain/Selections/EliteSelection.cs) (also know as Truncate or Truncation)
   - [Roulette Wheel](src/GeneticSharp.Domain/Selections/RouletteWheelSelection.cs)
   - [Stochastic Universal Sampling](src/GeneticSharp.Domain/Selections/StochasticUniversalSamplingSelection.cs)
   - [Tournament](src/GeneticSharp.Domain/Selections/TournamentSelection.cs)  
   - Others selections can be added implementing [ISelection](src/GeneticSharp.Domain/Selections/ISelection.cs) interface or extending [SelectionBase](src/GeneticSharp.Domain/Selections/SelectionBase.cs). 

### [Crossovers](src/GeneticSharp.Domain/Crossovers)
   - [Cut and Splice](src/GeneticSharp.Domain/Crossovers/CutAndSpliceCrossover.cs) 
   - [Cycle (CX)](src/GeneticSharp.Domain/Crossovers/CycleCrossover.cs)   
   - [One-Point (C1)](src/GeneticSharp.Domain/Crossovers/OnePointCrossover.cs)
   - [Order-based (OX2)](src/GeneticSharp.Domain/Crossovers/OrderBasedCrossover.cs)
   - [Ordered (OX1)](src/GeneticSharp.Domain/Crossovers/OrderedCrossover.cs)
   - [Partially Mapped (PMX)](src/GeneticSharp.Domain/Crossovers/PartiallyMappedCrossover.cs)
   - [Position-based (POS)](src/GeneticSharp.Domain/Crossovers/PositionBasedCrossover.cs)
   - [Three parent](src/GeneticSharp.Domain/Crossovers/ThreeParentCrossover.cs)
   - [Two-Point (C2)](src/GeneticSharp.Domain/Crossovers/TwoPointCrossover.cs)
   - [Uniform](src/GeneticSharp.Domain/Crossovers/UniformCrossover.cs)
   - Others crossovers can be added implementing [ICrossover](src/GeneticSharp.Domain/Crossovers/ICrossover.cs) interface or extending [CrossoverBase](src/GeneticSharp.Domain/Crossovers/CrossoverBase.cs).   

### [Mutations](src/GeneticSharp.Domain/Mutations)
   - [Displacement](src/GeneticSharp.Domain/Mutations/DisplacementMutation.cs)
   - [Flip Bit](src/GeneticSharp.Domain/Mutations/FlipBitMutation.cs)
   - [Insertion](src/GeneticSharp.Domain/Mutations/InsertionMutation.cs)
   - [Partial Shuffle (PSM)](src/GeneticSharp.Domain/Mutations/PartialShuffleMutation.cs)
   - [Reverse Sequence (RSM)](src/GeneticSharp.Domain/Mutations/ReverseSequenceMutation.cs)
   - [Twors](src/GeneticSharp.Domain/Mutations/TworsMutation.cs)
   - [Uniform](src/GeneticSharp.Domain/Mutations/UniformMutation.cs)
   - Others mutations can be added implementing [IMutation](src/GeneticSharp.Domain/Mutations/IMutation.cs) interface or extending [MutationBase](src/GeneticSharp.Domain/Mutations/MutationBase.cs) / [SequenceMutationBase](src/GeneticSharp.Domain/Mutations/SequenceMutationBase.cs).

### [Reinsertions](src/GeneticSharp.Domain/Reinsertions)
   - [Elitist](src/GeneticSharp.Domain/Reinsertions/ElitistReinsertion.cs)
   - [Fitness Based](src/GeneticSharp.Domain/Reinsertions/FitnessBasedReinsertion.cs)
   - [Pure](src/GeneticSharp.Domain/Reinsertions/PureReinsertion.cs)
   - [Uniform](src/GeneticSharp.Domain/Reinsertions/UniformReinsertion.cs)
   - Others reinsertions can be added implementing [IReinsertion](src/GeneticSharp.Domain/Reinsertions/IReinsertion.cs) interface or extending [ReinsertionBase](src/GeneticSharp.Domain/Reinsertions/ReinsertionBase.cs).

### [Terminations](src/GeneticSharp.Domain/Terminations)
   - [Generation number](src/GeneticSharp.Domain/Terminations/GenerationNu)
   - [Time evolving](src/GeneticSharp.Domain/Terminations/TimeEvolvingTermination.cs)
   - [Fitness stagnation](src/GeneticSharp.Domain/Terminations/FitnessStagnationTermination.cs)
   - [Fitness threshold](src/GeneticSharp.Domain/Terminations/FitnessThresholdTermination.cs)
   - [And](src/GeneticSharp.Domain/Terminations/AndTermination.cs) e [Or](src/GeneticSharp.Domain/Terminations/OrTermination.cs) (allows combine others terminations)
   - Others terminations can be added implementing [ITermination](src/GeneticSharp.Domain/Terminations/ITermination.cs) interface or extending [TerminationBase](src/GeneticSharp.Domain/Terminations/TerminationBase.cs).

### [Randomizations](src/GeneticSharp.Domain/Randomizations)
   - [Basic randomization](src/GeneticSharp.Domain/Randomizations/BasicRandomization.cs) (using System.Random)
   - [Fast random](src/GeneticSharp.Domain/Randomizations/FastRandomRandomization.cs)   
   - If you need a special kind of randomization for your GA, just implement the [IRandomization](src/GeneticSharp.Domain/Randomizations/IRandomization.cs) interface.

### [Console sample](src/GeneticSharp.Runner.ConsoleApp)
- AutoConfig
- Bitmap equality
- Equality equation
- Equation solver
- Function builder

![](docs/gifs/GeneticSharp-ConsoleApp-EquationSolver-FunctionBuilder.gif)

- Ghostwriter
- TSP (Travelling Salesman Problem)
 	
### [GTK# sample](src/GeneticSharp.Runner.GtkApp)

#### TSP (Travelling Salesman Problem) and Function optimization
![](docs/gifs/GeneticSharp-GtkApp.gif)
 
#### Bitmap equality
![](docs/gifs/GeneticSharp-BitmapEquality_sample01.gif)

### [Unity3D sample](src/GeneticSharp.Runner.UnityApp)
- Car2D
- TSP
- Wall builder
[![](docs/screenshots/GeneticSharp-UnityApp.png)](https://youtu.be/xXqNcgeOU_g)
      
### Multi-platform
- Mono, .NET Standard 2.0 and .NET Framework 4.6.2 support.
- Fully tested on Windows and MacOS.

![](docs/screenshots/VisualStudioMacAndWin.png)

### Code quality
- 100% unit test code coverage.
- FxCop validated.
- Code duplicated verification.
- Good (and well used) design patterns.  
- 100% code documentation

--------

## Setup

### .NET Standard 2.0 and .NET Framework 4.6.2 
Only GeneticSharp:

```shell
install-package GeneticSharp
```

GeneticSharp and extensions (TSP, AutoConfig, Bitmap equality, Equality equation, Equation solver, Function builder, etc):

```shell
install-package GeneticSharp.Extensions
```
## Unity3D
If want to use GeneticSharp on Unity3D you can use the latest GeneticSharp.unitypackage available on our [release page](https://github.com/giacomelli/GeneticSharp/releases).

## Mono and .NET Framework 3.5
To install previous version that support .NET Framework 3.5:

```shell
install-package GeneticSharp -Version 1.2.0
```

## Running samples
If you want to run the console, GTK# and Unity samples, just fork this repository and follow the instruction from our [setup](https://github.com/giacomelli/GeneticSharp/wiki/setup) page wiki.

## Usage

### Creating your own fitness evaluation 
```csharp

public class MyProblemFitness : IFitness
{  
	public double Evaluate (IChromosome chromosome)
	{
		// Evaluate the fitness of chromosome.
	}
}

```

### Creating your own chromosome 
```csharp

public class MyProblemChromosome : ChromosomeBase
{
	// Change the argument value passed to base construtor to change the length 
	// of your chromosome.
	public MyProblemChromosome() : base(10) 
	{
		CreateGenes();
	}

	public override Gene GenerateGene (int geneIndex)
	{
		// Generate a gene base on my problem chromosome representation.
	}

	public override IChromosome CreateNew ()
	{
		return new MyProblemChromosome();
	}
}

```

### Running your GA 

```csharp
var selection = new EliteSelection();
var crossover = new OrderedCrossover();
var mutation = new ReverseSequenceMutation();
var fitness = new MyProblemFitness();
var chromosome = new MyProblemChromosome();
var population = new Population (50, 70, chromosome);

var ga = new GeneticAlgorithm(population, fitness, selection, crossover, mutation);
ga.Termination = new GenerationNumberTermination(100);

Console.WriteLine("GA running...");
ga.Start();

Console.WriteLine("Best solution found has {0} fitness.", ga.BestChromosome.Fitness);
```

--------

## Roadmap
 - Add new problems/classic sample
   - Checkers 
   - Time series   
   - Knapsack problem
 - Add new selections   
  - Reward-based
 - Add new crossovers   
   - Voting recombination
   - Alternating-position (AP)
   - Sequential Constructive (SCX)    
   - Shuffle crossover
   - Precedence Preservative Crossover (PPX)
 - Add new mutations
   - Non-Uniform
   - Boundary
   - Gaussian 
 - Add new terminations
   - Fitness convergence 
   - Population convergence
   - Chromosome convergence   
 - New samples
   - Xamarin runner app (sample)
 - Parallel populations (islands) 
 
--------

## FAQ

Having troubles? 

- Read our [wiki](https://github.com/giacomelli/GeneticSharp/wiki).
- Tutorials
   - [Function optimization with GeneticSharp](http://diegogiacomelli.com.br/function-optimization-with-geneticsharp/) 
   - [TSP with GeneticSharp and Unity3D](http://diegogiacomelli.com.br/tsp-with-GeneticSharp-and-Unity3d/)
- Ask on Twitter [@ogiacomelli](http://twitter.com/ogiacomelli).
- Ask on [Stack Overflow](http://stackoverflow.com/questions/tagged/geneticsharp) using the tag [GeneticSharp](http://stackoverflow.com/questions/tagged/geneticsharp).
 
 --------

## How to improve it?

Create a fork of [GeneticSharp](https://github.com/giacomelli/GeneticSharp/fork). 

Did you change it? [Submit a pull request](https://github.com/giacomelli/GeneticSharp/pull/new/master).

## License
Licensed under the The MIT License (MIT).
In others words, you can use this library for developement any kind of software: open source, commercial, proprietary and alien.

# Thanks to
I would like to thanks to the guys from [SMASHINGLOG (https://smashinglogo.com)](https://smashinglogo.com/) for the amazing GeneticSharp logo.
