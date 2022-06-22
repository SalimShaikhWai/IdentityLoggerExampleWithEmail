using IdentityLogger.Data.Models;

namespace IdentityLogger.Data.Service
{
    public interface IEmailService
    {
        Task SendTestEmail(UserEmailOptions userEmailOptions);
    }
}