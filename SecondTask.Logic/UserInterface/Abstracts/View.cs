using SecondTask.Logic.Comonents.Interfaces;

namespace SecondTask.Logic.UserInterface.Abstracts
{
    public abstract class View
    {
        public IEnvelope ModelToView { get; set; }

        //public View(IEnvelope modelToView) 
        //{
        //    ModelToView = modelToView;
        //}

        public abstract void Display(string message);
    }
}
