using IntermediateBufferConsole.Models;
namespace IntermediateBufferConsole.Services
{
    public class CsvImporter
    {
        private readonly BufferService _bufferService;

        public CsvImporter(BufferService bufferService)
        {
            _bufferService = bufferService;
        }
        //function for importing CSV
        public void Import(string filePath)
        {
            int success = 0;
            int failed = 0;
            //read line-by-line
            //expected format id,type
            foreach (var line in File.ReadLines(filePath))
            {
                try
                {
                    var parts = line.Split(',');
                    if (parts.Length != 2)
                        throw new Exception("Invalid format");

                    var wp = new Workpiece(parts[0].Trim(), parts[1].Trim());
                    if (_bufferService.StoreWorkpiece(wp))
                        success++;
                    else
                        failed++;
                }
                catch
                {
                    failed++;
                }
            }
            Console.WriteLine($"\nCSV IMPORT FINISHED: {success} successful, {failed} failed");
        }
    }
}
