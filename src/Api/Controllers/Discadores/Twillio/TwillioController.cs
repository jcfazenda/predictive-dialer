using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Services.Domain.Discadores.Twillio;  
using Services.Domain.Views.Input.Discadores; 

namespace Api.Controllers.Discadores.Twillio
{
    [Produces("application/json")]
    [Route("{tenant_database}/api/[controller]")]
    public class TwillioController : Controller
    {
        private readonly TwillioDial _dialWorker;

        // Injetando o Worker que faz a discagem
        public TwillioController(TwillioDial dialWorker)
        {
            _dialWorker = dialWorker ?? throw new ArgumentNullException(nameof(dialWorker));
        }

        [EnableCors("CorsPolicy")]
        [HttpPost("SendSMS")]
        public IActionResult SendSMS([FromBody] TwillioInput input)
        {
            try
            {
                if (input == null)
                    return Response(false, "warn", "Dados de busca não fornecidos", null, "warn");  

                // Chama o Worker para discar
                var dialResult = _dialWorker.SendSMS(input);

                if (!dialResult)
                    return Response(false, "warn", "Não conseguimos enviar o SMS para você.", null, "warn");

                return Response(true, "success", "SMS realizado com sucesso.", null, "success");
            }
            catch (Exception ex)
            {
                return Response(false, "error", $"Ocorreu um erro: {ex.Message}", null, "error");
            }
        } 
 
        [EnableCors("CorsPolicy")]
        [HttpPost("Dial")]
        public IActionResult Dial([FromBody] TwillioInput input)
        {
            try
            {
                if (input == null)
                    return Response(false, "warn", "Dados de busca não fornecidos", null, "warn");  

                var dialResult = _dialWorker.MakeCall(input);

                if (dialResult == null)
                    return Response(false, "warn", "Não conseguimos discaor para você.", null, "warn");

                return Response(true, "success", "Ligação realizada com sucesso.", dialResult, "success");
            }
            catch (Exception ex)
            {
                return Response(false, "error", $"Ocorreu um erro: {ex.Message}", null, "error");
            }
        } 

        [EnableCors("CorsPolicy")]
        [HttpPost("GetStatusDial")]
        public IActionResult GetStatusDial([FromBody] TwillioInput input) 
        {
            try
            {
                if (input == null)
                    return Response(false, "warn", "Dados de busca não fornecidos", null, "warn");  

                var resource = _dialWorker.GetCallStatus(input.Sid);

                if (resource == null)
                    return Response(false, "warn", "Busca por status da discagem falhou.", null, "warn");

                return Response(true, "success", "Busca por status da ligação realizada com sucesso.", resource, "success");
            }
            catch (Exception ex)
            {
                return Response(false, "error", $"Ocorreu um erro: {ex.Message}", null, "error");
            }
        } 

        [EnableCors("CorsPolicy")]
        [HttpPost("ReceiveStatus")]
        public IActionResult ReceiveStatus([FromBody] TwilioStatusInput input) 
        {
            try
            {
                if (input == null)
                    return Response(false, "warn", "Dados de busca não fornecidos", null, "warn");  

                    Console.WriteLine($"SID: {input.CallSid}, Status: {input.CallStatus}");
 

                return Response(true, "success", "Busca por status da ligação realizada com sucesso.", input, "success");
            }
            catch (Exception ex)
            {
                return Response(false, "error", $"Ocorreu um erro: {ex.Message}", null, "error");
            }
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
