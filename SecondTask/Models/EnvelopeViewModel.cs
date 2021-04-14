using SecondTask.Logic.Comonents.Interfaces;
using SecondTask.Logic.UserInterface.Abstracts;

namespace SecondTask.Models
{
    public class EnvelopeViewModel : Model
    {
        public override void SetnewEnvelope(IEnvelope newEnvelope)
        {
            EnvelopeToCompare = newEnvelope;
        }
    }
}
