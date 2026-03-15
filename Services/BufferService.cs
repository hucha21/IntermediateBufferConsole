using IntermediateBufferConsole.Models;
namespace IntermediateBufferConsole.Services
{
    public class BufferService
    {
        //Class for functions working with Buffer
        private readonly IntermediateBuffer _buffer;
        private readonly List<string> _history = new();
        //variable assigned to keep track of history for later whowing inside app
        public IReadOnlyList<string> History => _history.AsReadOnly();

        public BufferService(IntermediateBuffer buffer)
        {
            _buffer = buffer;
        }

        public bool StoreWorkpiece(Workpiece workpiece)
        {
            //Check if workpiece already exists
            var existingSlot = _buffer.FindSlotByWorkpieceId(workpiece.Id);
            if (existingSlot != null)
            {
                Log($"STORE FAILED: Workpiece {workpiece.Id} already exists in Slot {existingSlot.SlotNumber}");
                return false;
            }
            //Check for free slot
            var freeSlot = _buffer.GetFreeSlot();
            if (freeSlot == null)
            {
                Log($"STORE FAILED: Buffer full (Workpiece {workpiece.Id})");
                return false;
            }
            //Store workpiece
            freeSlot.Store(workpiece);
            Log($"STORED: {workpiece} in Slot {freeSlot.SlotNumber}");
            return true;
        }

        public Workpiece? RetrieveWorkpiece(string id)
        {
            var slot = _buffer.FindSlotByWorkpieceId(id);
            //handle pieces not existing in Buffer
            if (slot == null)
            {
                Log($"RETRIEVE FAILED: Workpiece {id} not found");
                return null;
            }

            var wp = slot.Retrieve();
            Log($"RETRIEVED: {wp} from Slot {slot.SlotNumber}");
            return wp;
        }
        //function for showing current buffer state (free/occupied)
        public void PrintBufferState()
        {
            Console.WriteLine("\n--- BUFFER STATE ---");
            foreach (var slot in _buffer.Slots)
            {
                Console.WriteLine(slot.IsFree
                ? $"Slot {slot.SlotNumber}: FREE"
                : $"Slot {slot.SlotNumber}: OCCUPIED by ({slot.Workpiece})");
            }
        }
        //function for logging events and adding them to variable _history
        private void Log(string message)
        {
            var entry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {message}";
            _history.Add(entry);
            Console.WriteLine(entry);
        }
    }
}
