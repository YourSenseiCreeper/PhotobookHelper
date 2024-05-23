using OuhmaniaPeopleRecognizer.Commands.Abstraction;

namespace OuhmaniaPeopleRecognizer.Commands
{
    public interface ICommandFactory
    {
        ICommand Get(Command command);
    }
}