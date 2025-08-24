using Services.Domain.Models.Empresa;
using Services.Domain.Views.Input.Empresa;
using System.Linq;

namespace Services.Domain.Repository.Interface.Empresa
{
    public interface IEmpresasRepository : IRepository<Empresas, decimal>
    {
        IQueryable<Empresas> GetById(long id);   
        Empresas Create(EmpresasInput input);
        bool Update(EmpresasInput input);  
        bool Remove(long id);

    }
}
