using System;
using NLog;
using static System.Console;

using SecondTask.Messages;
using SecondTask.Controllers;
//using SecondTask.Models;
using SecondTask.Views;
using SecondTask.Logic.Comonents.Builders;
using SecondTask.Logic.Comonents.Builders.Abstracts;
using SecondTask.Logic.UserInterface.Abstracts;
using LibToTasks.Validation.Interfaces;
using LibToTasks.Builders;

namespace SecondTask
{
    public class Startup
    {
        private const double MAX_ENVELOPE_WIDTH_AND_HEIGHT = 100;
        private const double MIN_ENVELOPE_WIDTH_AND_HEIGHT = 2;

        private IValidator _validator;
        private ITransformator _transformator;
        private ILogger _logger;

        public Startup() 
        {
            _logger = LogManager.GetCurrentClassLogger();
            _validator = new DefaultValidatorBuilder().Create();
            _transformator = new DefaultTransformatorBuilder().Create();
        }

        public void Start(string[] mainArguments) 
        {
            if (mainArguments.Length != 2) 
            {
                WriteLine(ExceptionMessage.USER_MESSAGE);

                _logger.Error(ExceptionMessage.USER_MESSAGE);

                return;
            }

            try
            {
                Controller envelopeController = GetController(
                    envelopeWidth: GetCheckedDoubleFromString(mainArguments[0]),
                    envelopeHeight: GetCheckedDoubleFromString(mainArguments[1]));

                envelopeController.SetEnvelop();

                envelopeController.SetBuilder(CreateBuilder());

                CheckSuitableOfEnvelopes(envelopeController);

                SetBooleanFlage(out bool flage);

                Clear();

                while (flage)
                {
                    envelopeController.SetBuilder(CreateBuilder());

                    envelopeController.SetEnvelop();

                    envelopeController.SetBuilder(CreateBuilder());

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
            if (envelopeController.CompareEnvelopes())
            {
                envelopeController.Display(DisplayMessage.DISPLAY_SUETABLE);
            }
            else
            {
                envelopeController.Display(DisplayMessage.DISPLAY_UNSUETABLE);
            }
        }

        private Builder CreateBuilder() 
        {
            Write(ExceptionMessage.CREATE_ENVELOPE_WIDTH);
            double widthOfEnvelope = GetCheckedDoubleFromString(ReadLine());

            if (widthOfEnvelope == default)
            {
                throw new FormatException(ExceptionMessage.FORMAT_EXCEPTION_WIDTH);
            }

            Write(ExceptionMessage.CREATE_ENVELOPE_HEIGHT);
            double heightofEnvelope = GetCheckedDoubleFromString(ReadLine());

            if (heightofEnvelope == default)
            {
                throw new FormatException(ExceptionMessage.FORMAT_EXCEPTION_HEIGHT);
            }

            return new EnvelopeBuilder(widthOfEnvelope, heightofEnvelope);
        }

        private void SetBooleanFlage(out bool flage) 
        {
            WriteLine(ExceptionMessage.SET_BOOLEAN_FLAGE);

            flage = (ReadLine().ToUpper()) switch
            {
                "Y" or "YES" => true,
                _ => false,
            };
        }

        private Controller GetController(double envelopeWidth, double envelopeHeight) 
        {
            return new EnvelopeController(
                viewToDisplay: new EnvelopeView(),
                envelopeBuilder: new EnvelopeBuilder(envelopeWidth, envelopeHeight));
        }

        private double GetCheckedDoubleFromString(string doubleValue) 
        {
            double envelopWidthHeight = ConvertStringToDouble(doubleValue);

            if (_validator.CheckValue(CheckDouble, envelopWidthHeight, true)) 
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
