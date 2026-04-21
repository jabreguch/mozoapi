using Mozo.Helper.Enu;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Mozo.Model.Seguridad;

public record PaginaFilterDto : BaseFilterDto {
    public int? CoModulo { get; set; }
    public int? CoTipoPagina { get; set; }
    public int? CoPersona { get; set; }
    public int? CoPagina { get; set; }
    

}

[Serializable]
public partial class PaginaModel : BaseModel //<PaginaModel>
{
    public int? CoModulo { get; set; }
    public int? CoTipoPagina { get; set; }
    public int? CoPagina { get; set; }
    public string? TxDescripcion { get; set; }
    public int? CoMenu { get; set; }
    public int? CoPaginaPadre { get; set; }
    public int? CoArea { get; set; }
  public string? NoControlador { get; set; }
     public string? NoAccion { get; set; }
    public string? NoOpcion { get; set; }
     public int? NuOrden { get; set; }
    public string? NoParametro { get; set; }
}
public partial class PaginaModel
{
    [JsonIgnore]
    public string? NoPathPage
    {
        get
        {
            if (NoControlador != null)
                return string.Concat(NoArea, "/", NoControlador, "/", NoAccion);
            else return string.Empty;
        }
    }

    [JsonIgnore]
    public string? Icono
    {
        get => "bi bi-arrow-right-circle";
    }

    //public string? Icono()
    //{
    //    return "bi bi-arrow-right-circle";
    //    //coTipoPagina = coTipoPagina ?? CoTipoPagina;


    //    //if (CoTipoPagina == EnuSeguridad.TipoPagina.Menu)
    //    //    return "bi bi-menu-app";
    //    //else if (CoTipoPagina == EnuSeguridad.TipoPagina.Pagina)
    //    //    return "bi bi-arrow-right-circle";
    //    //else if (CoTipoPagina == EnuSeguridad.TipoPagina.SubPagina)
    //    //    return "bi bi-caret-right";
    //    //else if (CoTipoPagina == EnuSeguridad.TipoPagina.PaginaFlotante)
    //    //    return "bi bi-window";
    //    //else if (CoTipoPagina == EnuSeguridad.TipoPagina.ServicioWeb)
    //    //    return "bi bi-cloud";

    //    //return "";

    //}

    //

    public int? CoPersona { get; set; }
    public string? NoArea { get; set; }
    public List<SubPaginaModel>? SubPaginaLst { get; set; }
    public List<PaginaFlotanteModel>? PaginaFlotanteLst { get; set; }
    public List<ServicioWebModel>? ServicioWebLst { get; set; }
    public int? CoPerfil { get; set; }
    public string? NoModuloDescripcion { get; set; }
    public string? NoMenu { get; set; }
}