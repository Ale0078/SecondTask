using SecondTask.Logic.Comonents.Interfaces;

namespace SecondTask.Logic.Comonents.Builders.Abstracts
{
    public abstract class Builder
    {
        public double EnvelopeWidth { get; }
        public double EnvelopeHeight { get; }

        public Builder(double envelopeWidth, double envelopeHeight) 
        {
            EnvelopeWidth = envelopeWidth;
            EnvelopeHeight = envelopeHeight;
        }

        public abstract IEnvelope Create();
    }
}
