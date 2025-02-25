namespace TaskManagementSystem.Models
{
    public interface IMailService
    {
        Task<Boolean> SendEmailAsync(string email);
    }
}
