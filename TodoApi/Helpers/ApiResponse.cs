using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Helpers
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; } = true;
        public T? Data { get; set; }
        public string? Message { get; set; }
        public string? Error { get; set; }

        public ApiResponse() { }

        public ApiResponse(T data, string message = "Thành công.")
        {
            Data = data;
            Message = message;
        }

        public ApiResponse(string error, bool success = false, string message = "Có lỗi xảy ra.")
        {
            Success = success;
            Message = message;
            Error = error;
        }
    }
}