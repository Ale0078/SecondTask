using NLog;

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

            _logger.Info("Envelopes were compared");

            return false;
        }

        public override bool CompareEnvelopes(double comparisonWidth, double comparisonHeight)
        {
            if (ViewToDisplay.ModelToView.EnvelopeToCompare.Compare(comparisonWidth, comparisonHeight)
                || new Envelope(comparisonWidth, comparisonHeight).Compare(ViewToDisplay.ModelToView.EnvelopeToCompare))
            {
                return true;
            }

            _logger.Info("Envelopes were compared");

            return false;
        }

        public override void Display(string message)
        {
            _logger.Info("Information was inputted in console");

            ViewToDisplay.Display(message);
        }

        public override void SetEnvelop(Envelope newEnvelope)
        {
            _logger.Info("New envelope was setted to model");

            ViewToDisplay.ModelToView.SetnewEnvelope(newEnvelope);
        }
    }
}
