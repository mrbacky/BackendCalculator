using System;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace CalcApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddController : Controller
    {
        private readonly ICalculator _calc;

        public AddController(ICalculator calculator)
        {
            _calc = calculator;
        }

        [HttpPost]
        public IActionResult Post([FromBody] double[] array)
        {
            try
            {
                return Ok(_calc.Add(array));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}