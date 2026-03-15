// See https://aka.ms/new-console-template for more information
using IntermediateBufferConsole.Models;
using IntermediateBufferConsole.Services;

class Program
{
    static void Main()
    {
        var buffer = new IntermediateBuffer("MainBuffer", 8); //creatin of buffer with 8 slots
        var bufferService = new BufferService(buffer);
        var importer = new CsvImporter(bufferService);
        Console.WriteLine("\n--- Importing workpieces manually ---");
        bufferService.StoreWorkpiece(new Workpiece("WP1", "TypeA")); //expected to be successful
        bufferService.StoreWorkpiece(new Workpiece("WP2", "TypeB")); //expected to be successful
        Console.WriteLine("\n--- Retrieveing workpieces ---");
        bufferService.RetrieveWorkpiece("WP1"); //expected to be successful
        bufferService.RetrieveWorkpiece("UNKNOWN"); //expected to fail because this workpiece is not in the slot
        Console.WriteLine("\n--- Importing workpieces via .CSV ---");
        importer.Import("workpieces.csv"); //importing workpieces via CSV file
        Console.WriteLine("\n--- Current Buffer state ---");
        bufferService.PrintBufferState(); //showing current Buffer state
        Console.WriteLine("\n--------");
        Console.WriteLine("\n--- HISTORY ---");
        foreach (var log in bufferService.History) //showing history of events
            Console.WriteLine(log);
        Console.WriteLine("\n--------");
        Console.ReadLine();//window stays open until pressed ENTER
    }
}
