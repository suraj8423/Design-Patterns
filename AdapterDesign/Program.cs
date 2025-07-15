using AdapterDesignPattern;

public class Program
{
    public static void Main(string[] args)
    {
        // Create a power socket
        IPowerSocket powerSocket = new PowerSocket();

        // Create a charger adapter using the power socket
        ICellPhoneCharger chargerAdapter = new ChargerAdapter(powerSocket);

        // Use the charger adapter to charge the phone
        chargerAdapter.ChargePhone();
    }
}