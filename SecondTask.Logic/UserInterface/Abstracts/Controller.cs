using System;
using SecondTask.Logic.Comonents;

namespace SecondTask.Logic.UserInterface.Abstracts
{
    public abstract class Controller
    {
        public View ViewToDisplay { get; }

        public Controller(View viewToDisplay) 
        {
            ViewToDisplay = viewToDisplay;
        }

        public abstract void SetEnvelop(Envelope newEnvelope);
        public abstract bool CompareEnvelopes(Envelope comparisonEnvelope);
        public abstract void Display(string message);
    }
}
