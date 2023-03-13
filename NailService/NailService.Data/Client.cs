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
    [Table("Clients")]
    public class Client
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientId { get; set; }

        [Column]
        [StringLength(255)]
        public string? LastName { get; set; }

        [Column]
        [StringLength(255)]
        public string? FirstName { get; set; }

        [Column]
        [StringLength(255)]
        public string? Patronymic { get; set; }

        [Column]
        [StringLength(255)]
        public string? Phone { get; set; }

        [Column]
        [StringLength(255)]
        public string? Comment { get; set; }

        [InverseProperty(nameof(TypeOfWork.WorkId))]
        public virtual ICollection<TypeOfWork> TypeOfWorks { get; set; } = new HashSet<TypeOfWork>();

        [InverseProperty(nameof(Appountment.Client))]
        public virtual ICollection<Appountment> Appountments { get; set; } = new HashSet<Appountment>();

    }
}
