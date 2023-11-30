namespace Data.Model
{
    public partial class EmailConfig : BaseModel
    {
		public string? MasterEmailUser { get; set; }
		public string? MasterEmailPassword { get; set; }
		public string? MasterEmailDisplay { get; set; }
		public string? SMTPServer { get; set; }
		public int? SMTPPort { get; set; }
		public bool? IsMailUsingSSL { get; set; }
		public bool? IsMailBodyHtml { get; set; }
		public EmailConfig()
        {
        }
    }
}
