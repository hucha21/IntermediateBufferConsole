using IntermediateBufferConsole.Models;
namespace IntermediateBufferConsole.Services
{
    public class IntermediateBuffer
    {
        //class representing Intermediate Buffer in digital form
        public string Name { get; }
        public List<BufferSlot> Slots { get; }

        public IntermediateBuffer(string name, int capacity)
        {
            Name = name;
            Slots = Enumerable.Range(1, capacity)
            .Select(i => new BufferSlot(i))
            .ToList();
        }
        //function for getting first free slot in buffer
        public BufferSlot? GetFreeSlot()
        {
            return Slots.FirstOrDefault(s => s.IsFree);
        }
        //function for finding specific slot by provided ID
        public BufferSlot? FindSlotByWorkpieceId(string id)
        {
            return Slots.FirstOrDefault(s => !s.IsFree && s.Workpiece!.Id == id);
        }
    }
}
