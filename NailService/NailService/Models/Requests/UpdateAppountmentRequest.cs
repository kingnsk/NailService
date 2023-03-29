using NailService.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace NailService.Models.Requests
{
    public class UpdateAppountmentRequest
    {
        public int AppountmentId { get; set; }

        public int ClientId { get; set; }

        public int WorkId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime DateOfReceipt { get; set; }

        public DateTime TimeOfReceipt { get; set; }

        public string? Comment { get; set; }

    }
}
