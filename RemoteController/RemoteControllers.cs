using System;

namespace RemoteController;

public class RemoteControllers
{
    private List<ICommand> _commands;

    public void SetCommand(ICommand command, int slot)
    {
        if (_commands == null)
        {
            _commands = new List<ICommand>(new ICommand[10]);
        }
        if (slot < 0 || slot >= _commands.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(slot), "Slot must be between 0 and 9.");
        }
        _commands[slot] = command ?? throw new ArgumentNullException(nameof(command));
    }

    public void PressButton(int slot)
    {
        if (_commands == null || slot < 0 || slot >= _commands.Count || _commands[slot] == null)
        {
            throw new InvalidOperationException("No command set for this slot.");
        }
        _commands[slot].Execute();
    }
}