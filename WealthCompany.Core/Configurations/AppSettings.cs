

namespace WealthCompany.Core.Configurations
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string CommonAPIBaseUrl { get; set; }
        public SendSMS SendSMS { get; set; }
        public string CC { get; set; }
        public string BCC { get; set; }
        public string MsgFrom { get; set; }
        public string EncryptionKey { get; set; }
        public string EncryptionKeyNumber { get; set; }
        public string EmandateReturnUrl { get; set; }
        public string EmandateCallUrl { get; set; }
        public string ProductCode { get; set; }
        public string WalletBaseUrl { get; set; }
        public string GoldOrSilverSummaryUrl { get; set; }
        public string GetWithdrawalDetailsUrl { get; set; }



    }

    public class SendSMS
    {
        public string ACLApiUrl { get; set; }
        public string ACLPwd { get; set; }
        public string ACLSender { get; set; }
        public string ACLEnterpriseId { get; set; }
    }
}
