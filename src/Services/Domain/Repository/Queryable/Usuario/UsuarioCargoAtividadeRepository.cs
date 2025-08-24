
using Services.Domain.Models.Usuario;
using Services.Domain.Repository.Interface.Usuario;
using Services.Domain.Views.Input.Usuario;
using System;
using System.Linq;

namespace Services.Domain.Repository.Queryable.Usuario
{
    public class UsuarioCargoAtividadeRepository : Repository<UsuarioCargoAtividade, decimal>, IUsuarioCargoAtividadeRepository
    {
        private readonly GRCContext _context;
        public UsuarioCargoAtividadeRepository(GRCContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IQueryable<UsuarioCargoAtividade> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Ativo.HasValue && x.Ativo.Value == active).AsQueryable();
            return data;
        }

        public bool UpdateStatus(long id)
        {
            UsuarioCargoAtividade? data = DbSet.FirstOrDefault(x => x.idUsuarioCargoAtividade.Equals(id));
            if (data == null) return false;

            data.Ativo = !(data.Ativo ?? false);

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(UsuarioCargoAtividadeInput input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            UsuarioCargoAtividade data = new UsuarioCargoAtividade
            {
                UsuarioCargoAtividadeNome = input.UsuarioCargoAtividadeNome,
                UsuarioCargoAtividadeDescricao = input.UsuarioCargoAtividadeDescricao,
                Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(UsuarioCargoAtividadeInput input)
        {
            if (input == null) return false;

            UsuarioCargoAtividade? data = DbSet.FirstOrDefault(x => x.idUsuarioCargoAtividade.Equals(input.idUsuarioCargoAtividade));
            if (data == null) return false;

            data.UsuarioCargoAtividadeNome = input.UsuarioCargoAtividadeNome;
            data.UsuarioCargoAtividadeDescricao = input.UsuarioCargoAtividadeDescricao;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            UsuarioCargoAtividade? data = DbSet.FirstOrDefault(x => x.idUsuarioCargoAtividade.Equals(id));
            if (data == null) return false;

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }
    }
}
