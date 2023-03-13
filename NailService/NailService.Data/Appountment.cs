using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NailService.Data
{
    [Table("Appountments")]
    public class Appountment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppountmentId { get; set; }

        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }

        [ForeignKey(nameof(TypeOfWork))]
        public int WorkId { get; set; }

        [Column]
        public DateTime CreatedAt { get; set; }

        [Column]
        public DateTime DateOfReceipt { get; set; }

        [Column]
        public DateTime TimeOfReceipt { get; set; }

        [Column]
        [StringLength(255)]
        public string? Comment { get; set; }

        public virtual Client Client { get; set; }
        public virtual TypeOfWork TypeOfWork { get; set; }
    }
}
