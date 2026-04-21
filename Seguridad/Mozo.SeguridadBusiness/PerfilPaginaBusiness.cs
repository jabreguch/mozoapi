using Mozo.Model.Seguridad;
using Mozo.SeguridadData;

namespace Mozo.SeguridadBusiness;

public interface IPerfilPaginaBusiness
{
    Task<int> InsertAsync(PerfilPaginaModel c);
    Task DeleteByIdAsync(PerfilPaginaFilterDto c);
    Task<IEnumerable<PerfilPaginaModel>> SelAllAsync(PerfilPaginaFilterDto c);
}
public class PerfilPaginaBusiness : IPerfilPaginaBusiness
{
    private readonly IPerfilPaginaData _data;
    public PerfilPaginaBusiness(IPerfilPaginaData data)
    {
        _data = data;
    }

    public async Task<int> InsertAsync(PerfilPaginaModel c)
    {
        if (c.CoPaginaPadre == null) c.CoPaginaPadre = 0;
        return await _data.InsertAsync(c);
    }
    public async Task DeleteByIdAsync(PerfilPaginaFilterDto c) => await _data.DeleteByIdAsync(c);
    public async Task<IEnumerable<PerfilPaginaModel>> SelAllAsync(PerfilPaginaFilterDto c) => await _data.SelAllAsync(c);

}