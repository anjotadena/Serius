﻿namespace API.Errors
{
    public class ApiValidationErrorResponse : ErrorResponse
    {
        public ApiValidationErrorResponse() : base(400)
        {
        }

        public IEnumerable<string> Errors { get; set; }
    }
}
