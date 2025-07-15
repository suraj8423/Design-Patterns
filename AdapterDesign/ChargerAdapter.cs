namespace AdapterDesignPattern;
public class ChargerAdapter : ICellPhoneCharger
{
    private readonly IPowerSocket _powerSocket;

    public ChargerAdapter(IPowerSocket powerSocket)
    {
        _powerSocket = powerSocket;
    }

    public void ChargePhone()
    {
        // Use the power socket to provide electricity
        _powerSocket.ProvideElectricity();
        Console.WriteLine("Adapter converts 220V AC to 5V DC...");
        Console.WriteLine("Phone is charging!");
    }
}