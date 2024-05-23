using System;

namespace OuhmaniaPeopleRecognizer.Commands
{
    public interface ICommand
    {
        void Execute(object sender, EventArgs args);
    }
}
