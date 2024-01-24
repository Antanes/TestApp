using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.PortableExecutable;
using Stateless;

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
        public State MachineState { get; set; }

        enum Trigger
        {
            CoinInserted,
            DrinkSelected,
            NotEnoughCoins,
            DispenseDrink
        }

        public enum State
        {
            IdleState,
            CoinInsertionState,
            DrinkSelectionState
        }

        StateMachine<State, Trigger> _machine;
        StateMachine<State, Trigger>.TriggerWithParameters<int> _insertCoinTrigger;
        StateMachine<State, Trigger>.TriggerWithParameters<Drink, Machine> _drinkSelectedTrigger;

        public Machine()
        {
            
            _machine = new StateMachine<State, Trigger>(() => MachineState, s => MachineState = s);

            _insertCoinTrigger = _machine.SetTriggerParameters<int>(Trigger.CoinInserted);
            _drinkSelectedTrigger = _machine.SetTriggerParameters<Drink, Machine>(Trigger.DrinkSelected);

            _machine.Configure(State.IdleState)
                .Permit(Trigger.CoinInserted, State.CoinInsertionState)
                .Ignore(Trigger.DrinkSelected);                

            _machine.Configure(State.CoinInsertionState)
                .OnEntryFrom(_insertCoinTrigger, (value, t) => OnCoinInsert(value))
                .InternalTransition<int>(_insertCoinTrigger, (value, t) => OnCoinInsert(value))
                .Permit(Trigger.DrinkSelected, State.DrinkSelectionState);

            _machine.Configure(State.DrinkSelectionState)
                .OnEntryFrom(_drinkSelectedTrigger, (Drink, Machine, t) => OnDrinkSelect(Drink, Machine))
                .Permit(Trigger.NotEnoughCoins, State.CoinInsertionState)
                .Permit(Trigger.DispenseDrink, State.IdleState); 
        }

        public void DrinkSelect(Drink drink, Machine machine)
        {
            _machine.Fire(_drinkSelectedTrigger, drink, machine);
        }
        void OnDrinkSelect(Drink drink, Machine machine)
        {
            if (drink.Quantity > 0 && drink.Price <= machine.ClientBalance)
            {
                drink.Quantity--;
                machine.Change = machine.CalculateChange(machine.ClientBalance, drink.Price);
                machine = machine.CalculateDenominations(machine, machine.Change);

                foreach (var coin in machine.Coins)
                {
                    coin.OnClientBalance = false;
                }
                machine.ClientBalance = 0;
                Dispense();
            }
            else NotEnoughCoins();
        }
        public void CoinInsert(int value)
        {
            _machine.Fire(_insertCoinTrigger, value);
        }
        void OnCoinInsert (int value)
        {
            ClientBalance += value;
        }
        public void NotEnoughCoins()
        {
            _machine.Fire(Trigger.NotEnoughCoins);
        }
        public void Dispense()
        {
            _machine.Fire(Trigger.DispenseDrink);
        }
       
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
