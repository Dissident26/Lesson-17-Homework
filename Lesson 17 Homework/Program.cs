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

//2.Кто не сделал на занятии, или хочет повторить:
//	Создать три файла. В двух должен быть какой-то текст, последний пустой.
//	Прочитать содержимое первых двух файлов в различных потоках и записать результаты чтения в третий файл так, чтобы
//	операции записи не мешали друг другу.

string firstFilePath = "./Assets/TextFile1.txt";
string secondFilePath = "./Assets/TextFile2.txt";
string destinationFile = "./Assets/result.txt";

FileReader.WriteFilesToFile(destinationFile, firstFilePath, secondFilePath);