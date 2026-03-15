namespace IntermediateBufferConsole.Models
{
    //model class for BufferSlot
    public class BufferSlot
    {
        public int SlotNumber { get; }
        public Workpiece? Workpiece { get; private set; }
        public bool IsFree => Workpiece == null;
        public BufferSlot(int slotNumber)
        {
            SlotNumber = slotNumber;
        }
        public void Store(Workpiece workpiece)
        {
            Workpiece = workpiece;
        }
        public Workpiece? Retrieve()
        {
            var wp = Workpiece;
            Workpiece = null;
            return wp;
        }
    }
}