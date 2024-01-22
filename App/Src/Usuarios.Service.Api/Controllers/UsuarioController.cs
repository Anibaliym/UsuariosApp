using Microsoft.AspNetCore.Mvc;
using Usuarios.Application.EventSourcedNormalizers.Usuario;
using Usuarios.Application.Interfaces;
using Usuarios.Application.ViewModels.Usuario;

namespace Usuarios.Service.Api.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpGet("BuscaPorId/{id:guid}")]
        public async Task<UsuarioViewModel> BuscaPorId(Guid id)
        {
            return await _usuarioAppService.BuscaPorId(id);
        }

        [HttpGet("BuscaPorIdPersona/{id:guid}")]
        public async Task<UsuarioViewModel> BuscaPorIdPersona(Guid id)
        {
            return await _usuarioAppService.BuscaPorIdPersona(id);
        }

        [HttpGet("BuscaPorNick")]
        public async Task<UsuarioViewModel> BuscaPorNick(string nick)
        {
            return await _usuarioAppService.BuscaPorNick(nick);
        }

        [HttpGet("ObtieneUsuariosEstadoActivo")]
        public async Task<IList<UsuarioViewModel>> ObtieneUsuariosEstadoActivo()
        {
            return await _usuarioAppService.ObtieneUsuariosEstadoActivo();
        }


        [HttpGet("ObtieneUsuariosEstadoInactivo")]
        public async Task<IList<UsuarioViewModel>> ObtieneUsuariosEstadoInactivo()
        {
            return await _usuarioAppService.ObtieneUsuariosEstadoInactivo();
        }

        [HttpPut("Modificar")]
        public async Task<IActionResult> Modificar(UsuarioViewModel modelo)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _usuarioAppService.Modificar(modelo));
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear(UsuarioCrearViewModel modelo)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _usuarioAppService.Crear(modelo));
        }

        [HttpDelete("Eliminar/{id:Guid}")]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            return CustomResponse(await _usuarioAppService.Eliminar(id));
        }

        [HttpGet("History/{id:guid}")]
        public async Task<IList<UsuarioHistoryData>> History(Guid id)
        {
            return await _usuarioAppService.GetAllHistory(id);
        }
    }
}
