namespace SecondTask.Messages
{
    public class LoggerMessage
    {
        public const string STARTUP_ERROR = "{0}: {1}";
        public const string CHECK_FIRST_ENVELOPE_ERROR = "Amount of arguments was too small. " +
                    "You need enter two arguments(double) into console, for example: dotnet run 3.4 23." +
                    "Bouth of these values have to be more than 2 and less than 100";
        public const string COMPARE_ENVELOPES = "Envelopes were compared";
        public const string DISPLAY = "Information was inputted in console";
        public const string SET_ENVELOPE = "New envelope was setted to model";
    }
}
