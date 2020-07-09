using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestMediatR.Features;

namespace TestMediatR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<TestController> _logger;

        public TestController(IMediator mediator, ILogger<TestController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public string Get() => "lololololololololololol";

        [HttpGet("request")]
        public async Task<string> TestGenericRequest()
        {
            try
            {
                return await _mediator.Send(new TestGenericRequest<int>(1024));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{ex.Message}");
                return $"{ex.Message}";
            }
        }

        [HttpGet("notification")]
        public async Task TestGenericNotification()
        {
            try
            {
                await _mediator.Publish(new TestGenericNotification<int>(1024));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{ex.Message}");
            }
        }
    }
}
