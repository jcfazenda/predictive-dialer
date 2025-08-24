
using Services.Domain.Views.Output.Empresa;

namespace Services.Domain.Views.Output.Campanha
{
    public class CampanhasOutput
    {
        public long idCampanha { get; set; }
        public long idEmpresa { get; set; }

        public string? CampanhaNome { get; set; } 

        public EmpresasOutput? Empresa { get; set; }
    }
}
