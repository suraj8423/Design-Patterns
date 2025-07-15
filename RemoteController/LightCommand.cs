namespace RemoteController;

public class LightCommand : ICommand
{
    private readonly Light _light;

    public LightCommand(Light light)
    {
        _light = light ?? throw new ArgumentNullException(nameof(light));
    }
    public void Execute()
    {
        _light.On();
    }
    public void Undo()
    {
        _light.Off();
    }
}