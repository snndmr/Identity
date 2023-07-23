using MailKit.Net.Smtp;
using MimeKit;

namespace EmailService
{
    public class EmailSender : IEmailSender
    {
        private readonly ILogger<EmailSender> _logger;
        private readonly EmailConfiguration _configuration;

        public EmailSender(ILogger<EmailSender> logger, EmailConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);

            Send(emailMessage);
        }

        public async Task SendEmailAsync(Message message)
        {
            var mailMessage = CreateEmailMessage(message);

            await SendAsync(mailMessage);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var mimeMessage = new MimeMessage();

            mimeMessage.From.Add(new MailboxAddress(_configuration.Alias, _configuration.From));
            mimeMessage.To.AddRange(message.To);
            mimeMessage.Subject = message.Subject;

            BodyBuilder bodyBuilder = new()
            {
                HtmlBody = string.Format("<p>{0}</p>", message.Content)
            };

            if (message.Attachments != null && message.Attachments.Any())
            {
                foreach (var attachment in message.Attachments)
                {
                    using var stream = new MemoryStream();

                    attachment.CopyTo(stream);

                    bodyBuilder.Attachments.Add(attachment.FileName, stream.ToArray(), ContentType.Parse(attachment.ContentType));
                }
            }

            mimeMessage.Body = bodyBuilder.ToMessageBody();

            return mimeMessage;
        }

        private void Send(MimeMessage mimeMessage)
        {
            using SmtpClient client = new();

            try
            {
                client.Connect(_configuration.SmtpServer, _configuration.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_configuration.UserName, _configuration.Password);

                client.Send(mimeMessage);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to send email. Error: {ErrorMessage}", ex.ToString());
            }
            finally
            {
                client.Disconnect(true);
            }
        }

        private async Task SendAsync(MimeMessage mimeMessage)
        {
            using SmtpClient client = new();

            try
            {
                await client.ConnectAsync(_configuration.SmtpServer, _configuration.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.AuthenticateAsync(_configuration.UserName, _configuration.Password);
                await client.SendAsync(mimeMessage);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to send email. Error: {ErrorMessage}", ex.ToString());
            }
            finally
            {
                await client.DisconnectAsync(true);
            }
        }
    }
}
