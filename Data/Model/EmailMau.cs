namespace Data.Model
{
    public partial class EmailMau : BaseModel
    {
        public string? HTMLContent { get; set; }
        public string? FileName { get; set; }
        public EmailMau()
        {
        }
    }
}
