namespace WebApplication.Responses
{
    public abstract class Response
    {
        public bool Succeeded { get; set; }
        public string Error { get; set; }
    }
}