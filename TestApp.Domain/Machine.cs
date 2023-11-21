using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp.Domain
{
    public class Machine
    {
        public int Id { get; set; }

        public ICollection<Drink> Drinks { get; set; }
        public ICollection<Coin> Coins { get; set; }
        
        public int ClientBalance { get; set; }
       
        public int Change { get; set; }
       
        public int Coin1quantity { get; set; }
        
        public int Coin2quantity { get; set; }
        
        public int Coin5quantity { get; set; }
        
        public int Coin10quantity { get; set; }
        
        public bool Login { get; set; }

    }
}
