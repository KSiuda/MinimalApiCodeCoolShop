using Domain;

namespace MinimalApiCodeCoolShop.Services.Email
{
    public interface IEmailService
    {
        void SendEmailConfirmation(Order order, string total);
    }
}
