using Estoque.Api.Dtos;
using Estoque.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace Estoque.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class LeituraEtiquetaController : ControllerBase
    {
        private readonly IServicoLeituraEtiqueta _servicoLeitura;

        public LeituraEtiquetaController(IServicoLeituraEtiqueta servicoLeitura)
        {
            _servicoLeitura = servicoLeitura;
        }
        
        [HttpPost]
        [Route("leituraEtiqueta")]
        public IActionResult SalvaLeituraEtiqueta([FromBody]LeituraEtiquetaDto leituraEtiquetaDto)
        {
            if (string.IsNullOrEmpty(leituraEtiquetaDto.CodigoBarras))
                return BadRequest("Código de barras inválido");
            
            _servicoLeitura.SalvarLeituraEtiqueta(leituraEtiquetaDto.CodigoBarras);

            return Ok();
        }

        [HttpGet]
        [Route("leituraEtiqueta")]
        public IEnumerable<LeituraEtiqueta> ObterLeiturasEtiquetas()
        {
            var leituras = _servicoLeitura.ObterLeiturasEtiquetas();

            return leituras;
        }
    }
}