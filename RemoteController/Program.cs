using System;
using RemoteController;

public class Program
{
    public static void Main(string[] args)
    {
        RemoteControllers remote = new RemoteControllers();

        ICommand lightOnCommand = new LightCommand(new Light());
        remote.SetCommand(lightOnCommand, 0);

        remote.PressButton(0); // Fan ON
    }
}