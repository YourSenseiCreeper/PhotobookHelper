namespace OuhmaniaPeopleRecognizer.Commands
{
    public interface ICommandFactory
    {
        ICommand Get<T>() where T : class, ICommand;
    }
}