using static System.Console;

using SecondTask.Logic.Comonents.Interfaces;
using SecondTask.Logic.UserInterface.Abstracts;

namespace SecondTask.Views
{
    public class EnvelopeView : View
    {
        //public EnvelopeView(IEnvelope viewModel) : base(viewModel) 
        //{        
        //}

        public override void Display(string message)
        {
            WriteLine(message);
            WriteLine();
        }
    }
}
