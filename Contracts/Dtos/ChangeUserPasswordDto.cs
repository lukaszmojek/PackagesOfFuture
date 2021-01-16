namespace Contracts.Dtos
{
    public class ChangeUserPasswordDto
    {
        public int UserId { get; set; }
        public string NewPassword { get; set; }
    }
}