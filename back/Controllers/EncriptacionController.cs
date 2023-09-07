using back.Service;
using Microsoft.AspNetCore.Mvc;

namespace back.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class EncriptacionController : Controller
    {
        private readonly IEncriptacionService _EncriptacionService;

        public EncriptacionController(IEncriptacionService frasesService)
        {
            _EncriptacionService = frasesService;
        }

        [HttpPost("encriptar")]
        public async Task<IActionResult> addFrase(string fraseRequest)
        {
            string frase = _EncriptacionService.encriptar(fraseRequest, +5);
            return Ok(frase);
        }



        [HttpPost("desencriptar")]
        public async Task<IActionResult> decencriptar(string fraseRequest)
        {
            string frase = _EncriptacionService.encriptar(fraseRequest, -5);
            return Ok(frase);
        }
    }
}
