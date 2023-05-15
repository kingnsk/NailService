using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NailService.Models.Requests
{
    public class CreateAppountmentRequest
    {
        public DateTime CreatedAt { get; set; }

        public DateTime DateOfReceipt { get; set; }

        public DateTime TimeOfReceipt { get; set; }

        public string? Comment { get; set; }

        public int  ClientId { get; set; }

        public int WorkId { get; set; }
    }
}
