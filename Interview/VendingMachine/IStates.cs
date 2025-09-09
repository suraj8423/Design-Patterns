namespace Interview.VendingMachine
{
    public interface IStates
    {
        public void ClickOnInsertCoinButton(VendingMachineClass vendingMachine);
        public void InsertCoin(VendingMachineClass vendingMachine, Coin coin);
        public int getChange(int returnChangeMoney);
        public void ClickOnProductSelectionButton(VendingMachineClass vendingMachine);
        public void ChooseProduct(VendingMachineClass vendingMachine, int code);
        public Item DispenseProduct(VendingMachineClass vendingMachine, int code);
        public List<Coin> RefundFullMoney(VendingMachineClass vendingMachine);

        public void UpdateInventory(VendingMachineClass vendingMachine, Item item, int code);
    }
}