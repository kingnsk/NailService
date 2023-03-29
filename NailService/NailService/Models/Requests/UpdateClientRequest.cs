using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NailService.Models.Requests
{
    public class UpdateClientRequest
    {
        public int ClientId { get; set; }
        public string? LastName { get; set; }

        public string? FirstName { get; set; }

        public string? Patronymic { get; set; }

        public string? Phone { get; set; }

        public string? Comment { get; set; }

    }
}
