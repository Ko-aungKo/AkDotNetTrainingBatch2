// See https://aka.ms/new-console-template for more information


using AkDotNetTrainingBatch2.ConsoleApp;

Console.WriteLine("Hello, World!");
AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
adoDotNetExample.Read();
adoDotNetExample.Edit();
adoDotNetExample.Update();
adoDotNetExample.Create();
adoDotNetExample.Delete();


Console.ReadKey();