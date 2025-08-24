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

            var data = DbSet.Where(x => x.UsuarioEmail != null && x.UsuarioEmail.Equals(input.UsuarioEmail) &&
                                        x.UsuarioSenha != null && x.UsuarioSenha.Equals(input.UsuarioSenha))
                            .AsQueryable();

            return data; 

        }

        public IQueryable<Usuarios> GetAll(bool active)
        {
            byte value = (byte)(active ? 1 : 0); // converte bool -> byte
            var data = DbSet.Where(x => x.Ativo.HasValue && x.Ativo.Value == value)
                            .AsQueryable();

            return data;
        }

        public bool UpdateStatus(long id)
        {
            var data = DbSet.FirstOrDefault(x => x.idUsuario == id);
            if (data == null) return false;

            data.Ativo = (byte)((data.Ativo ?? 0) == 1 ? 0 : 1);

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public Usuarios Create(UsuariosInput input)
        {
            var data = new Usuarios
            {
                idCliente        = input.idCliente,
                UsuarioNome      = input.UsuarioNome,
                UsuarioSobrenome = input.UsuarioSobrenome,
                UsuarioEmail     = input.UsuarioEmail,
                UsuarioSenha     = input.UsuarioSenha,
                UsuarioAvatar    = input.UsuarioAvatar,
                Ativo            = 1
            };

            _context.Add(data);
            _context.SaveChanges();

            return data;
        }

        public bool Update(UsuariosInput input)
        {
            if (input == null) return false;

            Usuarios? data = DbSet.FirstOrDefault(x => x.idUsuario.Equals(input.idUsuario));
            if (data == null) return false;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateAvatar(UsuariosInput input)
        {
            if (input == null) return false;

            Usuarios? data = DbSet.FirstOrDefault(x => x.idUsuario.Equals(input.idUsuario));
            if (data == null) return false;

            data.UsuarioAvatar = input.UsuarioAvatar;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool UpdatePassword(UsuariosInput input)
        {
            if (input == null) return false;

            Usuarios? data = DbSet.FirstOrDefault(x => x.idUsuario.Equals(input.idUsuario));
            if (data == null) return false;

            data.UsuarioSenha = input.UsuarioSenha;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            Usuarios? data = DbSet.FirstOrDefault(x => x.idUsuario.Equals(id));
            if (data == null) return false;

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }
    }
}
