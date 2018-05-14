using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CalculatorRest.Servicios;

namespace CalculatorRest.Controllers
{
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {
        // GET api/values
        [HttpGet("add/{*nums}")]
        public IActionResult Addition([Bind] string nums)
        {

            var serv = new Service();
            var result = serv.Addition(nums);
            return Ok(result);
        }
        [HttpGet("sub/{*nums}")]
        public IActionResult Substraction([Bind] string nums)
        {

            var serv = new Service();
            var result = serv.Substraction(nums);
            return Ok(result);
        }
        [HttpGet("mult/{*nums}")]
        public IActionResult Multiplication([Bind] string nums)
        {

            var serv = new Service();
            var result = serv.Multiplication(nums);
            return Ok(result);
        }
        [HttpGet("div/{*nums}")]
        public IActionResult Division([Bind] string nums)
        {

            var serv = new Service();
            var result = serv.Division(nums);
            return Ok(result);
        }
    }
}
