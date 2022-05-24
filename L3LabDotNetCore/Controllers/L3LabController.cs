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
    }
}