using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course_API.Options;
using FluentScheduler;

namespace Course_API.Providers
{
    public interface IEmailSender : IJob
    {
        string Email { get; set; }
        string Subject { get; set; }
        string Message { get; set; }
        EmailOptions emailOptions { get; set; }
        Task SendEmailAsync(string email, string subject, string message);

    }
}
