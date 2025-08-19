

using Services.Domain.Models.Usuario;
using Services.Domain.Views.Output.Usuario;
using AutoMapper;

namespace Services.Domain.Mapping
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {

            #region Usuarios

            CreateMap<Usuarios, UsuariosOutput>()
                .ForMember(f => f.Id_Usuario, t => t.MapFrom(m => m.Id_Usuario))
                .ForMember(f => f.Id_Cliente, t => t.MapFrom(m => m.Id_Cliente))

                .ForMember(f => f.Usuario_Nome, t => t.MapFrom(m => m.Usuario_Nome))
                .ForMember(f => f.Usuario_Sobrenome, t => t.MapFrom(m => m.Usuario_Sobrenome))
                .ForMember(f => f.Usuario_Email, t => t.MapFrom(m => m.Usuario_Email))
                .ForMember(f => f.Usuario_Senha, t => t.MapFrom(m => m.Usuario_Senha))
                .ForMember(f => f.Usuario_Avatar, t => t.MapFrom(m => m.Usuario_Avatar))
                .ForMember(f => f.Fl_Ativo, t => t.MapFrom(m => m.Fl_Ativo))

                ;

            #endregion

        }
    }
}
