using System.Threading.Tasks;

using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using Course_API.Options;
using Course_API.Exceptions;
using Course_API.Resources;
using System;
using Microsoft.Extensions.Localization;
using FluentScheduler;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net;
using System.Net.Http;

namespace Course_API.Providers
{
    public class EmailSender : IEmailSender
    {
        public EmailOptions emailOptions { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        /// <summary>
        /// Constructor of email sender
        /// </summary>
        /// <param name="emailOptions"></param>
        public EmailSender()
        {
            
        
        }

        /// <summary>
        /// Send email async
        /// </summary>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task SendEmailAsync(string email, string subject, string message)
        {
            Execute(email, subject, message).Wait();
            return Task.FromResult(0);
        }

        /// <summary>
        /// Execute send email
        /// </summary>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task Execute(string email, string subject, string body)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

            }
            
            try
            {
                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress(emailOptions.FromEmail));
                message.To.Add(new MailboxAddress(email));
                message.Subject = subject;

                BodyBuilder bodyBuilder = new BodyBuilder { HtmlBody = body };
                message.Body = bodyBuilder.ToMessageBody();

                using (SmtpClient client = new SmtpClient() )
                {
                    client.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) =>
                    {
                        return true;
                    };
                    client.Connect(emailOptions.SmtpServer, emailOptions.Port);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(emailOptions.Username, emailOptions.Password);

                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                throw new FailedSendEmailException(Account.SendPinCodeFailed);
            }
        }

        public async void Execute()
        {
            await SendEmailAsync(Email, Subject, Message);
        }
    }
}
