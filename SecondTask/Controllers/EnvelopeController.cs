using NLog;

using SecondTask.Messages;
using SecondTask.Logic.Comonents.Builders.Abstracts;
using SecondTask.Logic.UserInterface.Abstracts;

namespace SecondTask.Controllers
{
    public class EnvelopeController : Controller
    {
        private ILogger _logger;

        public EnvelopeController(View viewToDisplay, Builder envelopeBuilder) : 
            base(viewToDisplay, envelopeBuilder) 
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public override bool CompareEnvelopes()
        {
            _logger.Info(LoggerMessage.COMPARE_ENVELOPES);

            if (ViewToDisplay.ModelToView.CompareTo(EnvelopeBuilder.Create()) != 0) 
            {
                return true;
            }        

            return false;
        }

        public override void Display(string message)
        {
            _logger.Info(LoggerMessage.DISPLAY);

            ViewToDisplay.Display(message);
        }

        public override void SetEnvelop()
        {
            _logger.Info(LoggerMessage.SET_ENVELOPE);

            ViewToDisplay.ModelToView = EnvelopeBuilder.Create();
        }

        public override void SetBuilder(Builder envelopeBuilder)
        {
            EnvelopeBuilder = envelopeBuilder;

            _logger.Info("New envelope builder has been setted");
        }
    }
}
