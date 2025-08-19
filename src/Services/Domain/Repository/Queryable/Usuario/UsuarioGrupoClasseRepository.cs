
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
            return DbSet.Where(x => x.Fl_Ativo.HasValue && x.Fl_Ativo.Value == active).AsQueryable();
        }

        public bool UpdateStatus(long id)
        {
            var data = DbSet.FirstOrDefault(x => x.Id_Usuario_Grupo_Classe == id);
            if (data == null) return false;

            data.Fl_Ativo = !(data.Fl_Ativo ?? false);

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(UsuarioGrupoClasseInput input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            var data = new UsuarioGrupoClasse
            {
                Usuario_Grupo_Classe_Nome = input.Usuario_Grupo_Classe_Nome ?? string.Empty,
                Usuario_Grupo_Classe_Descricao = input.Usuario_Grupo_Classe_Descricao ?? string.Empty,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(UsuarioGrupoClasseInput input)
        {
            if (input == null) return false;

            var data = DbSet.FirstOrDefault(x => x.Id_Usuario_Grupo_Classe == input.Id_Usuario_Grupo_Classe);
            if (data == null) return false;

            data.Usuario_Grupo_Classe_Nome = input.Usuario_Grupo_Classe_Nome ?? string.Empty;
            data.Usuario_Grupo_Classe_Descricao = input.Usuario_Grupo_Classe_Descricao ?? string.Empty;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            var data = DbSet.FirstOrDefault(x => x.Id_Usuario_Grupo_Classe == id);
            if (data == null) return false;

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }
    }
}
