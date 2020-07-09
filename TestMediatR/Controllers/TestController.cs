using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TestMediatR.Features;

namespace TestMediatR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet]
        public async Task<string> Get()
        {
            try
            {
                return await _mediator.Send(new TestGenericRequest<int>(1024));
            }
            catch (Exception ex)
            {
                return $"{ex.Message}";
            }
        }
    }
}
