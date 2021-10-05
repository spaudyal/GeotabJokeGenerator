using System;
using Geotab.Core;

namespace JokeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Application Start 
            Logger.LogInfo($"APP START: JokeGenerator started at {DateTime.UtcNow}");

            bool continueApplication;
            try
            {
                do
                {
                    continueApplication = true;
                    DisplayControl.ShowInstructions();
                    var userChoice = ConsoleReader.ReadKey();
                    if (UserOptionHelper.IsContinueApplication(userChoice))
                    {
                        Application.Start();
                    }
                    else if (UserOptionHelper.IsExitApplication(userChoice))
                    {
                        continueApplication = false;
                        DisplayControl.ShowApplicationExitMessage();
                    }
                    else
                    {
                        DisplayControl.ShowInvalidMessage(userChoice);
                    }

                } while (continueApplication);
            }
            catch (Exception exception)
            {
                Logger.LogError("Application Error", exception);
            }

            // Application End 
            Logger.LogInfo($"APP STOP: JokeGenerator stopped at {DateTime.UtcNow}");
        }
    }
}
