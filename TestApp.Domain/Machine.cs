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
        
        public int CalculateChange(int clientbalance, int drinkprice)
        {
            int change = clientbalance - drinkprice;
            return change;
        }
        public Machine CalculateDenominations(Machine machine, int change)
        {
            var denominations = new List<int> { 10, 5, 2, 1 };
            var changedenominations = new Dictionary<int, int>();

            foreach (var denomination in denominations)
            {
                int quantity = change / denomination;
                if (quantity > 0)
                {
                    changedenominations.Add(denomination, quantity);
                    change -= denomination * quantity;
                }
                else changedenominations.Add(denomination, 0);
            }
            machine.Coin1quantity = changedenominations[1];
            machine.Coin2quantity = changedenominations[2];
            machine.Coin5quantity = changedenominations[5];
            machine.Coin10quantity = changedenominations[10];
            return machine;
        }

        public Machine Reset(Machine machine)
        {
            machine.Change = 0;
            machine.Coin1quantity = 0;
            machine.Coin2quantity = 0;
            machine.Coin5quantity = 0;
            machine.Coin10quantity = 0;
            return machine;
        }
    }
}
