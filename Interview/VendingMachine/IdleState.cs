namespace Interview.VendingMachine;

public class IdleState : IState
{

    public IdleState(VendingMachine machine){
        // System.out.println("Currently Vending machine is in IdleState");
        machine.setCoinList(new List<>());
    }

    public void ClickOnInsertCoinButton(VendingMachineClass vendingMachine)
    {
        vendingMachine.setVendingMachineState(new HasMoneyState());
    }
    
     public void ClickOnStartProductSelectionButton(VendingMachine machine) {
        throw new Exception("first you need to click on insert coin button");

    }
    public void InsertCoin(VendingMachine machine, Coin coin){
        throw new Exception("you can not insert Coin in idle state");
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