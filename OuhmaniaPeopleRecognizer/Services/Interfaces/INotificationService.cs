using System;
using System.Collections.Generic;

namespace OuhmaniaPeopleRecognizer.Services.Interfaces
{
    public interface INotificationService
    {
        void Info(string title, string message);
        void Warning(string title, string message);
        void Error(string title, string message);
        void ShowMissingFiles(string directoryPath, List<string> missingFiles, Action<string> removeCallback);
    }
}
