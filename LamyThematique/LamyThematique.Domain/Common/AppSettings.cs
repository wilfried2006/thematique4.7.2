using System.Collections.Generic;

namespace LamyThematique.Domain.Common
{
    public class AppSettings
    {
        public AppSettingsClass Settings { get; set; }

        public MaboSettings Mabo { get; set; }

        //public EloquaSettings Eloqua { get; set; }

        #region getters

        public string NawUrl => Settings.NawUrl;
        public string NawAppKey => Settings.NawAppKey;
        public string NawSecretKey => Settings.NawSecretKey;
        public List<string> MasterToCs => Settings.MasterToCs;
        public string NawImgUrl => Settings.NawImgUrl;
        public string NawMediaUrl => Settings.NawMediaUrl;
        public string NawMediaIp => Settings.NawMediaIp;
        public double SyncProcessHour => Settings.SyncProcessHour;
        public int SyncProcessInterval => Settings.SyncProcessInterval;

        //public string EloquaUrl => Eloqua.EloquaUrl;
        //public string EloquaSiteId => Eloqua.EloquaSiteId;
        //public string EloquaPartyCookie => Eloqua.EloquaPartyCookie;

        public string BlobStorageUri => Settings.BlobStorageUri;
        public string KeyVaultUri => Settings.KeyVaultUri;
        public string MediaContainerSecretName => Settings.MediaContainerSecretName;
        public string TemplatesContainerSecretName => Settings.TemplatesContainerSecretName;

        public string CallBackAppUrl => Settings.CallBackAppUrl;
        public string CalendarUrl => Settings.CalendarUrl;

        public string MaboEmbedUrl => Mabo?.MaboEmbedUrl;
        public string MaboWsUri => Mabo?.MaboWsUri;

        public string SmartSearchUrl => Settings.SmartSearchUrl;
        public int SmartSearchNumResults => Settings.SmartSearchNumResults;

        public string MaboOrderPortalId => Mabo.MaboOrderPortalId;
        public string MaboOrderServiceId => Mabo.MaboOrderServiceId;
        public string MaboOrderMvtCode => Mabo.MaboOrderMvtCode;

        public string ContactEmail => Settings.ContactEmail;
        public string NoReplyEmail => Settings.NoReplyEmail;

        public string AuthApiUrl => Settings.AuthApiUrl;
        public string AuthApiIpAddress => Settings.AuthApiIpAddress;
        public string AuthApiSolveoKey => Settings.AuthApiSolveoKey;
        public string AuthApiSecret => Settings.AuthApiSecret;
        public string AuthApiTokenUrl => Settings.AuthApiTokenUrl;

        public string SitemapPingUrl => Settings.SitemapPingUrl;
        public string DatabaseConnectionString { get; set; }

        #endregion getters
    }

    public class AppSettingsClass
    {
        public string NawUrl { get; set; }
        public string NawAppKey { get; set; }
        public string NawSecretKey { get; set; }
        public List<string> MasterToCs { get; set; }
        public string NawImgUrl { get; set; }
        public string NawMediaUrl { get; set; }
        public string NawMediaIp { get; set; }
        public double SyncProcessHour { get; set; }
        public int SyncProcessInterval { get; set; }

        //public string EloquaUrl { get; set; }
        //public string EloquaSiteId { get; set; }
        //public string EloquaPartyCookie { get; set; }

        public string BlobStorageUri { get; set; }
        public string KeyVaultUri { get; set; }
        public string MediaContainerSecretName { get; set; }
        public string TemplatesContainerSecretName { get; set; }

        public string CallBackAppUrl { get; set; }
        public string CalendarUrl { get; set; }

        //public string MaboEmbedUrl { get; set; }
        //public string MaboWSUri { get; set; }

        public string SmartSearchUrl { get; set; }
        public int SmartSearchNumResults { get; set; }

        //public string MaboOrderPortalId { get; set; }
        //public string MaboOrderServiceId { get; set; }
        //public string MaboOrderMvtCode { get; set; }

        public string ContactEmail { get; set; }
        public string NoReplyEmail { get; set; }

        public string AuthApiUrl { get; set; }
        public string AuthApiIpAddress { get; set; }
        public string AuthApiSolveoKey { get; set; }
        public string AuthApiSecret { get; set; }
        public string AuthApiTokenUrl { get; set; }

        public string SitemapPingUrl { get; set; }
    }
}
