
using Services.Domain.Models.Usuario;
using Services.Domain.Repository.Interface.Usuario;
using Services.Domain.Views.Input.Usuario;
using System;
using System.Linq;

namespace Services.Domain.Repository.Queryable.Usuario
{
    public class UsuarioAreaAtuacaoRepository : Repository<UsuarioAreaAtuacao, decimal>, IUsuarioAreaAtuacaoRepository
    {
        private readonly GRCContext _context;
        public UsuarioAreaAtuacaoRepository(GRCContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IQueryable<UsuarioAreaAtuacao> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Ativo.HasValue && x.Ativo.Value == active).AsQueryable();
            return data;
        }

        public bool UpdateStatus(long id)
        {
            UsuarioAreaAtuacao? data = DbSet.FirstOrDefault(x => x.idUsuarioAreaAtuacao.Equals(id));
            if (data == null) return false;

            data.Ativo = !(data.Ativo ?? false);

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(UsuarioAreaAtuacaoInput input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            UsuarioAreaAtuacao data = new UsuarioAreaAtuacao
            {
                UsuarioAreaAtuacaoNome = input.UsuarioAreaAtuacaoNome,
                UsuarioAreaAtuacaoDescricao = input.UsuarioAreaAtuacaoDescricao,
                Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(UsuarioAreaAtuacaoInput input)
        {
            if (input == null) return false;

            UsuarioAreaAtuacao? data = DbSet.FirstOrDefault(x => x.idUsuarioAreaAtuacao.Equals(input.idUsuarioAreaAtuacao));
            if (data == null) return false;

            data.UsuarioAreaAtuacaoNome = input.UsuarioAreaAtuacaoNome;
            data.UsuarioAreaAtuacaoDescricao = input.UsuarioAreaAtuacaoDescricao;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            UsuarioAreaAtuacao? data = DbSet.FirstOrDefault(x => x.idUsuarioAreaAtuacao.Equals(id));
            if (data == null) return false;

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }
    }
}
