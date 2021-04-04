namespace SecondTask.Logic.Comonents
{
    public class Envelope
    {
        public double Width { get; private set; }
        public double Height { get; private set; }

        public Envelope(double envelopeWidth, double envelopeHeight) 
        {
            Width = envelopeWidth;
            Height = envelopeHeight;
        }

        /// <summary>
        ///     Use it when you want to check if an envelope would fit in current envelope or not
        /// </summary>
        /// <returns>
        ///     Return true if comparisonEnvelope can fit in current envelope and return false if cannot
        /// </returns>
        public bool Compare(Envelope comparisonEnvelope) 
        {
            if (Width > comparisonEnvelope.Width && Height > comparisonEnvelope.Height
                || Height > comparisonEnvelope.Width && Width > comparisonEnvelope.Height) 
            {
                return true;
            }

            return false;
        }

        /// <summary>
        ///     Use it when you want to check if an envelope would fit in current envelope or not
        /// </summary>
        /// <returns>
        ///     Return true if sides of comparisonEnvelope can fit in current envelope and return false if cannot
        /// </returns>
        public bool Compare(double comparisonWidth, double comparisionHeight) 
        {
            if ((Width > comparisonWidth && Height > comparisionHeight)
                || (Height > comparisonWidth && Width > comparisionHeight))
            {
                return true;
            }

            return false;
        }
    }
}
