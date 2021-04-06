using System;

namespace SecondTask.Logic.Comonents
{
    public class Envelope : IComparable<Envelope> //ToDo: IComparable
    {
        public double Width { get; private set; }
        public double Height { get; private set; }

        public Envelope(double envelopeWidth, double envelopeHeight) 
        {
            Width = envelopeWidth;
            Height = envelopeHeight;
        }

        public int CompareTo(Envelope comparisonEnvelope)
        {
            if (((Width > comparisonEnvelope.Width) && (Height > comparisonEnvelope.Height))
                || ((Height > comparisonEnvelope.Width) && (Width > comparisonEnvelope.Height)))
            {
                return -1;
            }
            else if (((Width < comparisonEnvelope.Width) && (Height < comparisonEnvelope.Height))
                || ((Height < comparisonEnvelope.Width) && (Width < comparisonEnvelope.Height)))
            {
                return 1;
            }

            return 0;
        }
    }
}
