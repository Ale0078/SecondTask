using System;
using NLog;
using static System.Console;

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

                SetBoolenFlage(out bool flage);

                while (flage)
                {
                    envelopeController.SetEnvelop(CreateEnvelop());

                    CheckSuitableOfEnvelopes(envelopeController);

                    SetBoolenFlage(out flage);

                    Clear();
                }
            }
            catch (FormatException ex)
            {
                _logger.Error("{0}: {1}", ex, ex.Message);

                WriteLine("Please, enter width of envelop and height of envelop like double.\n" +
                    "Bouth of these values have to be more than 2 and less than 100\n");
            }
        }

        private void CheckSuitableOfEnvelopes(Controller envelopeController) 
        {
            if (envelopeController.CompareEnvelopes(CreateEnvelop()))
            {
                envelopeController.Display("You can push one envelope other envelope");
            }
            else
            {
                envelopeController.Display("You cannot push one envelope other envelope");
            }
        }

        private Envelope CreateEnvelop() 
        {
            Write("Enter width of envelope: ");
            double widthOfEnvelope = GetCheckedDoubleFromString(ReadLine());

            if (widthOfEnvelope == 0.0) 
            {
                throw new FormatException("Width of envelop has to be more than 2 and less than 100.");
            }

            Write("Enter height of envelope: ");
            double heightofEnvelope = GetCheckedDoubleFromString(ReadLine());

            if (heightofEnvelope == 0.0)
            {
                throw new FormatException("Height of envelop has to be more than 2 and less than 100.");
            }

            return new Envelope(widthOfEnvelope, heightofEnvelope);
        }

        private void SetBoolenFlage(out bool flage) 
        {
            WriteLine("Do you want to continue? (y - yes)");

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
                WriteLine("Please, enter width of envelop and height of envelop like double.\n" +
                    "Bouth of these values have to be more than 2 and less than 100\n");

                _logger.Error("Amount of arguments was too small. " +
                    "You need enter two arguments(double) into console, for example: dotnet run 3.4 23." +
                    "Bouth of these values have to be more than 2 and less than 100");

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
