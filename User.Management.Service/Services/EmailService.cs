﻿using MailKit.Net.Smtp;
using MimeKit;
using User.Management.Service.Models;

namespace User.Management.Service.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration _emailConfiguration;
        
        public EmailService(EmailConfiguration emailConfiguration) => _emailConfiguration = emailConfiguration;
        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
        }

        private void Send(MimeMessage emailMessage)
        {
            using SmtpClient mailClient = new SmtpClient();
            try
            {
                mailClient.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.Port);
                mailClient.Authenticate(_emailConfiguration.UserName, _emailConfiguration.Password);
                mailClient.Send(emailMessage);
           
            }
            catch(Exception ex)
            {

            }
            finally
            {
                mailClient.Disconnect(true);
                mailClient.Dispose();
            }
           
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("email", _emailConfiguration.From));
            emailMessage.To.Add(MailboxAddress.Parse(message.To));
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };

            return emailMessage;
        }
    }
}