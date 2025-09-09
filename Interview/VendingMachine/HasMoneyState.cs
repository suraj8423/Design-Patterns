namespace Interview.VendingMachine;

public class HasMoneyState : IState
{
    public void ClickOnInsertCoinButton(VendingMachineClass vendingMachine)
    {
        return;
    }
    
     public void ClickOnStartProductSelectionButton(VendingMachine machine) {
       machine.SetVendingMachineState(new SelectionState());

    }
    public void InsertCoin(VendingMachine machine, Coin coin){
        machine.getCoinList().Add(coin);
    }
    public void ChooseProduct(VendingMachine machine, int codeNumber){
        throw new Exception("you can not choose Product in idle state");
    }
    public int GetChange(int returnChangeMoney) {
        throw new Exception("you can not get change in idle state");
    }
    public List<Coin> RefundFullMoney(VendingMachine machine) {
        throw new Exception("you can not get refunded in idle state");
    }
    public Item DispenseProduct(VendingMachine machine, int codeNumber) {
        throw new Exception("proeduct can not be dispensed idle state");
    }
    public void UpdateInventory(VendingMachine machine, Item item, int codeNumber) {
        machine.getInventory().addItem(item, codeNumber);
    }

}