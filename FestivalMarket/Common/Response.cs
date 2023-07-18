/// <summary>
/// **********************************************************************************
/// Author      : Chung Trịnh
/// Mail        : hna.tvchung @gmail.com
/// Phone       : 0978.611.889
/// Facebook    : (Chung Trịnh) - https://www.facebook.com/shmily0511
/// CreateDate  : 03/2020
/// Note        : Mọi ý kiến xin gửi về mail, điện thoại hoặc fb
/// ***********************************************************************************
/// </summary>
namespace FestivalMarket.Common
{
    public class Response<T> : Response
    {
        public T Data { get; set; }

        public int DataCount { get; set; }

        public Response(int status, string message = null, T data = default)
            : base(status, message)
        {
            Data = data;
            DataCount = 0;
        }

        public Response(int status, string message = null, T data = default(T), int count = 0)
            : base(status, message)
        {
            Data = data;
            DataCount = count;
        }
    }
    public class Response
    {

        public int Status { get; set; }


        public string Message { get; set; }

        public Response(int status, string message = null)
        {

            Status = status;
            Message = message;
        }
    }
}