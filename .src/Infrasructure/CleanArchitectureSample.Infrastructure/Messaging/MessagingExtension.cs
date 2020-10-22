using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureSample.Infrastructure.Messaging
{
    public enum ErrorTypes
    {
        BadRequest = 1,
        ItemNotFound = 2,
        ItemAlreadyExist = 3,
        InsertFaield = 4,
        UpdateFaild = 5,
        DeleteFaild = 6,
        Unecpected = 7
    }

    public static class MessagingExtension
    {
        //public static Response<T> CreateNullRequestResponse<T>(this Request<T> request, string message)
        //{
        //    var response = new Response<T>
        //    {
        //        Success = false,
        //        Message = message
        //    };
        //    response.Errors.AddError("NullRequest", message);

        //    return response;
        //}

        public static Response<T> CreateFailedResponse<T>(this Response<T> response, ErrorTypes errorTypes, string message)
        {
            response = new Response<T>
            {
                Success = false,
                Message = message
            };
            response.Errors.AddError(errorTypes.ToString(), message);

            return response;
        }

        public static SearchResponse<T> CreateFailedResponse<T>(this SearchResponse<T> response, ErrorTypes errorTypes, string message)
        {
            response = new SearchResponse<T>
            {
                Success = false,
                Message = message
            };
            response.Errors.AddError(errorTypes.ToString(), message);

            return response;
        }

        //public static SearchResponse<T> CreateNullRequestResponse<T>(this SearchRequest<T> request, string message)
        //{
        //    var response = new SearchResponse<T>
        //    {
        //        Success = false,
        //        Message = message
        //    };
        //    response.Errors.AddError("NullRequest", message);

        //    return response;
        //}
    }
}
