using System;
using SecondTask.Logic.Comonents;

namespace SecondTask.Logic.UserInterface.Abstracts
{
    public abstract class Model
    {
        public Envelope EnvelopeToCompare { get; private set; }

        public Model(Envelope envelopeToCompare) 
        {
            EnvelopeToCompare = envelopeToCompare;
        }

        public abstract void SetnewEnvelope(Envelope newEnvelope);
    }
}
