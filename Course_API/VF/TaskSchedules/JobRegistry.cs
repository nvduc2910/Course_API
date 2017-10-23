using System;
using Course_API.Options;
using Course_API.Providers;
using FluentScheduler;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;


namespace Course_API.TaskSchedules
{
    public class JobRegistry : FluentScheduler.Registry
    {
        
        public JobRegistry(string email, string subject, string message, DateTime date, EmailOptions emailOptions)
        {

            var emailSender = new EmailSender();
            emailSender.Email = email;
            emailSender.Subject = subject;
            emailSender.Message = message;
            emailSender.emailOptions = emailOptions;



            Schedule(() => emailSender.Execute()).ToRunOnceAt(date.AddDays(-7));

        }


    }


}
