using HRSystem.Common.Enums;

namespace HRSystem.Common.Views
{
    public record RequestResult<T>(T Data, bool IsSuccess, string Message, ErrorCodes ErrorCodes)
    {
        public static RequestResult<T> Success(T Data, string Message = "")
        {
            return new RequestResult<T>(Data, true, Message, ErrorCodes.NoError);
        }
        public static RequestResult<T> Failure(string message, ErrorCodes errorCode = ErrorCodes.NoError)
        {
            return new RequestResult<T>(default, false, message, errorCode);
        }
        public static RequestResult<T> Failure(ErrorCodes errorCode = ErrorCodes.NoError)
        {
            return new RequestResult<T>(default, false, string.Empty, errorCode);
        }
    }
}
