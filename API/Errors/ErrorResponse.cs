﻿namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string? message)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }

        public string? Message { get; set; }

        public string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad request",
                401 => "Unauthorized",
                404 => "Resource not found",
                500 => "Server error",
                _ => "Something went wrong"
            };
        }
    }
}
