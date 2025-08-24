
using Services.Generics;
using Services.Domain.Models.Usuario;
using Services.Domain.Repository.Interface.Usuario;
using Services.Domain.Views.Input.Usuario;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Api.Controllers.Usuario
{
    [Produces("application/json")]
    [Route("{tenant_database}/api/[controller]")]
    public class UsuariosController : Controller
    {
        private readonly IUsuariosRepository _usuarios;

        public UsuariosController(IUsuariosRepository usuarios)
        {
            _usuarios = usuarios;
        }

        [EnableCors("CorsPolicy")]
        [HttpPost("Connected")]
        public IActionResult Connected([FromBody] UsuariosInput usuario)
        { 
            if (usuario == null)
                return Response(false, "warn", "Dados do usuário não fornecidos", null, "warn");

            if (!string.IsNullOrWhiteSpace(usuario.UsuarioEmail))
            {
                if (!Generics.IsEmail(usuario.UsuarioEmail))
                    return Response(false, "warn", "E-mail inválido", null, "warn");
            }

            usuario.UsuarioSenha = Hash.HashValue(usuario.UsuarioSenha?.Trim() ?? "");

            var user = _usuarios.GetAccess(usuario).FirstOrDefault();

            if (user == null)
                return Response(false, "warn", "Não conseguimos localizar você.", null, "warn");

            return Response(true, "success", "Seja bem-vindo.", user, "success");

        }


        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] UsuariosInput input)
        {
            if (input == null)
                return Response(false, "Erro", "Algo inesperado aconteceu.", null, "error");

            if (input.idUsuario == 0)
                _usuarios.Create(input);
            else
                _usuarios.Update(input);

            return Response(true, "Sucesso", "Registro criado/atualizado com sucesso", null, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] UsuariosInput input)
        {
            if (input == null)
                return Response(false, "Erro", "Dados inválidos", null, "error");

            if (input.idUsuario == 0)
                _usuarios.Create(input);
            else
                _usuarios.Update(input);

            return Response(true, "Sucesso", "Atualização realizada com sucesso", null, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] UsuariosInput input)
        {
            if (input == null)
                return Response(false, "Erro", "Dados inválidos", null, "error");

            var result = _usuarios.Remove(input.idUsuario);

            if (!result)
                return Response(false, "Erro", "Usuário não encontrado ou já removido", null, "error");

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
