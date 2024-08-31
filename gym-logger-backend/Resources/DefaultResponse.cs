using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace gym_logger_backend.Resources
{
    public class DefaultResponse<T>
    {
        private T Data { get; set; }
        private bool Success { get; set; }
        private int ResponseCode { get; set; }
        private string ResponseMessage { get; set; }

        public DefaultResponse()
        {
            Data = default!;
            Success = false;
            ResponseCode = 0;
            ResponseMessage = string.Empty;
        }

        public DefaultResponse(T data, bool success, int responseCode, string responseMessage)
        {
            Data = data;
            Success = success;
            ResponseCode = responseCode;
            ResponseMessage = responseMessage;
        }

        public IActionResult GetData()
        {
            return new ContentResult
            {
                Content = JsonSerializer.Serialize(this, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters = { new JsonStringEnumConverter() }
                }),
                ContentType = "application/json",
                StatusCode = ResponseCode
            };
        }
    }
}
