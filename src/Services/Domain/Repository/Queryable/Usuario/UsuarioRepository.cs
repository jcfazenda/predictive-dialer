using Services.Domain.Models.Usuario;
using Services.Domain.Repository.Interface.Usuario;
using Services.Domain.Views.Input.Usuario;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Services.Domain.Repository.Queryable.Usuario
{
    public class UsuariosRepository : Repository<Usuarios, decimal>, IUsuariosRepository
    {
        private readonly GRCContext _context;
        public UsuariosRepository(GRCContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IQueryable<Usuarios> GetAccess(UsuariosInput input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            var data = DbSet.Where(x => x.Usuario_Email != null &&
                                         x.Usuario_Email.Equals(input.Usuario_Email) &&
                                         x.Usuario_Senha != null &&
                                         x.Usuario_Senha.Equals(input.Usuario_Senha))
                            .AsQueryable();

            return data;
        }

        public IQueryable<Usuarios> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.HasValue && x.Fl_Ativo.Value == active)
                            .AsQueryable();

            return data;
        }

        public bool UpdateStatus(long id)
        {
            Usuarios? data = DbSet.FirstOrDefault(x => x.Id_Usuario.Equals(id));
            if (data == null) return false;

            data.Fl_Ativo = !(data.Fl_Ativo ?? false);

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public Usuarios Create(UsuariosInput input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            Usuarios data = new Usuarios
            {
                Id_Cliente        = input.Id_Cliente,
                Usuario_Nome      = input.Usuario_Nome,
                Usuario_Sobrenome = input.Usuario_Sobrenome,
                Usuario_Email     = input.Usuario_Email,
                Usuario_Senha     = input.Usuario_Senha,
                Usuario_Avatar    = input.Usuario_Avatar,
                Fl_Ativo          = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return data;
        }

        public bool Update(UsuariosInput input)
        {
            if (input == null) return false;

            Usuarios? data = DbSet.FirstOrDefault(x => x.Id_Usuario.Equals(input.Id_Usuario));
            if (data == null) return false;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateAvatar(UsuariosInput input)
        {
            if (input == null) return false;

            Usuarios? data = DbSet.FirstOrDefault(x => x.Id_Usuario.Equals(input.Id_Usuario));
            if (data == null) return false;

            data.Usuario_Avatar = input.Usuario_Avatar;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool UpdatePassword(UsuariosInput input)
        {
            if (input == null) return false;

            Usuarios? data = DbSet.FirstOrDefault(x => x.Id_Usuario.Equals(input.Id_Usuario));
            if (data == null) return false;

            data.Usuario_Senha = input.Usuario_Senha;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            Usuarios? data = DbSet.FirstOrDefault(x => x.Id_Usuario.Equals(id));
            if (data == null) return false;

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }
    }
}
