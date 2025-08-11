using HRSystem.Common.Enums;

namespace HRSystem.Common.Views
{
    public record EndPointResponse<T>(T Data,bool IsSuccess,string Message,ErrorCodes ErrorCodes)
    {
        public static EndPointResponse<T> Success(T Data,string Message="")
        {
            return new EndPointResponse<T>(Data,true,Message,ErrorCodes.NoError);
        }
        public static EndPointResponse<T> Failure(string message, ErrorCodes errorCode = ErrorCodes.NoError)
        {
            return new EndPointResponse<T>(default, false, message, errorCode);
        }
        public static EndPointResponse<T> Failure( ErrorCodes errorCode = ErrorCodes.NoError)
        {
            return new EndPointResponse<T>(default,false,string.Empty, errorCode);
        }
    }
}
