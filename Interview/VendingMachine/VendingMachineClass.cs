namespace Interview.VendingMachine
{
    public class VendingMachineClass
    {
        private Inventory _inventory;
        private List<Coin> _acceptedCoins;
        private IState _currentState;

        public VendingMachineClass(Inventory inventory)

        {
            _currentState = new IdleState();
            _acceptedCoins = new List<Coin>();
            _inventory = inventory ?? throw new ArgumentNullException(nameof(inventory), "Inventory cannot be null.");
        }

        public IState getVendingMachineState()
        {
            return _currentState;
        }
        public void setVendingMachineState(IState state)
        {
            _currentState = state ?? throw new ArgumentNullException(nameof(state), "State cannot be null.");
        }

        public void setCoinList(List<Coin> coinList)
        {
            _acceptedCoins = coinList;
        }
        public List<Coin> getCoinList()
        {
            return _acceptedCoins;
        }


    }
}