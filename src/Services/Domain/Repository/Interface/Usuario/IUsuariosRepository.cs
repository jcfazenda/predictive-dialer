using Services.Domain.Models.Usuario;
using Services.Domain.Views.Input.Usuario;
using System.Linq;

namespace Services.Domain.Repository.Interface.Usuario
{
    public interface IUsuariosRepository : IRepository<Usuarios, decimal>
    {
        IQueryable<Usuarios> GetAll(bool active);
        IQueryable<Usuarios> GetAccess(UsuariosInput input);

        bool UpdateStatus(long id);

        Usuarios Create(UsuariosInput input);
        bool Update(UsuariosInput input);
        bool UpdateAvatar(UsuariosInput input);
        bool UpdatePassword(UsuariosInput input);

        bool Remove(long id);

    }
}
