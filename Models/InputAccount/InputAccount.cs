namespace WebAPIModule4.Models.InputAccount
{
    public class InputAccount
    {
        public Guid UserId { get; set; }
        public string LoginId { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}