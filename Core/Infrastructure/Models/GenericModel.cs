namespace TodoApi.Core.Infrastructure.Models
{
    public class GenericModel
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public DateTime? DeletionDate { get; set; }
    }
}
