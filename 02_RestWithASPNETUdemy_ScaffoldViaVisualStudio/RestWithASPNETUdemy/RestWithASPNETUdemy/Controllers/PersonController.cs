using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
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
