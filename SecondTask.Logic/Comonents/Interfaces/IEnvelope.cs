using System;

namespace SecondTask.Logic.Comonents.Interfaces
{
    public interface IEnvelope : IComparable<IEnvelope>
    {
        double Width { get; }
        double Height { get; }
    }
}
