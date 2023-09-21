
namespace Data.Model
{
    public class BaseModel
    {
        public long ID { get; set; }
        public long? ParentID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? CreatedMembershipID { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public long? LastUpdatedMembershipID { get; set; }
        public int? RowVersion { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Display { get; set; }
        public string? Description { get; set; }
        public string? ContentHTML { get; set; }
        public string? Note { get; set; }
        public bool? Active { get; set; }
        public int? SortOrder { get; set; }
        public bool? IsHomePage { get; set; }
        public string? FileName { get; set; }
        public string? FileThumbnailName { get; set; }
        public string? Status { get; set; }
        public string? DateComplete { get; set; }
        public string? Location { get; set; }
        public string? Area { get; set; }
        public string? Recognize { get; set; }
        public bool? IsShow { get; set; }
        public BaseModel()
        {
            ParentID = GlobalHelper.CategoryLanguageID;
            SortOrder = GlobalHelper.InitializationSortOrder;
            Active = GlobalHelper.InitializationBool;
            IsShow = GlobalHelper.InitializationBool;
        }
    }
}
