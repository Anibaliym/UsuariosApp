using Microsoft.AspNetCore.Mvc;
using Usuarios.Application.Interfaces;
using Usuarios.Application.Services;
using Usuarios.Application.ViewModels.Log;
using Usuarios.Application.ViewModels.Seguridad;

namespace Usuarios.Service.Api.Controllers
{
    [Route("api/[controller]")]
    public class LogController : ApiController
    {
        private readonly ILogAppService _logAppService;

        public LogController(ILogAppService logAppService)
        {
            _logAppService = logAppService;
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear(LogCrearViewModel modelo)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _logAppService.Crear(modelo));
        }

        [HttpGet("BuscaPorId/{id:guid}")]
        public async Task<LogViewModel> BuscaPorId(Guid id)
        {
            return await _logAppService.BuscaPorId(id);
        }

        [HttpGet("BuscaPorIdUsuario/{idUsuario:guid}")]
        public async Task<LogViewModel> BuscaPorIdUsuario(Guid idUsuario)
        {
            return await _logAppService.BuscaPorIdUsuario(idUsuario);
        }

        [HttpGet("ObtieneUltimaAccionReportadaUsuario/{id:guid}")]
        public async Task<LogViewModel> ObtieneUltimaAccionReportadaUsuario(Guid id)
        {
            return await _logAppService.ObtieneUltimaAccionReportadaUsuario(id);
        }
    }
}
