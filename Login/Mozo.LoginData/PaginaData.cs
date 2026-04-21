using Dapper;

using Mozo.Helper.Enu;
using Mozo.Helper.Global;
using Mozo.Model.Seguridad;

using System.Data;

///<summary>
///
///</summary>
///<remarks>
///</remarks>
///<history>
/// t[Jonatan Abregu]	16/11/2018	Created
///</history>
namespace Mozo.LoginData;

public interface IPaginaData
{
    Task<IEnumerable<PaginaModel>> SelAllPaginaAsync(PaginaFilterDto c);
    Task<IEnumerable<SubPaginaModel>> SelAllSubPaginaAsync(SubPaginaFilterDto c);
    Task<IEnumerable<PaginaFlotanteModel>> SelAllPaginaFlotanteAsync(PaginaFlotanteFilterDto c);
    Task<IEnumerable<ServicioWebModel>> SelAllServicioWebAsync(ServicioWebFilterDto c);
}
public partial class PaginaData : IPaginaData
{
    private readonly string _schema = EnuCommon.BdDefault.Schema.Login;

    private readonly IDbConnection _connection;
    private readonly UserContext _user;
    public PaginaData(IDbConnection connection, UserContext user)
    {
        _connection = connection;
        _user = user;
    }
    public async Task<IEnumerable<PaginaModel>> SelAllPaginaAsync(PaginaFilterDto c)
    {
        c.CoTipoPagina = EnuTipoGeneral.Seguridad.Pagina.Paginaa;

        DynamicParameters pr = new();
        pr.Add2("CoEmpresa", _user.CoEmpresa, DbType.Int32);
        pr.Add2("CoModulo", c.CoModulo, DbType.Int32);
        pr.Add2("CoPersona", c.CoPersona, DbType.Int32);
        string sql = $"SELECT * FROM {_schema}.fn_pagina_sel_all(@CoEmpresa,@CoModulo,@CoPersona)";
        return await _connection.QueryAsync<PaginaModel>(sql, pr);
    }
    public async Task<IEnumerable<SubPaginaModel>> SelAllSubPaginaAsync(SubPaginaFilterDto c)
    {
        c.CoTipoPagina = EnuTipoGeneral.Seguridad.Pagina.SubPagina;
        DynamicParameters pr = new();
        pr.Add2("CoEmpresa", _user.CoEmpresa, DbType.Int32);
        pr.Add2("CoModulo", c.CoModulo, DbType.Int32);
        pr.Add2("CoPersona", c.CoPersona, DbType.Int32);
        string sql = $"SELECT * FROM {_schema}.fn_subpagina_sel_all(@CoEmpresa,@CoModulo,@CoPersona)";
        return await _connection.QueryAsync<SubPaginaModel>(sql, pr);
    }
    public async Task<IEnumerable<PaginaFlotanteModel>> SelAllPaginaFlotanteAsync(PaginaFlotanteFilterDto c)
    {
        c.CoTipoPagina = EnuTipoGeneral.Seguridad.Pagina.VistaFlotante;
        DynamicParameters pr = new();
        pr.Add2("CoEmpresa", _user.CoEmpresa, DbType.Int32);
        pr.Add2("CoModulo", c.CoModulo, DbType.Int32);
        pr.Add2("CoPersona", c.CoPersona, DbType.Int32);
        string sql = $"SELECT * FROM {_schema}.fn_paginaflotante_sel_all(@CoEmpresa,@CoModulo,@CoPersona)";
        return await _connection.QueryAsync<PaginaFlotanteModel>(sql, pr);
    }
    public async Task<IEnumerable<ServicioWebModel>> SelAllServicioWebAsync(ServicioWebFilterDto c)
    {
        c.CoTipoPagina = EnuTipoGeneral.Seguridad.Pagina.ServicioWeb;
        DynamicParameters pr = new();
        pr.Add2("CoEmpresa", _user.CoEmpresa, DbType.Int32);
        pr.Add2("CoModulo", c.CoModulo, DbType.Int32);
        pr.Add2("CoPersona", c.CoPersona, DbType.Int32);
        string sql = $"SELECT * FROM {_schema}.fn_servicioweb_sel_all(@CoEmpresa,@CoModulo,@CoPersona)";
        return await _connection.QueryAsync<ServicioWebModel>(sql, pr);
    }

}