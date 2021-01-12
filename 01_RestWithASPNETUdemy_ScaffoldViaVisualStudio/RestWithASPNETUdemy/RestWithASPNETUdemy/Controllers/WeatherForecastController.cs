using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
		[HttpGet("sum/{FirstNumber}/{SecondNumber}")]
        public IActionResult Sum(String FirstNumber, String SecondNumber)
        {
            if (IsNumeric(FirstNumber) && IsNumeric(SecondNumber))
            {
                var sum = ConvertToDecimal(FirstNumber) + ConvertToDecimal(SecondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("invalid Input");
        }

        [HttpGet("subtraction/{FirstNumber}/{SecondNumber}")]
        public IActionResult Subtraction(String FirstNumber, String SecondNumber)
        {
            if (IsNumeric(FirstNumber) && IsNumeric(SecondNumber))
            {
                var sum = ConvertToDecimal(FirstNumber) - ConvertToDecimal(SecondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("invalid Input");
        }


        [HttpGet("multiplication/{FirstNumber}/{SecondNumber}")]
        public IActionResult Multiplication(String FirstNumber, String SecondNumber)
        {
            if (IsNumeric(FirstNumber) && IsNumeric(SecondNumber))
            {
                var sum = ConvertToDecimal(FirstNumber) * ConvertToDecimal(SecondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("invalid Input");
        }

        [HttpGet("division/{FirstNumber}/{SecondNumber}")]
        public IActionResult Division(String FirstNumber, String SecondNumber)
        {
            if (IsNumeric(FirstNumber) && IsNumeric(SecondNumber))
            {
                var sum = ConvertToDecimal(FirstNumber) / ConvertToDecimal(SecondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("invalid Input");
        }

        [HttpGet("mean/{FirstNumber}/{SecondNumber}")]
        public IActionResult Mean(String FirstNumber, String SecondNumber)
        {
            if (IsNumeric(FirstNumber) && IsNumeric(SecondNumber))
            {
                var sum = (ConvertToDecimal(FirstNumber) + ConvertToDecimal(SecondNumber))/2;
                return Ok(sum.ToString());
            }
            return BadRequest("invalid Input");
        }

        [HttpGet("square-root/{FirstNumber}")]
        public IActionResult SquareRoot(String FirstNumber)
        {
            if (IsNumeric(FirstNumber))
            {
                var squareRoot = Math.Sqrt((double)ConvertToDecimal(FirstNumber));
                return Ok(squareRoot.ToString());
            }
            return BadRequest("invalid Input");
        }


        private bool IsNumeric(string strNumber)
        {
            double number;
            bool IsNumber = double.TryParse(strNumber,
                                            System.Globalization.NumberStyles.Any,
                                            System.Globalization.NumberFormatInfo.InvariantInfo,
                                            out number);
            return IsNumber;
        }
        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue)) ;
            {
                return decimalValue;
            }
            return 0;
        }

    }
}
