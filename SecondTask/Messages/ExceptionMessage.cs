namespace SecondTask.Messages
{
    public class ExceptionMessage
    {
        public const string USER_MESSAGE = "Please, enter width of envelop and height of envelop like double.\n" +
                    "Bouth of these values have to be more than 2 and less than 100\n";
        public const string CREATE_ENVELOPE_WIDTH = "Enter width of envelope: ";
        public const string CREATE_ENVELOPE_HEIGHT = "Enter height of envelope: ";
        public const string SET_BOOLEAN_FLAGE = "Do you want to continue? (y - yes)";
        public const string FORMAT_EXCEPTION_WIDTH = "Width of envelop has to be more than 2 and less than 100.";
        public const string FORMAT_EXCEPTION_HEIGHT = "Height of envelop has to be more than 2 and less than 100.";
    }
}
