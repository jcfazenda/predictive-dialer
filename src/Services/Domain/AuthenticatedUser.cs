using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Services.Domain.Models
{
    public class AuthenticatedUser
    {
        private readonly IHttpContextAccessor _accessor;

        public AuthenticatedUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        // Pode ser null se o usuário não estiver autenticado
        public string? Email => _accessor.HttpContext?.User?.Identity?.Name;

        // Retorna o NameIdentifier ou null se não existir
        public string? Name => GetClaimsIdentity()
            .FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value;

        // Sempre retorna uma coleção (nunca null)
        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext?.User?.Claims ?? Enumerable.Empty<Claim>();
        }
    }
}
