using NailService.Data;
using NailService.Models.Requests;
using NailService.Services;
using Microsoft.AspNetCore.Mvc;

namespace NailService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        #region Serives

        private readonly IClientRepository _clientRepository;
        private readonly ILogger<ClientController> _logger;

        #endregion

        #region Constructors

        public ClientController(IClientRepository clientRepository,
            ILogger<ClientController> logger)
        {
            _logger = logger;
            _clientRepository = clientRepository;
        }

        #endregion

        #region Public Methods

        [HttpPost("create")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public IActionResult Create([FromBody] CreateClientRequest createClientRequest)
        {
            _logger.LogInformation("Create client.");
            return Ok(_clientRepository.Add(new Client
            {
                FirstName = createClientRequest.FirstName,
                LastName = createClientRequest.LastName,
                Patronymic = createClientRequest.Patronymic,
                Phone = createClientRequest.Phone,
                Comment = createClientRequest.Comment
            }));
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] UpdateClientRequest updateClientRequest)
        {
            _logger.LogInformation($"Update client id:{updateClientRequest.ClientId}");
            _clientRepository.Update(new Client
            {
                ClientId = updateClientRequest.ClientId,
                FirstName = updateClientRequest.FirstName,
                LastName = updateClientRequest.LastName,
                Patronymic = updateClientRequest.Patronymic,
                Phone = updateClientRequest.Phone,
                Comment = updateClientRequest.Comment
            });
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] int clientId)
        {
            _logger.LogInformation($"Delete client id:{clientId}");
            _clientRepository.Delete(clientId);
            return Ok();
        }

        [HttpGet("get-all")]
        [ProducesResponseType(typeof(IList<Client>), StatusCodes.Status200OK)]
        public IActionResult GetAll() =>
            Ok(_clientRepository.GetAll());

        [HttpGet("get/{clientId}")]
        [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
        public IActionResult GetById([FromRoute] int clientId) =>
            Ok(_clientRepository.GetById(clientId));


        #endregion
    }
}
