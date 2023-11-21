using System;


namespace TestApp.Domain
{
    public class Drink
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public byte[]? Avatar { get; set; }
        public Machine Machine { get; set; }
        public int MachineId { get; set; }
    }
}
