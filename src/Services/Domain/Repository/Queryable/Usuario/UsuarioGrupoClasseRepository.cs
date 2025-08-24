
using Services.Domain.Models.Usuario;
using Services.Domain.Repository.Interface.Usuario;
using Services.Domain.Views.Input.Usuario;
using System;
using System.Linq;

namespace Services.Domain.Repository.Queryable.Usuario
{
    public class UsuarioGrupoClasseRepository : Repository<UsuarioGrupoClasse, decimal>, IUsuarioGrupoClasseRepository
    {
        private readonly GRCContext _context;
        public UsuarioGrupoClasseRepository(GRCContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IQueryable<UsuarioGrupoClasse> GetAll(bool active)
        {
            return DbSet.Where(x => x.Ativo.HasValue && x.Ativo.Value == active).AsQueryable();
        }

        public bool UpdateStatus(long id)
        {
            var data = DbSet.FirstOrDefault(x => x.idUsuarioGrupoClasse == id);
            if (data == null) return false;

            data.Ativo = !(data.Ativo ?? false);

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(UsuarioGrupoClasseInput input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            var data = new UsuarioGrupoClasse
            {
                UsuarioGrupoClasseNome = input.UsuarioGrupoClasseNome ?? string.Empty,
                UsuarioGrupoClasseDescricao = input.UsuarioGrupoClasseDescricao ?? string.Empty,
                Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(UsuarioGrupoClasseInput input)
        {
            if (input == null) return false;

            var data = DbSet.FirstOrDefault(x => x.idUsuarioGrupoClasse == input.idUsuarioGrupoClasse);
            if (data == null) return false;

            data.UsuarioGrupoClasseNome = input.UsuarioGrupoClasseNome ?? string.Empty;
            data.UsuarioGrupoClasseDescricao = input.UsuarioGrupoClasseDescricao ?? string.Empty;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            var data = DbSet.FirstOrDefault(x => x.idUsuarioGrupoClasse == id);
            if (data == null) return false;

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }
    }
}
