using Services.Domain.Models.Campanha;
using Services.Domain.Views.Input.Campanha;
using System.Linq;

namespace Services.Domain.Repository.Interface.Campanha
{
    public interface ICampanhasRepository : IRepository<Campanhas, decimal>
    {
        IQueryable<Campanhas> GetById(long id);   
        Campanhas Create(CampanhasInput input);
        bool Update(CampanhasInput input);  
        bool Remove(long id);

    }
}
