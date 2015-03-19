# NBenchmarker
A lightweight, micro-benchmarker for .NET.

Do you have an algorithm that you need to eek every last CPU cycle out of? Is it not clear which option will give the best performance? [Performance tuning](http://en.wikipedia.org/wiki/Performance_tuning) requires measurement; NBenchmarker can help!

Here's an example that compares two different options by running each expression as many times as possible within a specified amount of time (5 seconds):
```
var trial1 = new Trial("100ms Trial")
{
    ForEachIteration = () => Thread.Sleep(100)
};
var trial2 = new Trial("1000ms Trial")
{
    ForEachIteration = () => Thread.Sleep(1000)
};
var benchmarker = new Benchmarker();
benchmarker.AddConstraint(new SecondsConstraint(5));
benchmarker.Run(trial1, trial2)
    .ToList()
    .ForEach(result =>
    {
        Console.WriteLine(result.TrialName);
        Console.WriteLine("Elapsed time: " + result.ElapsedTime);
        Console.WriteLine("# of iterations: " + result.NumberOfIterations);
        Console.WriteLine("Avg iteration duration: " + result.IterationAverageDuration);
        Console.WriteLine();
    });
```

This example outputs the following results:
```
100ms Trial
Elapsed time: 00:00:05.0083071
# of iterations: 46
Avg iteration duration: 00:00:00.1088762

1000ms Trial
Elapsed time: 00:00:05.0488858
# of iterations: 5
Avg iteration duration: 00:00:01.0097771
```
