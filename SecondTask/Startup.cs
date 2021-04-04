using System;
using NLog;
using static System.Console;

using SecondTask.Messages;
using SecondTask.Controllers;
using SecondTask.Models;
using SecondTask.Views;
using SecondTask.Logic.Comonents;
using SecondTask.Logic.UserInterface.Abstracts;
using LibToTasks.Validation;

namespace SecondTask
{
    public class Startup
    {
        private const double MAX_ENVELOPE_WIDTH_AND_HEIGHT = 100;
        private const double MIN_ENVELOPE_WIDTH_AND_HEIGHT = 2;

        private Validator _validator;
        private Transformator _transformator;
        private ILogger _logger;

        public Startup() 
        {
            _logger = LogManager.GetCurrentClassLogger();
            _validator = new Validator();
            _transformator = new Transformator();
        }

        public void Start(string[] mainArguments) 
        {
            Envelope comparisonEnvelope = CheckFirstEnvelope(mainArguments);

            if (comparisonEnvelope == null) 
            {
                return;
            }

            Controller envelopeController = GetController(comparisonEnvelope);

            try
            {
                CheckSuitableOfEnvelopes(envelopeController);

                SetBooleanFlage(out bool flage);

                Clear();

                while (flage)
                {
                    envelopeController.SetEnvelop(CreateEnvelop());

                    CheckSuitableOfEnvelopes(envelopeController);

                    SetBooleanFlage(out flage);

                    Clear();
                }
            }
            catch (FormatException ex)
            {
                _logger.Error(LoggerMessage.STARTUP_ERROR, ex, ex.Message);

                WriteLine(ExceptionMessage.USER_MESSAGE);
            }
        }

        private void CheckSuitableOfEnvelopes(Controller envelopeController) 
        {
            if (envelopeController.CompareEnvelopes(CreateEnvelop()))
            {
                envelopeController.Display(DisplayMessage.DISPLAY_SUETABLE);
            }
            else
            {
                envelopeController.Display(DisplayMessage.DISPLAY_UNSUETABLE);
            }
        }

        private Envelope CreateEnvelop() 
        {
            Write(ExceptionMessage.CREATE_ENVELOPE_WIDTH);
            double widthOfEnvelope = GetCheckedDoubleFromString(ReadLine());

            if (widthOfEnvelope == 0.0) 
            {
                throw new FormatException(ExceptionMessage.FORMAT_EXCEPTION_WIDTH);
            }

            Write(ExceptionMessage.CREATE_ENVELOPE_HEIGHT);
            double heightofEnvelope = GetCheckedDoubleFromString(ReadLine());

            if (heightofEnvelope == 0.0)
            {
                throw new FormatException(ExceptionMessage.FORMAT_EXCEPTION_HEIGHT);
            }

            return new Envelope(widthOfEnvelope, heightofEnvelope);
        }

        private void SetBooleanFlage(out bool flage) 
        {
            WriteLine(ExceptionMessage.SET_BOOLEAN_FLAGE);

            switch (ReadKey().Key) 
            {
                case ConsoleKey.Y:
                    flage = true;
                    break;
                default:
                    flage = false;
                    break;
            }
        }

        private Controller GetController(Envelope comparisonEnvelope) 
        {
            return new EnvelopeController(
                viewToDisplay: new EnvelopeView(
                    viewModel: new EnvelopeViewModel(
                        comparisonEnvelope: comparisonEnvelope)));
        }

        private Envelope CheckFirstEnvelope(string[] mainArguments) 
        {
            try
            {
                return new Envelope(
                    envelopeWidth: GetCheckedDoubleFromString(mainArguments[0]),
                    envelopeHeight: GetCheckedDoubleFromString(mainArguments[1]));
            }
            catch (IndexOutOfRangeException)
            {
                WriteLine(ExceptionMessage.CREATE_ENVELOPE_HEIGHT);

                _logger.Error(LoggerMessage.CHECK_FIRST_ENVELOPE_ERROR);

                return default;
            }
        }

        private double GetCheckedDoubleFromString(string doubleValue) 
        {
            double envelopWidthHeight = ConvertStringToDouble(doubleValue);

            if (_validator.CheckValue(CheckDouble, envelopWidthHeight, false)) 
            {
                return envelopWidthHeight;
            }

            return default;
        }

        private double ConvertStringToDouble(string doubleValue) 
        {
            return _transformator.ConfirmConversion<double, string>(doubleValue);
        }

        private bool CheckDouble(double doubleToCheck) 
        {
            if (doubleToCheck > MAX_ENVELOPE_WIDTH_AND_HEIGHT || doubleToCheck < MIN_ENVELOPE_WIDTH_AND_HEIGHT)
            {
                return false;
            }

            return true;
        }
    }
}
