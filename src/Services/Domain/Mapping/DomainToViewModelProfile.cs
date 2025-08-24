
using Services.Domain.Models.Usuario;
using Services.Domain.Models.Campanha;
using Services.Domain.Models.Cliente;
using Services.Domain.Models.Empresa;
using Services.Domain.Models.Operador;
using Services.Domain.Models.Telefone;

using Services.Domain.Views.Output.Usuario;
using Services.Domain.Views.Output.Campanha;
using Services.Domain.Views.Output.Cliente;
using Services.Domain.Views.Output.Empresa;
using Services.Domain.Views.Output.Operador; 
using Services.Domain.Views.Output.Telefone; 

using AutoMapper;

namespace Services.Domain.Mapping
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {

            #region Usuarios

            CreateMap<Usuarios, UsuariosOutput>()
                .ForMember(f => f.idUsuario, t => t.MapFrom(m => m.idUsuario))
                .ForMember(f => f.idCliente, t => t.MapFrom(m => m.idCliente))

                .ForMember(f => f.UsuarioNome, t => t.MapFrom(m => m.UsuarioNome))
                .ForMember(f => f.UsuarioSobrenome, t => t.MapFrom(m => m.UsuarioSobrenome))
                .ForMember(f => f.UsuarioEmail, t => t.MapFrom(m => m.UsuarioEmail))
                .ForMember(f => f.UsuarioSenha, t => t.MapFrom(m => m.UsuarioSenha))
                .ForMember(f => f.UsuarioAvatar, t => t.MapFrom(m => m.UsuarioAvatar))
                .ForMember(f => f.Ativo, t => t.MapFrom(m => m.Ativo))
                ;

            #endregion

            #region Campanhas

            CreateMap<Campanhas, CampanhasOutput>()
                .ForMember(f => f.idCampanha, t => t.MapFrom(m => m.idCampanha))
                .ForMember(f => f.idEmpresa, t => t.MapFrom(m => m.idEmpresa))

                .ForMember(f => f.CampanhaNome, t => t.MapFrom(m => m.CampanhaNome))
                .ForMember(f => f.DataSolicitacao, t => t.MapFrom(m => m.DataSolicitacao))
                .ForMember(f => f.DataEntregaDiscador, t => t.MapFrom(m => m.DataEntregaDiscador))
                ;

            CreateMap<RegrasDiscagem, RegrasDiscagemOutput>()
                .ForMember(f => f.idRegra, t => t.MapFrom(m => m.idRegra))
                .ForMember(f => f.idStatus, t => t.MapFrom(m => m.idStatus))

                .ForMember(f => f.QuantidadeTentativas, t => t.MapFrom(m => m.QuantidadeTentativas))
                .ForMember(f => f.IntervaloMinutos, t => t.MapFrom(m => m.IntervaloMinutos))
                ;

            CreateMap<StatusDiscagem, StatusDiscagemOutput>()
                .ForMember(f => f.idStatus, t => t.MapFrom(m => m.idStatus))
                .ForMember(f => f.NomeStatus, t => t.MapFrom(m => m.NomeStatus))
                ;

            #endregion

            #region Clientes

                CreateMap<Clientes, ClientesOutput>()
                    .ForMember(f => f.idCliente, t => t.MapFrom(m => m.idCliente))

                    .ForMember(f => f.ClienteNome, t => t.MapFrom(m => m.ClienteNome))
                    .ForMember(f => f.ClienteCpf, t => t.MapFrom(m => m.ClienteCpf))
                    .ForMember(f => f.ClienteEmail, t => t.MapFrom(m => m.ClienteEmail))
                    ;

            #endregion

            #region Empresa

                CreateMap<Empresas, EmpresasOutput>()
                    .ForMember(f => f.idEmpresa, t => t.MapFrom(m => m.idEmpresa))
                    .ForMember(f => f.EmpresaNome, t => t.MapFrom(m => m.EmpresaNome))
                    ;

                CreateMap<EmpresaOperador, EmpresaOperadorOutput>()
                    .ForMember(f => f.idOperador, t => t.MapFrom(m => m.idOperador))
                    .ForMember(f => f.idEmpresa, t => t.MapFrom(m => m.idEmpresa))
                    ;

            #endregion

            #region Operador

                CreateMap<Operadores, OperadoresOutput>()
                    .ForMember(f => f.idOperador, t => t.MapFrom(m => m.idOperador))
                    .ForMember(f => f.idStatus, t => t.MapFrom(m => m.idStatus))

                    .ForMember(f => f.OperadorNome, t => t.MapFrom(m => m.OperadorNome))
                    .ForMember(f => f.Ramal, t => t.MapFrom(m => m.Ramal)) 
                    ;

            #endregion 

            #region Telefone

                CreateMap<TiposTelefones, TiposTelefonesOutput>()
                    .ForMember(f => f.idTipo, t => t.MapFrom(m => m.idTipo))
                    .ForMember(f => f.Nome, t => t.MapFrom(m => m.Nome)) 
                    ;

            #endregion
                        
        }
    }
}
