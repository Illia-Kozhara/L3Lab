using L3Lab.EntityFrameworkCore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace L3LabDotNetCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class L3LabController : ControllerBase
    {
        private readonly ILogger<L3LabController> _logger;

        public L3LabController(ILogger<L3LabController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Messages")]
        public IEnumerable<L3LabMessage> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new L3LabMessage
            {
                Created = DateTime.Now.AddDays(index),
                Content = "Test Content",
            })
            .ToArray();
        }
    }
}