using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Domain
{
    public class Coin
    {
        public Guid Id { get; set; }

        public int Value { get; set; }
        
        public bool OnClientBalance { get; set; }
        public bool Blocked { get; set; }
        public Machine Machine { get; set; }
        public int MachineId { get; set; }
        

    }
}
