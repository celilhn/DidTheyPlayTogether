using System;
using System.Net;

namespace Application.Models
{
    public class CommonApiResponse
    {
        public static CommonApiResponse Create(int statusCode, object result = null, string message = null)
        {
            return new CommonApiResponse(statusCode, result, message);
        }

        public int StatusCode { get; set; }
        public string RequestId { get; }
        public string Message { get; set; }
        public object Data { get; set; }

        protected CommonApiResponse(int statusCode, object data = null, string message = null)
        {
            RequestId = Guid.NewGuid().ToString();
            StatusCode = statusCode;
            Data = data;
            Message = message;
        }
    }
}
