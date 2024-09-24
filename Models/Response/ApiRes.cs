using Microsoft.AspNetCore.Mvc;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace apekade.Models.Dto
{
    public class ApiRes
    {
        public bool Status { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        public object? Data { get; set; }
        public string TimeStamp { get; set; }

        public ApiRes(int code, bool status, string message, object? data)
        {
            Status = status;
            Code = code;
            Message = message;
            Data = data ?? new { error = "Unknown error." };
            TimeStamp = DateTime.UtcNow.ToString("o");
        }
    }
    public static class ResExtension
    {
        public static IActionResult ApiRes(this ControllerBase controller,int code,bool status, string message, object? data)
        {
            var response = new ApiRes(code,status, message, data ?? new { error = "Unknown error." });
            return new ContentResult
            {
                Content = JsonConvert.SerializeObject(response),
                ContentType = "application/json",
                StatusCode = code
            };
        }
    }

}
