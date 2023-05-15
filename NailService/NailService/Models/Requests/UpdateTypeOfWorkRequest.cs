using NailService.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace NailService.Models.Requests
{
    public class UpdateTypeOfWorkRequest
    {
        public int WorkId { get; set; }

        public string TypeOfService { get; set; }

        public string? SubService { get; set; }
    }
}
