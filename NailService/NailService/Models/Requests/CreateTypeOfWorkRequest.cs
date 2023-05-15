using NailService.Data;

namespace NailService.Models.Requests
{
    public class CreateTypeOfWorkRequest
    {
        public string TypeOfService { get; set; } = "Default Service";

        public string? SubService { get; set; }

    }
}
