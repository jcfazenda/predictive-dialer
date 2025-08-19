
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
            var data = DbSet.Where(x => x.Fl_Ativo.HasValue && x.Fl_Ativo.Value == active).AsQueryable();
            return data;
        }

        public bool UpdateStatus(long id)
        {
            UsuarioAreaAtuacao? data = DbSet.FirstOrDefault(x => x.Id_Usuario_Area_Atuacao.Equals(id));
            if (data == null) return false;

            data.Fl_Ativo = !(data.Fl_Ativo ?? false);

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(UsuarioAreaAtuacaoInput input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            UsuarioAreaAtuacao data = new UsuarioAreaAtuacao
            {
                Usuario_Area_Atuacao_Nome = input.Usuario_Area_Atuacao_Nome,
                Usuario_Area_Atuacao_Descricao = input.Usuario_Area_Atuacao_Descricao,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(UsuarioAreaAtuacaoInput input)
        {
            if (input == null) return false;

            UsuarioAreaAtuacao? data = DbSet.FirstOrDefault(x => x.Id_Usuario_Area_Atuacao.Equals(input.Id_Usuario_Area_Atuacao));
            if (data == null) return false;

            data.Usuario_Area_Atuacao_Nome = input.Usuario_Area_Atuacao_Nome;
            data.Usuario_Area_Atuacao_Descricao = input.Usuario_Area_Atuacao_Descricao;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            UsuarioAreaAtuacao? data = DbSet.FirstOrDefault(x => x.Id_Usuario_Area_Atuacao.Equals(id));
            if (data == null) return false;

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }
    }
}
