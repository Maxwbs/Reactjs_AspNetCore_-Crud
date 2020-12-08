using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCE.Domain.Entities
{
    public class EntidadeBase
    {
        public Guid Id { get; set; }

        public DateTime? _CreateAt;
        public DateTime? CreateAt
        {
            get { return _CreateAt; }
            set { _CreateAt = (value == null) ? DateTime.UtcNow : value; }
        }
        public DateTime? UpdateAt { get; set; }
    }
}
