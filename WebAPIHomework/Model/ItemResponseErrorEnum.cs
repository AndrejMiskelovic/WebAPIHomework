namespace WebAPIHomework.Model
{
    public class ItemResponseErrorEnum
    {
        public enum ItemResponseError
        {
            FileDoesNotExist,
            CouldNotOpenFile,
            FileIsEmpty,
            ServiceError,
            NumbersOutOfRange,
            RequestIsEmpty
        }
    }
}
