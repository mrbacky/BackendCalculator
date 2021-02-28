using System;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace CalcApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PowerController : Controller
    {
        private readonly ICalculator _calc;

        public PowerController(ICalculator calculator)
        {
            _calc = calculator;
        }

        [HttpPost]
        public IActionResult Post([FromBody] double[] numbers)
        {
            try
            {
                return Ok(_calc.Power(numbers));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}