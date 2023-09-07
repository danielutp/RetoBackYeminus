using back.Model;
using back.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace back.Controllers
{
    [ApiController]
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    public class EncriptacionController : Controller
    {
        private readonly IEncriptacionService _EncriptacionService;

        public EncriptacionController(IEncriptacionService frasesService)
        {
            _EncriptacionService = frasesService;
        }

        [HttpPost("encriptar")]
        public async Task<IActionResult> encriptar(EncriptacionRequest encriptacionRequest)
        {
            var frase = new EncriptacionRequest()
            {
                frase = _EncriptacionService.encriptar(encriptacionRequest.frase, +5)
            };
            return Ok(frase);
        }



        [HttpPost("desencriptar")]
        public async Task<IActionResult> desencriptar(EncriptacionRequest encriptacionRequest)
        {
            var frase = new EncriptacionRequest()
            {
                frase = _EncriptacionService.encriptar(encriptacionRequest.frase, -5)
            };
            return Ok(frase);
        }
    }
}
