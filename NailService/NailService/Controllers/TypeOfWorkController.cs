using NailService.Data;
using NailService.Models.Requests;
using NailService.Services;
using Microsoft.AspNetCore.Mvc;
using NailService.Services.Impl;

namespace NailService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfWorkController : ControllerBase
    {
        #region Serives

        private readonly ITypeOfWorkRepository _typeOfWorkRepository;
        private readonly ILogger<TypeOfWorkController> _logger;

        #endregion

        #region Constructors

        public TypeOfWorkController(ITypeOfWorkRepository typeOfWorkRepository,
            ILogger<TypeOfWorkController> logger)
        {
            _logger = logger;
            _typeOfWorkRepository = typeOfWorkRepository;
        }

        #endregion

        #region Public Methods

        [HttpPost("create")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public IActionResult Create([FromBody] CreateTypeOfWorkRequest createTypeOfWorkRequest)
        {
            _logger.LogInformation($"Create new type of Work.");

            return Ok(_typeOfWorkRepository.Add(new TypeOfWork
            {
                TypeOfService = createTypeOfWorkRequest.TypeOfService,
                SubService = createTypeOfWorkRequest.SubService
            })) ;
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] UpdateTypeOfWorkRequest updateTypeOfWorkRequest)
        {
            _logger.LogInformation($"Update type of Work id:{updateTypeOfWorkRequest.WorkId}");
            _typeOfWorkRepository.Update(new TypeOfWork
            {
                TypeOfService = updateTypeOfWorkRequest.TypeOfService,
                SubService = updateTypeOfWorkRequest.SubService,
                WorkId = updateTypeOfWorkRequest.WorkId

            });
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] int typeOfWorkId)
        {
            _logger.LogInformation($"Delete type of Work id:{typeOfWorkId}");
            _typeOfWorkRepository.Delete(typeOfWorkId);
            return Ok();
        }

        [HttpGet("get-all")]
        [ProducesResponseType(typeof(IList<TypeOfWork>), StatusCodes.Status200OK)]
        public IActionResult GetAll() =>
            Ok(_typeOfWorkRepository.GetAll());

        [HttpGet("get/{typeOfWorkId}")]
        [ProducesResponseType(typeof(TypeOfWork), StatusCodes.Status200OK)]
        public IActionResult GetById([FromRoute] int typeOfWorkId) =>
            Ok(_typeOfWorkRepository.GetById(typeOfWorkId));

        #endregion
    }
}
