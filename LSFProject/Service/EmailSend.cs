using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using LSFProject.ViewModelss;
using MailKit;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using MimeKit;

namespace LSFProject
{
    public static class EmailSend
    {
        public static async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(
                new MailboxAddress("Администрация сайта", "life.safety.fundamentals.mailto@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, false);
                await client.AuthenticateAsync("life.safety.fundamentals.mailto@gmail.com", "1500009578403sem");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }

        public static async void NewsletterSendEmailAsync(string link)
        {
            LSFProjectContext _context = new LSFProjectContext();
            List<AspNetEmailSubscribe> emailSubscribes = _context.AspNetEmailSubscribe.Where(e => e.IsConfirmed).ToList();
            
            foreach (AspNetEmailSubscribe emailSubscribe in emailSubscribes)
            {
                await EmailSend.SendEmailAsync(emailSubscribe.Email, "Добавлена новая новость на сайт",
                    System.IO.File.ReadAllText("wwwroot/NewsletterEmailPage.html")
                        .Replace("UserEmail", _context.AspNetUsers.FirstOrDefault(u => u.Id == emailSubscribe.UserId).Email)
                        .Replace("linkNewPostModeration", link));
            }
        }
    }
}