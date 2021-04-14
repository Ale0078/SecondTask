using SecondTask.Logic.Comonents.Interfaces;
using SecondTask.Logic.Comonents.Builders.Abstracts;

namespace SecondTask.Logic.UserInterface.Abstracts
{
    public abstract class Controller
    {
        public View ViewToDisplay { get; }
        public Builder EnvelopeBuilder { get; set; }

        public Controller(View viewToDisplay, Builder envelopeBuilder) 
        {
            ViewToDisplay = viewToDisplay;
            EnvelopeBuilder = envelopeBuilder;
        }

        public abstract void SetEnvelop();
        public abstract bool CompareEnvelopes();
        public abstract void SetBuilder(Builder envelopeBuilder);
        public abstract void Display(string message);
    }
}
