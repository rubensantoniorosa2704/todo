using System;

namespace TodoApi.GenericEntities
{
    public class GenericEntity
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public DateTime? DeletionDate { get; set; }
    }
}
