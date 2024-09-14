using Microsoft.AspNetCore.Mvc;

namespace gym_logger_backend.Resources
{
    public class JsonResponse
    {
        public bool Success { get; set; }
        public int ResponseCode { get; set; }
        public string? ResponseMessage { get; set; }
        public object? Data { get; set; }
    }
    public class DefaultResponse<T>
    {
        private JsonResponse JsonResponse { get; set; }

        public DefaultResponse()
        {
            JsonResponse = new();
            JsonResponse.Success = false;
            JsonResponse.ResponseCode = 0;
            JsonResponse.ResponseMessage = string.Empty;
            JsonResponse.Data = null;
        }

        public DefaultResponse(T data, bool success, int responseCode, string responseMessage)
        {
            JsonResponse = new();
            JsonResponse.Success = success;
            JsonResponse.ResponseCode = responseCode;
            JsonResponse.ResponseMessage = responseMessage;
            JsonResponse.Data = data;
        }

        public IActionResult GetData()
        {
            return new JsonResult(JsonResponse) {
                StatusCode = JsonResponse.ResponseCode
            };
        }
    }
}
