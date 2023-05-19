using Data;
using Domain;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;

namespace MinimalApiCodeCoolShop.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly EmailContext _emailContext;

        public EmailService(IOptions<EmailContext> emailContext)
        {
            _emailContext = emailContext.Value;
        }

        public void SendEmailConfirmation(Order order, string total)
        {
            // Create a new SmtpClient instance with your SMTP server details
            var client = new SmtpClient(_emailContext.Smtp, _emailContext.Port)
            {
                Credentials = new NetworkCredential(_emailContext.Username, _emailContext.Password),
                EnableSsl = true
            };

            // Create a new MailMessage instance
            MailMessage message = new()
            {
                // Set the sender and recipient email addresses
                From = new MailAddress(_emailContext.Address),
                // Set the subject and body of the email
                Subject = "Order Confirmation",
                Body = $"Dear {order.Name},\n\nThank you for your order. Your order has been confirmed.\n\nShipping Address:\n{order.ShippingAddress}\n\nTotal amount: {total}\n\nBest Regards,\nYour CodeCoolShop"
            };
            message.To.Add(new MailAddress(order.Email));

            // Send the email using the SmtpClient
            client.Send(message);
        }
    }
}
