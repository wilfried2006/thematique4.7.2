﻿namespace LamyThematique.Domain.Common
{
    public class SmtpSettings
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string SecretPassword { get; set; }
    }
}
