using SecondTask.Logic.Comonents;
using SecondTask.Logic.UserInterface.Abstracts;

namespace SecondTask.Models
{
    public class EnvelopeViewModel : Model
    {
        public EnvelopeViewModel(Envelope comparisonEnvelope) : base (comparisonEnvelope)
        {
        }

        public override void SetnewEnvelope(Envelope newEnvelope)
        {
            EnvelopeToCompare = newEnvelope;
        }
    }
}
