using Mozo.ApiSeguridad.Helper;
using Mozo.Model.Seguridad;
using Mozo.SeguridadBusiness;

namespace Mozo.Api.Seguridad;

///<summary>
/// Endpoints para gestión de EmpresaModulo
///</summary>
///<history>
/// Create by Jonatan Abregu
///</history>
public static partial class EmpresaModuloEndPoints
{
    /// <summary>
    /// Mapea todas las rutas de EmpresaModulo
    /// </summary>
    public static RouteGroupBuilder MapEmpresaModulo(this RouteGroupBuilder g)
    {
        g.WithSecurity();

        g.MapPost("/", InsertAsync)
             .WithResponsesValue<int>(StatusCodes.Status200OK)
             .WithDescription("Insertar una EmpresaModulo");

        g.MapPut("/", UpdateAsync)
             .WithResponsesValue<int>(StatusCodes.Status200OK)
             .WithDescription("Actualizar una EmpresaModulo");

        g.MapDelete("/byid", DeleteByIdAsync)
          .WithResponses(StatusCodes.Status204NoContent)
          .WithDescription("Eliminar una EmpresaModulo");

        g.MapGet("/byid", SelByIdAsync)
         .WithResponses<EmpresaModuloModel>(StatusCodes.Status200OK)
         .Produces(StatusCodes.Status404NotFound)
         .WithDescription("Obtener una EmpresaModulo");

        g.MapGet("/", SelAllAsync)
          .WithResponses<IEnumerable<EmpresaModuloModel>>(StatusCodes.Status200OK)
          .Produces(StatusCodes.Status404NotFound)
          .WithDescription("Obtener una EmpresaModulo");

        g.MapGet("/", SelAllAsync)
          .WithResponses<IEnumerable<EmpresaModuloModel>>(StatusCodes.Status200OK)
          .Produces(StatusCodes.Status404NotFound)
          .WithDescription("Obtener una EmpresaModulo");

        return g;
    }

}

public static partial class EmpresaModuloEndPoints
{
    private static async Task<IResult>
        InsertAsync(
            EmpresaModuloModel m,
            IEmpresaModuloBusiness IEmpresaModulo
         )
    {

        m.CoEmpresaModulo = await IEmpresaModulo.InsertAsync(m);
        return Results.Created($"/{m.CoEmpresaModulo}", m.CoEmpresaModulo);
    }

    private static async Task<IResult>
        UpdateAsync(
            EmpresaModuloModel c,
            IEmpresaModuloBusiness IEmpresaModulo
        )
    {
        await IEmpresaModulo.UpdateAsync(c);
        return Results.Ok(c.CoEmpresaModulo);
    }


    private static async Task<IResult>
         DeleteByIdAsync(
             [AsParameters] EmpresaModuloFilterDto f,
               IEmpresaModuloBusiness IEmpresaModulo
      )
    {
        await IEmpresaModulo.DeleteByIdAsync(f);
        return Results.NoContent();
    }


    private static async Task<IResult>
         SelByIdAsync(
             [AsParameters] EmpresaModuloFilterDto f,
           IEmpresaModuloBusiness IEmpresaModulo
        )
    {
        EmpresaModuloModel? i = await IEmpresaModulo.SelByIdAsync(f);
        if (i is null)
            return Results.NotFound();
        return Results.Ok(i);
    }

    static async Task<IResult>
        SelAllAsync(
                [AsParameters] EmpresaModuloFilterDto f,
            IModuloBusiness IModulo,
            IEmpresaModuloBusiness IEmpresaModulo
    )
    {

        List<ModuloModel> moduloLst = (await IModulo.SelAllActiveAsync()).ToList();

        List<EmpresaModuloModel> empresaModuloLst  = (await IEmpresaModulo.SelAllAsync(f)).ToList();
        //return Results.Ok(r);
        foreach (ModuloModel item in moduloLst)
        {
            EmpresaModuloModel? EmpresaModulo = empresaModuloLst.Find(x => x.CoModulo == item.CoModulo);
            if (EmpresaModulo != null)
                item.FlEstReg = 1;
            else
                item.FlEstReg = 0;
        }

        //foreach (ModuloModel item in moduloLst) item.CoEmpresa = f.CoEmpresa;
        return Results.Ok(moduloLst);

        //var ModuloCol = _moduloService.GetAllActivo().ToList();
        //var EmpresaModuloCol = _empresaModuloService.GetAll(c).ToList();
        //foreach (var Item in ModuloCol)
        //{
        //    var EmpresaModulo = EmpresaModuloCol.Find(x => x.CoModulo == Item.CoModulo);
        //    if (EmpresaModulo != null)
        //    {
        //        Item.CoEstReg = 1;
        //        Item.FlOnlyTypeMasterTable = EmpresaModulo.FlOnlyTypeMasterTable;
        //    }
        //    else
        //    {
        //        Item.CoEstReg = 0;
        //        Item.FlOnlyTypeMasterTable = 0;
        //    }
        //}

        //foreach (var Item in ModuloCol) Item.CoEmpresa = c.CoEmpresa;
        //return Results.Ok(ModuloCol);
    }



    static async Task<IResult>
       SelAllAsync(
               [AsParameters] EmpresaModuloFilterDto f,        
           IEmpresaModuloBusiness IEmpresaModulo
   )
    {

        var r = await IEmpresaModulo.SelAllAsync(f);
        r = r.OrderBy(x => x.NoModuloDescripcion);
        return Results.Ok(r);
        
    }



}