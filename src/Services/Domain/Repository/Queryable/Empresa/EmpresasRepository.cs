using Services.Domain.Models.Empresa;
using Services.Domain.Repository.Interface.Empresa;
using Services.Domain.Views.Input.Empresa;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Services.Domain.Repository.Queryable.Empresa
{
    public class EmpresasRepository : Repository<Empresas, decimal>, IEmpresasRepository
    {
        private readonly GRCContext _context;
        public EmpresasRepository(GRCContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        } 

        public IQueryable<Empresas> GetById(long id)
        { 
            var data = DbSet.Where(x => x.idEmpresa.Equals(id))
                            .AsQueryable();

            return data;
        } 

        public Empresas Create(EmpresasInput input)
        {
            var data = new Empresas
            {
                idEmpresa           = input.idEmpresa,
                EmpresaNome        = input.EmpresaNome 
            };

            _context.Add(data);
            _context.SaveChanges();

            return data;
        }

        public bool Update(EmpresasInput input)
        {
            if (input == null) return false;

            Empresas? data = DbSet.FirstOrDefault(x => x.idEmpresa.Equals(input.idEmpresa));
            if (data == null) return false;

            data.EmpresaNome        = input.EmpresaNome; 
  
            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
 
        public bool Remove(long id)
        {
            Empresas? data = DbSet.FirstOrDefault(x => x.idEmpresa.Equals(id));
            if (data == null) return false;

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }
    }
}
