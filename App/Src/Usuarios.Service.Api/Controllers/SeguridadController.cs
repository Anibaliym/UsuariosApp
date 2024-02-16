using Microsoft.AspNetCore.Mvc;
using Usuarios.Application.Interfaces;
using Usuarios.Application.ViewModels.Seguridad;

namespace Usuarios.Service.Api.Controllers
{
    [Route("api/[controller]")]

    public class SeguridadController : ApiController
    {
        private readonly ISeguridadAppService _seguridadAppService;

        public SeguridadController(ISeguridadAppService seguridadAppService) { 
            _seguridadAppService = seguridadAppService;
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear(SeguridadCrearViewModel modelo)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _seguridadAppService.Crear(modelo));
        }

        [HttpPut("Modificar")]
        public async Task<IActionResult> Modificar(SeguridadModificarViewModel modelo)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _seguridadAppService.Modificar(modelo));
        }

        [HttpGet("BuscaPorId/{id:guid}")]
        public async Task<SeguridadViewModel> BuscaPorId(Guid id)
        {
            return await _seguridadAppService.BuscaPorId(id);
        }

        [HttpGet("BuscaPorIdUsuario/{idUsuario:guid}")]
        public async Task<SeguridadViewModel> BuscaPorIdUsuario(Guid idUsuario)
        {
            return await _seguridadAppService.BuscaPorIdUsuario(idUsuario);
        }

        [HttpGet("ObtieneIntentosPorId")]
        public async Task<IActionResult> ObtieneIntentosPorId(Guid id)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _seguridadAppService.ObtieneIntentosPorId(id));
        }
    }
}
