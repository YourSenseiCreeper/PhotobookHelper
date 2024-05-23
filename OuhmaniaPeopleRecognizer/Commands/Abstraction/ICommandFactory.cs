namespace OuhmaniaPeopleRecognizer.Commands
{
    public interface ICommandFactory
    {
        ICommand Get(Commands command);
    }
}