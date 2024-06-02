namespace Data.Model
{
    public partial class EmailLichSu : BaseModel
    {
        public string? EmailFrom { get; set; }
        public string? EmailTo { get; set; }
        public string? HTMLContent { get; set; }
        public DateTime? DateSend { get; set; }
        public DateTime? DateRead { get; set; }
        public bool? IsSend { get; set; }
        public bool? IsRead { get; set; }
        public EmailLichSu()
        {
        }
    }
}
