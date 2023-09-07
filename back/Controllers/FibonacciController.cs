using back.Service;
using Microsoft.AspNetCore.Mvc;

namespace back.Controllers
{

    [Controller]
    [Route("api/[controller]")]
    public class FibonacciController : Controller
    {
        private readonly IFibonacciService _fibonacciService;

        public FibonacciController(IFibonacciService fibonacciService)
        {
            _fibonacciService = fibonacciService;
        }

        [HttpPost("fibonaci")]
        public async Task<IActionResult> addFrase(int numero)
        {
            bool presente = _fibonacciService.presente(numero);
            return Ok(presente);
        }
    }
}
