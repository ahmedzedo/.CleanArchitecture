namespace CleanArchitectureSample.Infrastructure.Messaging
{
    public class Request<T>
    {
        public T Data { get; set; }

        public string UserName { get; set; }
    }
}
