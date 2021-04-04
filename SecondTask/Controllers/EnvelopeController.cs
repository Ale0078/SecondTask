using NLog;

using SecondTask.Messages;
using SecondTask.Logic.Comonents;
using SecondTask.Logic.UserInterface.Abstracts;

namespace SecondTask.Controllers
{
    public class EnvelopeController : Controller
    {
        private ILogger _logger;

        public EnvelopeController(View viewToDisplay) : base(viewToDisplay) 
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public override bool CompareEnvelopes(Envelope comparisonEnvelope)
        {
            if (ViewToDisplay.ModelToView.EnvelopeToCompare.Compare(comparisonEnvelope)
                || comparisonEnvelope.Compare(ViewToDisplay.ModelToView.EnvelopeToCompare)) 
            {
                return true;
            }

            _logger.Info(LoggerMessage.COMPARE_ENVELOPES);

            return false;
        }

        public override bool CompareEnvelopes(double comparisonWidth, double comparisonHeight)
        {
            if (ViewToDisplay.ModelToView.EnvelopeToCompare.Compare(comparisonWidth, comparisonHeight)
                || new Envelope(comparisonWidth, comparisonHeight).Compare(ViewToDisplay.ModelToView.EnvelopeToCompare))
            {
                return true;
            }

            _logger.Info(LoggerMessage.COMPARE_ENVELOPES);

            return false;
        }

        public override void Display(string message)
        {
            _logger.Info(LoggerMessage.DISPLAY);

            ViewToDisplay.Display(message);
        }

        public override void SetEnvelop(Envelope newEnvelope)
        {
            _logger.Info(LoggerMessage.SET_ENVELOPE);

            ViewToDisplay.ModelToView.SetnewEnvelope(newEnvelope);
        }
    }
}
