using Mozo.Model.Seguridad;
using Mozo.SeguridadData;

namespace Mozo.SeguridadBusiness;

public interface IPaginaBusiness
{
    Task<int> InsertAsync(PaginaModel c);
    Task UpdateAsync(PaginaModel c);
    Task UpdateStateAsync(PaginaModel c);
    Task DeleteByIdAsync(PaginaFilterDto c);
    Task<PaginaModel?> SelByIdAsync(PaginaFilterDto c);
    Task<IEnumerable<PaginaModel>> SelAllPaginaAsync(PaginaFilterDto c);
    Task<IEnumerable<SubPaginaModel>> SelAllSubPaginaAsync(SubPaginaFilterDto c);
    Task<IEnumerable<PaginaFlotanteModel>> SelAllPaginaFlotanteAsync(PaginaFlotanteFilterDto c);
    Task<IEnumerable<ServicioWebModel>> SelAllServicioWebAsync(ServicioWebFilterDto c);
    Task<IEnumerable<PaginaModel>> SelAllActivePaginaAsync(PaginaFilterDto c);
    Task<IEnumerable<SubPaginaModel>> SelAllActiveSubPaginaAsync(SubPaginaFilterDto c);
    Task<IEnumerable<PaginaFlotanteModel>> SelAllActivePaginaFlotanteAsync(PaginaFlotanteFilterDto c);
    Task<IEnumerable<ServicioWebModel>> SelAllActiveServicioWebAsync(ServicioWebFilterDto c);
}
public class PaginaBusiness : IPaginaBusiness
{
    private readonly IPaginaData _data;
    public PaginaBusiness(IPaginaData data)
    {
        _data = data;
    }
    public async Task<int> InsertAsync(PaginaModel c) => await _data.InsertAsync(c);
    public async Task UpdateAsync(PaginaModel c) => await _data.UpdateAsync(c);
    public async Task UpdateStateAsync(PaginaModel c) => await _data.UpdateStateAsync(c);
    public async Task DeleteByIdAsync(PaginaFilterDto c) => await _data.DeleteByIdAsync(c);
    public async Task<PaginaModel?> SelByIdAsync(PaginaFilterDto c) => await _data.SelByIdAsync(c);
    public async Task<IEnumerable<PaginaModel>> SelAllPaginaAsync(PaginaFilterDto c) => await _data.SelAllPaginaAsync(c);
    public async Task<IEnumerable<PaginaFlotanteModel>> SelAllPaginaFlotanteAsync(PaginaFlotanteFilterDto c) => await _data.SelAllPaginaFlotanteAsync(c);
    public async Task<IEnumerable<SubPaginaModel>> SelAllSubPaginaAsync(SubPaginaFilterDto c) => await _data.SelAllSubPaginaAsync(c);
    public async Task<IEnumerable<ServicioWebModel>> SelAllServicioWebAsync(ServicioWebFilterDto c) => await _data.SelAllServicioWebAsync(c);
    public async Task<IEnumerable<PaginaModel>> SelAllActivePaginaAsync(PaginaFilterDto c) => await _data.SelAllActivePaginaAsync(c);
    public async Task<IEnumerable<PaginaFlotanteModel>> SelAllActivePaginaFlotanteAsync(PaginaFlotanteFilterDto c) => await _data.SelAllActivePaginaFlotanteAsync(c);    
    public async Task<IEnumerable<SubPaginaModel>> SelAllActiveSubPaginaAsync(SubPaginaFilterDto c) => await _data.SelAllActiveSubPaginaAsync(c);
    public async Task<IEnumerable<ServicioWebModel>> SelAllActiveServicioWebAsync(ServicioWebFilterDto c) => await _data.SelAllActiveServicioWebAsync(c);
  
}