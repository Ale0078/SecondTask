using static System.Console;

using SecondTask.Logic.UserInterface.Abstracts;

namespace SecondTask.Views
{
    public class EnvelopeView : View
    {
        public EnvelopeView(Model viewModel) : base(viewModel) 
        {        
        }

        public override void Display(string message)
        {
            WriteLine(message);
            WriteLine();
        }
    }
}
