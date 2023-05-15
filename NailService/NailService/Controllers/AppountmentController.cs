using NailService.Data;
using NailService.Models.Requests;
using NailService.Services;
using Microsoft.AspNetCore.Mvc;
using NailService.Services.Impl;

namespace NailService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppountmentController : ControllerBase
    {
        #region Serives

        private readonly IAppountmentRepository _appountmentRepository;
        private readonly ILogger<AppountmentController> _logger;

        #endregion

        #region Constructors

        public AppountmentController(IAppountmentRepository appountmentRepository,
            ILogger<AppountmentController> logger)
        {
            _logger = logger;
            _appountmentRepository = appountmentRepository;
        }

        #endregion

        #region Public Methods

        [HttpPost("create")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public IActionResult Create([FromBody] CreateAppountmentRequest createAppountmentRequest)
        {
            _logger.LogInformation("Create appountment.");
            return Ok(_appountmentRepository.Add(new Appountment
            {
                CreatedAt = createAppountmentRequest.CreatedAt,
                DateOfReceipt = createAppountmentRequest.DateOfReceipt,
                TimeOfReceipt = createAppountmentRequest.TimeOfReceipt,
                Comment = createAppountmentRequest.Comment,
                ClientId = createAppountmentRequest.ClientId,
                WorkId = createAppountmentRequest.WorkId
            }));
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] UpdateAppountmentRequest updateAppountmentRequest)
        {
            _logger.LogInformation($"Update appountment id:{updateAppountmentRequest.AppountmentId}");
            _appountmentRepository.Update(new Appountment
            {
                AppountmentId = updateAppountmentRequest.AppountmentId,
                ClientId = updateAppountmentRequest.ClientId,
                WorkId = updateAppountmentRequest.WorkId,
                CreatedAt = updateAppountmentRequest.CreatedAt,
                DateOfReceipt = updateAppountmentRequest.DateOfReceipt,
                TimeOfReceipt = updateAppountmentRequest.TimeOfReceipt,
                Comment = updateAppountmentRequest.Comment
            });
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] int appountmentId)
        {
            _logger.LogInformation($"Delete appountment id:{appountmentId}");
            _appountmentRepository.Delete(appountmentId);
            return Ok();
        }

        [HttpGet("get-all")]
        [ProducesResponseType(typeof(IList<Appountment>), StatusCodes.Status200OK)]
        public IActionResult GetAll() =>
            Ok(_appountmentRepository.GetAll());

        [HttpGet("get/{appountmentId}")]
        [ProducesResponseType(typeof(Appountment), StatusCodes.Status200OK)]
        public IActionResult GetById([FromRoute] int appountmentId) =>
            Ok(_appountmentRepository.GetById(appountmentId));


        #endregion
    }
}
