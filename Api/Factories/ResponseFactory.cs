using System;
using WebApplication.Responses;

namespace WebApplication.Factories
{
    public static class ResponseFactory
    {
        public static T CreateSuccessResponse<T>() where T : Response, new() 
        {
            return new T()
            {
                Succeeded = true
            };
        }
        
        public static T CreateFailureResponse<T>() where T : Response, new() 
        {
            return new T()
            {
                Succeeded = false
            };
        }
    }
}