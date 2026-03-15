namespace IntermediateBufferConsole.Models
{
    //model class for Workpiece
    public class Workpiece
    {
        public string Id { get; }
        public string Type { get; }
        public Workpiece(string id, string type)
        {
            Id = id;
            Type = type;
        }
        public override string ToString()
        {
            return $"{Id} ({Type})";
        }
    }
}