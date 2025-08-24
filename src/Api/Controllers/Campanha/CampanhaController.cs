
using Services.Generics;
using Services.Domain.Models.Campanha;
using Services.Domain.Repository.Interface.Campanha;
using Services.Domain.Views.Input.Campanha;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Api.Controllers.Campanha
{
    [Produces("application/json")]
    [Route("{tenant_database}/api/[controller]")]
    public class CampanhasController : Controller
    {
        private readonly ICampanhasRepository _campanhas;

        public CampanhasController(ICampanhasRepository campanhas)
        {
            _campanhas = campanhas;
        }

        [EnableCors("CorsPolicy")]
        [HttpPost("Get")]
        public IActionResult Get([FromBody] CampanhasInput campanhas)
        {
            try
            {
                if (campanhas == null)
                    return Response(false, "warn", "Dados de budca não fornecidos", null, "warn");  

                var campain = _campanhas.GetById(campanhas.idCampanha).FirstOrDefault();

                if (campain == null)
                    return Response(false, "warn", "Não conseguimos localizar você.", null, "warn");

                return Response(true, "success", "opa, olha os dados aí.", campain, "success");
            }
            catch (Exception ex)
            {
                return Response(false, "error", $"Ocorreu um erro: {ex.Message}", null, "error");
            }
        }


        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] CampanhasInput input)
        {
            if (input == null)
                return Response(false, "Erro", "Algo inesperado aconteceu.", null, "error");

            if (input.idCampanha == 0)
                _campanhas.Create(input);
            else
                _campanhas.Update(input);

            return Response(true, "Sucesso", "Registro criado/atualizado com sucesso", null, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] CampanhasInput input)
        {
            if (input == null)
                return Response(false, "Erro", "Dados inválidos", null, "error");

            if (input.idCampanha == 0)
                _campanhas.Create(input);
            else
                _campanhas.Update(input);

            return Response(true, "Sucesso", "Atualização realizada com sucesso", null, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] CampanhasInput input)
        {
            if (input == null)
                return Response(false, "Erro", "Dados inválidos", null, "error");

            var result = _campanhas.Remove(input.idCampanha);

            if (!result)
                return Response(false, "Erro", "Campanha não encontrada ou já removido", null, "error");

            return Response(true, "Sucesso", "Registro removido com sucesso", result, "success");
        }

        protected new IActionResult Response(bool success, string Title, string Message, object? data, string type)
        {
            return Ok(new
            {
                success,
                Title,
                Message,
                data,
                type
            });
        }
    }
}
