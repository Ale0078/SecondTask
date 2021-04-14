using SecondTask.Logic.Comonents.Interfaces;

namespace SecondTask.Logic.UserInterface.Abstracts
{
    public abstract class Model
    {
        public IEnvelope EnvelopeToCompare { get; protected set; }

        public abstract void SetnewEnvelope(IEnvelope newEnvelope);
    }
}
