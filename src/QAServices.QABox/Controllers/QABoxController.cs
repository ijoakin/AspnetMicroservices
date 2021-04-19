using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QAServices.QABox.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QABoxController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<QABoxController> _logger;

        public QABoxController(ILogger<QABoxController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<QABox> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new QABox
            {
                Date = DateTime.Now.AddDays(index),
                Description = "",
                Free = false,
                Id = index
            })
            .ToArray();
        }
    }
}
