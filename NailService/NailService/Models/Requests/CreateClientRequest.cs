using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NailService.Models.Requests
{
    public class CreateClientRequest
    {
        public string? LastName { get; set; }

        public string? FirstName { get; set; }

        public string? Patronymic { get; set; }

        public string? Phone { get; set; }

        public string? Comment { get; set; }
    }
}
