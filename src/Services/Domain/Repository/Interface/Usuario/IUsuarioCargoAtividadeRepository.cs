using Services.Domain.Models.Usuario;
using Services.Domain.Views.Input.Usuario;
using System.Linq;

namespace Services.Domain.Repository.Interface.Usuario
{
    public interface IUsuarioCargoAtividadeRepository : IRepository<UsuarioCargoAtividade, decimal>
    {
        IQueryable<UsuarioCargoAtividade> GetAll(bool active);

        bool UpdateStatus(long id);

        bool Create(UsuarioCargoAtividadeInput input);
        bool Update(UsuarioCargoAtividadeInput input);
        bool Remove(long id);

    }
}
