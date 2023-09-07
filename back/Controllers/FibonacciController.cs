using back.Model;
using back.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace back.Controllers
{

    [ApiController]
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    public class FibonacciController : Controller
    {
        private readonly IFibonacciService _fibonacciService;

        public FibonacciController(IFibonacciService fibonacciService)
        {
            _fibonacciService = fibonacciService;
        }

        [HttpPost("fibonaci")]
        public async Task<IActionResult> addFrase(FibonacciRequest fibonacciRequest)
        {

            var fibonacci = new FibonacciP()
            {
              presente = _fibonacciService.presente(fibonacciRequest.numero)
            }; 
            return Ok(fibonacci);
        }
    }
}
