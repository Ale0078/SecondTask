using SecondTask.Logic.Comonents.Interfaces;
using SecondTask.Logic.Comonents.Builders.Abstracts;

namespace SecondTask.Logic.Comonents.Builders
{
    public class EnvelopeBuilder : Builder
    {
        public EnvelopeBuilder(double envelopeWidth, double envelopeHeight) :
            base(envelopeWidth, envelopeHeight)
        {         
        }

        public override IEnvelope Create() 
        {
            return new Envelope(EnvelopeWidth, EnvelopeHeight);
        }
    }
}
