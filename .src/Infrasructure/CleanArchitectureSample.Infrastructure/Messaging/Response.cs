using CleanArchitectureSample.Infrastructure.Helpers;

namespace CleanArchitectureSample.Infrastructure.Messaging
{
    public class Response<T>
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }

        public Errors Errors { get; set; }

        public Response()
        {
            Errors = new Errors();
        }
    }
}
