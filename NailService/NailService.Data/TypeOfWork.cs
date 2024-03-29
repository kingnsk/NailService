﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NailService.Data
{
    [Table("TypeOfWork")]
    public class TypeOfWork
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkId { get; set; }

        [Column]
        [StringLength(255)]
        public string TypeOfService { get; set; } = "Default Service";

        [Column]
        [StringLength(255)]
        public string? SubService { get; set; }

        [InverseProperty(nameof(Appountment.TypeOfWork))]
        public virtual ICollection<Appountment> Appountments { get; set; } = new HashSet<Appountment>();

    }
}
