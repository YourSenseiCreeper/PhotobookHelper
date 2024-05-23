namespace OuhmaniaPeopleRecognizer.Commands
{
    public interface ICommandFactory
    {
        ICommand GetCommand(string name);
    }
}