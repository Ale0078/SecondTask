using System;

namespace SecondTask.Logic.UserInterface.Abstracts
{
    public abstract class View
    {
        public Model ModelToView { get; }

        public View(Model modelToView) 
        {
            ModelToView = modelToView;
        }

        public abstract void Display(string message);
    }
}
