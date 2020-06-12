namespace SmartHunter.Core
{
    public class AddressRange
    {
        public ulong Start { get; private set; }
        public ulong End { get; private set; }
        public ulong Size { get; private set; }

        public AddressRange(ulong start, ulong size)
        {
            Start = start;
            End = start + size;
            Size = size;
        }
    }
}
