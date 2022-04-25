using CarClass;
using FileReaderClass;
// #1 task
var carList = new CarList();
carList.FillList();

var ellapsedMsForeachMethod = carList.ForeachMethod();
var ellapsedMsForMethod = carList.ForMethod();
var ellapsedMsParallelForeachMethod = carList.ParalelForeachMethod();
var ellapsedMsParallelFor = carList.ParalelForMethod();

Console.WriteLine("'foreach' method took {0}ms", ellapsedMsForeachMethod);
Console.WriteLine("'for' method took {0}ms", ellapsedMsForMethod);
Console.WriteLine("'Parallel.ForEach' method took {0}ms", ellapsedMsParallelForeachMethod);
Console.WriteLine("'Parallel.For' method took {0}ms", ellapsedMsParallelFor);

// #2 task

string firstFilePath = "./Assets/TextFile1.txt";
string secondFilePath = "./Assets/TextFile2.txt";
string destinationFile = "./Assets/result.txt";

//FileReader.WriteFilesToFile(destinationFile, firstFilePath, secondFilePath);
FileReader.WriteFilesToFileMultiThread(destinationFile, firstFilePath, secondFilePath);