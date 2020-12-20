namespace Contracts.Responses
{
    public class Response<T>
    {
        public bool Succeeded { get; set; }
        public string Error { get; set; }
        public T Content { get; set; }
    }
}