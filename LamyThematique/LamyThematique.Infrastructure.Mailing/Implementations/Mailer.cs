using LamyThematique.Domain.Helpers;
using MimeKit;
using System.Threading.Tasks;
using System;
using LamyThematique.Domain;
using LamyThematique.Domain.Common;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;

namespace LamyThematique.Infrastructure.Mailing.Implementations
{
    public class Mailer : IMailer
    {
        #region Dependencies
        private readonly SmtpSettings _smtpSettings;
        private readonly AppSettings _appSettings;
        private readonly IAppLogger<Mailer> _logger;
        #endregion Dependencies

        #region Constructor

        public Mailer(IOptions<SmtpSettings> smtpSettings, IOptions<AppSettings> appSettings, IAppLogger<Mailer> logger)
        {
            _smtpSettings = smtpSettings?.Value ?? throw new ArgumentNullException(nameof(smtpSettings));
            _appSettings = appSettings?.Value ?? throw new ArgumentNullException(nameof(appSettings));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        #endregion Constructor

        #region Public Methods

        public async Task SendEmailAsync(string toEmail, string fromEmail, string subject, string htmlBody, string name)
        {
            try
            {
                var message = new MimeMessage()
                {
                    Subject = subject,
                    Body = new TextPart("html") { Text = htmlBody }
                };

                message.From.Add(new MailboxAddress(name, fromEmail));
                message.To.Add(MailboxAddress.Parse(toEmail));
                
                using (var client = new SmtpClient())
                {
                    if ("Development".Equals(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")))
                        await client.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, true);
                    else
                        await client.ConnectAsync(_smtpSettings.Server);

                    _logger.LogInformation($"Mailer - Connected with SMTP Server: {_smtpSettings.Server}");

                    var password = AzureHelper.GetSecretValue(_appSettings.KeyVaultUri, _smtpSettings.SecretPassword);

                    client.Authenticate(_smtpSettings.Username, password);

                    _logger.LogInformation($"Mailer - Sending message to {toEmail}");

                    await client.SendAsync(message);

                    _logger.LogInformation($"Mailer - SMTP Client: Disconnection");

                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Mailer - Exception: {e.Message}");
                throw new InvalidOperationException(e.Message);
            }
        }

        #endregion Public Methods
    }
}