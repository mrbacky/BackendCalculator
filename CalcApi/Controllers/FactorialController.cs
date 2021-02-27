using System;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace CalcApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactorialController : Controller
    {
        
        
        private readonly ICalculator _calc;

        public FactorialController(ICalculator calculator)
        {
            _calc = calculator;
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] double array)
        {
            try
            {
                return Ok(_calc.Factorial(array));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }  
        }
    }
}