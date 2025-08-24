using Services.Domain.Models.Campanha;
using Services.Domain.Models.Empresa;
using Services.Domain.Repository.Interface.Campanha;
using Services.Domain.Views.Input.Campanha;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Services.Domain.Repository.Queryable.Campanha
{
    public class CampanhasRepository : Repository<Campanhas, decimal>, ICampanhasRepository
    {
        private readonly GRCContext _context;
        public CampanhasRepository(GRCContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        } 

        public IQueryable<Campanhas> GetById(long id)
        { 
            var data = DbSet
                .Include(c => c.Empresas)  
                .Where(x => x.idCampanha == id)
                .AsQueryable();

            return data;
        }

        public Campanhas Create(CampanhasInput input)
        {
            var data = new Campanhas
            {
                idEmpresa           = input.idEmpresa,
                CampanhaNome        = input.CampanhaNome 
            };

            _context.Add(data);
            _context.SaveChanges();

            return data;
        }

        public bool Update(CampanhasInput input)
        {
            if (input == null) return false;

            Campanhas? data = DbSet.FirstOrDefault(x => x.idCampanha.Equals(input.idCampanha));
            if (data == null) return false;

            data.CampanhaNome        = input.CampanhaNome; 
            data.idEmpresa           = input.idEmpresa;
  
            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
 
        public bool Remove(long id)
        {
            Campanhas? data = DbSet.FirstOrDefault(x => x.idCampanha.Equals(id));
            if (data == null) return false;

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }
    }
}
