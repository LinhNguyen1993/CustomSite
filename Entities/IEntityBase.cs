using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomSite.Entities
{
    public interface IEntityBase
    {
        Guid Id { get; set; }
        byte[] RowVersion { get; set; }
    }
    public class EntityBase : IEntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}