using System.Security.Claims;
using GraduatesPortalAPI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UsersAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class GraduateController : Controller
{
    [HttpGet("Busqueda")]
    public IResult Busqueda(String valor, int limit,int offset){

        PortalEgresadosContext? context = null;

        try
        {
            context = new PortalEgresadosContext();

            var busqueda = context
                .Egresados
                .Where(b => EF.Functions.Like(b.PrimerNombre, $"%{valor}%") || EF.Functions.Like (b.PrimerApellido, $"%{valor}%" ))
                .OrderBy(b => b.PrimerNombre)
                .Skip(offset * limit)
                .Take(limit)
                .ToList();

            var Egresado = new List<Egresado>();

            if (Egresado.Any()){

                
                return null;
            }

            foreach (var item in busqueda){

                var EgresadoId = item.EgresadoId;
                var PrimerNombre = item.PrimerNombre;
                var SegundoNombre = item.SegundoNombre;
                var PrimerApellido = item.PrimerApellido;
                var SegundoApellido = item.SegundoApellido;
                var DocumentoEgresados = item.Participante.Documentos;
                var Genero = item.Genero;
                var FechaNac = item.FechaNac;
                var FotoPerfilUrl = item.Participante.FotoPerfilUrl;
                var Nacionalidad = item.NacionalidadNavigation.Nombre;
                var EgresadoIdioma = item.EgresadoIdiomas;
                var ExperienciaLaboral = item.ExperienciaLaborals;
                var Educacion = item.Educacions;
                var Contacto = item.Participante.Contactos;
                var EgresadoHabilidad = item.EgresadoHabilidads;


                dynamic Egresados = new
                {
                    EgresadoId = EgresadoId,
                    PrimerNombre = PrimerNombre,
                    SegundoNombre = SegundoNombre,
                    PrimerApellido = PrimerApellido,
                    SegundoApellido = SegundoApellido,
                    DocumentoEgresados = DocumentoEgresados,
                    Genero = Genero,
                    FechaNac = FechaNac,
                    FotoPerfilUrl = FotoPerfilUrl,
                    Nacionalidad = Nacionalidad,
                    EgresadoIdiomas = EgresadoIdioma,
                    ExperienciaLaborals = ExperienciaLaboral,
                    Educacions = Educacion,
                    Contacto = Contacto,
                    EgresadoHabilidads = EgresadoHabilidad
                };

                Egresado.Add(Egresados);
            }

            return Results.Json(
                data: Egresado,
                statusCode: StatusCodes.Status200OK
            );
        }
        
                catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);

            return Results.Json(
                data: new ErrorResult(0, "Unexpected server error"),
                statusCode: StatusCodes.Status500InternalServerError
            );
        }
    }

    [HttpGet("BusquedaId")]
    public IResult BusquedaId(int IdEgresado){

        PortalEgresadosContext? context = null;

        try
        {
            context = new PortalEgresadosContext();

            var busqueda = context
                .Egresados
                .Where(b => b.EgresadoId == IdEgresado)
                .OrderBy(b => b.PrimerNombre)
                .ToList();

            var Egresado = new List<Egresado>();



            foreach (var item in busqueda){

                var EgresadoId = item.EgresadoId;
                var PrimerNombre = item.PrimerNombre;
                var SegundoNombre = item.SegundoNombre;
                var PrimerApellido = item.PrimerApellido;
                var SegundoApellido = item.SegundoApellido;
                var DocumentoEgresados = item.Participante.Documentos;
                var Genero = item.Genero;
                var FechaNac = item.FechaNac;
                var FotoPerfilUrl = item.Participante.FotoPerfilUrl;
                var Nacionalidad = item.NacionalidadNavigation.Nombre;
                var EgresadoIdioma = item.EgresadoIdiomas;
                var ExperienciaLaboral = item.ExperienciaLaborals;
                var Educacion = item.Educacions;
                var Contacto = item.Participante.Contactos;
                var EgresadoHabilidad = item.EgresadoHabilidads;


                dynamic Egresados = new
                {
                    EgresadoId = EgresadoId,
                    PrimerNombre = PrimerNombre,
                    SegundoNombre = SegundoNombre,
                    PrimerApellido = PrimerApellido,
                    SegundoApellido = SegundoApellido,
                    DocumentoEgresados = DocumentoEgresados,
                    Genero = Genero,
                    FechaNac = FechaNac,
                    FotoPerfilUrl = FotoPerfilUrl,
                    Nacionalidad = Nacionalidad,
                    EgresadoIdiomas = EgresadoIdioma,
                    ExperienciaLaborals = ExperienciaLaboral,
                    Educacions = Educacion,
                    Contacto = Contacto,
                    EgresadoHabilidads = EgresadoHabilidad
                };

                Egresado.Add(Egresados);
            }

            return Results.Json(
                data: Egresado,
                statusCode: StatusCodes.Status200OK
            );
        }
        
                catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);

            return Results.Json(
                data: new ErrorResult(0, "Unexpected server error"),
                statusCode: StatusCodes.Status500InternalServerError
            );
        }
    }

    [HttpGet("EgresadoIdioma")]
    public IResult EgresadoIdioma(int IdEgresado){

        PortalEgresadosContext? context = null;

        try
        {
            context = new PortalEgresadosContext();

            var getidiomas = context
            .Egresados
            .Where(e => e.EgresadoId == IdEgresado)
            .SelectMany(e => e.EgresadoIdiomas)
            .Select(ei => ei.Idioma)
            .ToList();

            var idiomas = new List<Idioma>();

            foreach (var item in getidiomas){

                var idiomaId = item.IdiomaId;
                var Egreidioma = item.Nombre;

                var idioma = new Idioma
                {
                    IdiomaId = idiomaId,
                    Nombre = Egreidioma

                };

                idiomas.Add(idioma);
        
            }

            return Results.Json(
                data: idiomas,
                statusCode: StatusCodes.Status200OK
            );

        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);

            return Results.Json(
                data: new ErrorResult(0, "Unexpected server error"),
                statusCode: StatusCodes.Status500InternalServerError
            );

        }

    }

    [HttpPost("EgresadoIdioma")]
    public IResult PostEgresadoIdioma(int IdEgresado){

        PortalEgresadosContext? context = null;

        try
        {
            context = new PortalEgresadosContext();

            var getidiomas = context
            .Egresados
            .Where(e => e.EgresadoId == IdEgresado)
            .SelectMany(e => e.EgresadoIdiomas)
            .Select(ei => ei.Idioma)
            .ToList();

            var idiomas = new List<Idioma>();

            foreach (var item in getidiomas){

                var idiomaId = item.IdiomaId;
                var Egreidioma = item.Nombre;

                var idioma = new Idioma
                {
                    IdiomaId = idiomaId,
                    Nombre = Egreidioma

                };

                idiomas.Add(idioma);
        
            }

            return Results.Json(
                data: idiomas,
                statusCode: StatusCodes.Status200OK
            );

        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);

            return Results.Json(
                data: new ErrorResult(0, "Unexpected server error"),
                statusCode: StatusCodes.Status500InternalServerError
            );

        }

    }

    [HttpGet("Count")]
    public IResult Count()
    {
        var connection = Database.GetConnection();

        try
        {
            var graduateDAO = new GraduateDAO(connection);

            return Results.Json(
                data: graduateDAO.Count(),
                statusCode: StatusCodes.Status200OK
            );
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);

            return Results.Json(
                data: new ErrorResult(0, "Unexpected server error"),
                statusCode: StatusCodes.Status500InternalServerError
            );
        }
        finally
        {
            connection?.Close();
        }
    }

    [HttpGet("Paging/{offset}/{fetch}")]
    public IResult Paging(int offset, int fetch)
    {
        var connection = Database.GetConnection();

        try
        {
            var graduateDAO = new GraduateDAO(connection);
            var nationalityDAO = new NationalityDAO(connection);

            var graduates = graduateDAO.PagingMinimum(offset, fetch);

            foreach (var graduate in graduates)
            {
                var nationality = nationalityDAO.GetNationality(graduate.id);

                if (nationality == null)
                {
                    return Results.Json(
                        data: new ErrorResult(0, "Failed to retrieve graduate nationality"),
                        statusCode: StatusCodes.Status500InternalServerError
                    );
                }

                graduate.Nacionalidad = nationality;
            }

            return Results.Json(
                data: graduates,
                statusCode: StatusCodes.Status200OK
            );
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);

            return Results.Json(
                data: new ErrorResult(0, "Unexpected server error"),
                statusCode: StatusCodes.Status500InternalServerError
            );
        }
        finally
        {
            connection?.Close();
        }
    }

    [HttpGet("{graduateId}"), Authorize]
    public IResult GetById(int graduateId)
    {
        if (HttpContext.User.Identity is not ClaimsIdentity identity)
        {
            return Results.Json(
                data: new ErrorResult(0, "Unexpected server error"),
                statusCode: StatusCodes.Status500InternalServerError
            );
        }

        var connection = Database.GetConnection();

        try
        {
            var userDAO = new UserDAO(connection);
            var graduateDAO = new GraduateDAO(connection);
            var nationalityDAO = new NationalityDAO(connection);
            var graduateContactDAO = new GraduateContactDAO(connection);

            Claim? nameClaim = identity.FindFirst("name");

            if (nameClaim == null)
            {
                return Results.Json(
                    data: new ErrorResult(0, "Unexpected server error"),
                    statusCode: StatusCodes.Status500InternalServerError
                );
            }

            int? retrievedGraduateId = graduateDAO.GetGraduateIdByUsername(nameClaim.Value);

            if (graduateId != retrievedGraduateId)
            {
                return Results.Json(
                    data: new ErrorResult(0, "You don't have access to the specified graduate"),
                    statusCode: StatusCodes.Status401Unauthorized
                );
            }

            if (!graduateDAO.Exists(graduateId))
            {
                return Results.Json(
                    data: new ErrorResult(0, "Doesn't exists graduate with the submitted id"),
                    statusCode: StatusCodes.Status400BadRequest
                );
            }

            var graduate = graduateDAO.Get(graduateId);

            if (graduate == null)
            {
                return Results.Json(
                    data: new ErrorResult(0, "Unexpected error"),
                    statusCode: StatusCodes.Status500InternalServerError
                );
            }

            var user = userDAO.Get(graduate.id);

            if (user == null)
            {
                return Results.Json(
                    data: new ErrorResult(0, "Unexpected error"),
                    statusCode: StatusCodes.Status500InternalServerError
                );
            }

            var nationality = nationalityDAO.GetNationality(graduate.id);

            if (nationality == null)
            {
                return Results.Json(
                    data: new ErrorResult(0, "Unexpected error"),
                    statusCode: StatusCodes.Status500InternalServerError
                );
            }

            graduate.user = user;
            graduate.Nacionalidad = nationality;
            graduate.emails = graduateContactDAO.GetEmails(graduate.id);
            graduate.addresses = graduateContactDAO.GetAddresses(graduate.id);
            graduate.telephones = graduateContactDAO.GetTelephones(graduate.id);

            return Results.Json(
                data: graduate,
                statusCode: StatusCodes.Status200OK
            );
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);

            return Results.Json(
                data: new ErrorResult(0, "Unexpected server error"),
                statusCode: StatusCodes.Status500InternalServerError
            );
        }
        finally
        {
            connection?.Close();
        }
    }

    [HttpGet]
    public IResult GetAll()
    {
        var connection = Database.GetConnection();

        try
        {
            var graduateDAO = new GraduateDAO(connection);
            var nationalityDAO = new NationalityDAO(connection);

            var graduates = graduateDAO.GetAllMinimum();

            foreach (var graduate in graduates)
            {
                var nationality = nationalityDAO.GetNationality(graduate.id);

                if (nationality == null)
                {
                    return Results.Json(
                        data: new ErrorResult(0, "Failed to retrieve graduate nationality"),
                        statusCode: StatusCodes.Status500InternalServerError
                    );
                }

                graduate.Nacionalidad = nationality;
            }

            return Results.Json(
                data: graduates,
                statusCode: StatusCodes.Status200OK
            );
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);

            return Results.Json(
                data: new ErrorResult(0, "Unexpected server error"),
                statusCode: StatusCodes.Status500InternalServerError
            );
        }
        finally
        {
            connection?.Close();
        }
    }

    [HttpGet("Telephones")]
    public IResult GetTelephones(int graduate_id)
    {
        var connection = Database.GetConnection();

        try
        {
            var GraduateContactDAO = new GraduateContactDAO(connection);
            return Results.Ok(GraduateContactDAO.GetTelephones(graduate_id));
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);

            return Results.Json(
                data: new ErrorResult(0, "Unexpected server error"),
                statusCode: StatusCodes.Status500InternalServerError
            );
        }
        finally
        {
            connection?.Close();
        }
    }

    [HttpGet("Emails")]
    public IResult GetEmails(int graduate_id)
    {
        var connection = Database.GetConnection();
        try
        {
            var GraduateContactDAO = new GraduateContactDAO(connection);
            return Results.Ok(GraduateContactDAO.GetEmails(graduate_id));
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);

            return Results.Json(
                data: new ErrorResult(0, "Unexpected server error"),
                statusCode: StatusCodes.Status500InternalServerError
            );
        }
        finally
        {
            connection?.Close();
        }
    }

    [HttpGet("Addresses")]
    public IResult GetAddresses(int graduate_id)
    {
        var connection = Database.GetConnection();

        try
        {
            var GraduateContactDAO = new GraduateContactDAO(connection);
            return Results.Ok(GraduateContactDAO.GetAddresses(graduate_id));
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);

            return Results.Json(
                data: new ErrorResult(0, "Unexpected server error"),
                statusCode: StatusCodes.Status500InternalServerError
            );
        }
        finally
        {
            connection?.Close();
        }
    }

    [HttpPost]
    public IResult Create(Graduate graduate)
    {
        var connection = Database.GetConnection();
        var transaction = connection.BeginTransaction();

        try
        {
            var userDAO = new UserDAO(connection);
            var graduateDAO = new GraduateDAO(connection);
            var GraduateContactDAO = new GraduateContactDAO(connection);

            if (graduateDAO.ExistsIdentification(graduate.Identificacion))
            {
                transaction.Rollback();
                return Results.BadRequest(new ErrorResult(0, "Existe otro egresado con la misma identificación."));
            }

            if (userDAO.Exists(graduate.user.name))
            {
                transaction.Rollback();
                return Results.BadRequest(new ErrorResult(0, "Username already in use"));
            }

            var graduateId = graduateDAO.Create(graduate);
            var userId = userDAO.Create(graduate.user);

            graduateDAO.JoinToUser(graduateId, userId);

            foreach (string address in graduate.addresses)
            {
                GraduateContactDAO.CreateAddress(graduateId, address);
            }

            foreach (string email in graduate.emails)
            {
                if (GraduateContactDAO.ExistsEmail(email))
                {
                    transaction.Rollback();
                    return Results.BadRequest(new ErrorResult(0, $"The email '{email}' is already in use"));
                }

                GraduateContactDAO.CreateEmail(graduateId, email);
            }

           /* foreach (string telephone in graduate.telephones)
            {
                if (GraduateContactDAO.ExistsTelephone(telephone))
                {
                    transaction.Rollback();
                    return Results.BadRequest(new ErrorResult(0, $"The telephone '{telephone}' is already in use"));
                }

                GraduateContactDAO.CreateTelephone(graduateId, telephone);
            }*/

            transaction.Commit();

            return Results.Ok(graduateId);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);

            transaction.Rollback();

            return Results.Json(
                data: new ErrorResult(0, "Unexpected server error"),
                statusCode: StatusCodes.Status500InternalServerError
            );
        }
        finally
        {
            transaction?.Dispose();
            connection?.Close();
        }
    }

    [Authorize]
    [HttpPut]
    public IResult Update(GraduateMinimum graduate)
    {
        var connection = Database.GetConnection();

        try
        {
            var graduateDAO = new GraduateDAO(connection);

            //Checking if the information in the token is the correct to perform
            //the requested action

            if (HttpContext.User.Identity is not ClaimsIdentity identity)
            {
                Console.Error.WriteLine("Failed to get the claims");

                return Results.Json(
                    data: new ErrorResult(0, "Unexpected server error"),
                    statusCode: StatusCodes.Status500InternalServerError
                );
            }

            Claim? nameClaim = identity.FindFirst("name");

            if (nameClaim == null)
            {
                Console.Error.WriteLine("Failed to get the name claim");

                return Results.Json(
                    data: new ErrorResult(0, "Unexpected server error"),
                    statusCode: StatusCodes.Status500InternalServerError
                );
            }

            int? retrievedGraduateId = graduateDAO.GetGraduateIdByUsername(nameClaim.Value);

            //Only if the graduate's id requested from the token and the graduate's id
            //from the request (argument in the function) match, the operation can be carry out

            if (graduate.id != retrievedGraduateId)
            {
                return Results.Json(
                    data: new ErrorResult(0, "You don't have access to perform the requested action"),
                    statusCode: StatusCodes.Status401Unauthorized
                );
            }

            if (!graduateDAO.Exists(graduate.id))
            {
                return Results.BadRequest(new ErrorResult(0, $"Doesn't exists a graduate with submitted id"));
            }

            return Results.Json(
                data: graduateDAO.Update(graduate),
                statusCode: StatusCodes.Status200OK
            );
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);

            return Results.Json(
                data: new ErrorResult(0, "Unexpected server error"),
                statusCode: StatusCodes.Status500InternalServerError
            );
        }
        finally
        {
            connection?.Close();
        }
    }

    [Authorize]
    [HttpDelete("{graduateId}")]
    public IResult Delete(int graduateId)
    {
        var connection = Database.GetConnection();
        var transaction = connection.BeginTransaction();

        try
        {
            var userDAO = new UserDAO(connection);
            var graduateDAO = new GraduateDAO(connection);
            var contactDAO = new GraduateContactDAO(connection);

            //Checking if the information in the token is the correct to perform
            //the requested action

            if (HttpContext.User.Identity is not ClaimsIdentity identity)
            {
                Console.Error.WriteLine("Failed to get the claims");

                return Results.Json(
                    data: new ErrorResult(0, "Unexpected server error"),
                    statusCode: StatusCodes.Status500InternalServerError
                );
            }

            Claim? nameClaim = identity.FindFirst("name");

            if (nameClaim == null)
            {
                Console.Error.WriteLine("Failed to get the name claim");

                return Results.Json(
                    data: new ErrorResult(0, "Unexpected server error"),
                    statusCode: StatusCodes.Status500InternalServerError
                );
            }

            int? retrievedGraduateId = graduateDAO.GetGraduateIdByUsername(nameClaim.Value);

            //Only if the graduate's id requested from the token and the graduate's id
            //from the request (argument in the function) match, the operation can be carry out

            if (graduateId != retrievedGraduateId)
            {
                return Results.Json(
                    data: new ErrorResult(0, "You don't have access to perform the requested action"),
                    statusCode: StatusCodes.Status401Unauthorized
                );
            }

            //Performing graduate deletion

            if (!graduateDAO.Exists(graduateId))
            {
                transaction.Rollback();

                return Results.Json(
                    data: new ErrorResult(0, "Doesn't exists a graduate with the submitted id"),
                    statusCode: StatusCodes.Status400BadRequest
                );
            }

            //Deleting graduate's contact information

            if (contactDAO.CountAddresses(graduateId) > 0 && !contactDAO.DeleteAddresses(graduateId))
            {
                Console.Error.WriteLine("Failed to delete graduate addresses");

                transaction.Rollback();

                return Results.Json(
                    data: new ErrorResult(0, "Unexpected server error"),
                    statusCode: StatusCodes.Status500InternalServerError
                );
            }

            if (contactDAO.CountEmails(graduateId) > 0 && !contactDAO.DeleteEmails(graduateId))
            {
                Console.Error.WriteLine("Failed to delete graduate emails");

                transaction.Rollback();

                return Results.Json(
                    data: new ErrorResult(0, "Unexpected server error"),
                    statusCode: StatusCodes.Status500InternalServerError
                );
            }

            if (contactDAO.CountTelephones(graduateId) > 0 && !contactDAO.DeleteTelephones(graduateId))
            {
                Console.Error.WriteLine("Failed to delete graduate telephones");

                transaction.Rollback();

                return Results.Json(
                    data: new ErrorResult(0, "Unexpected server error"),
                    statusCode: StatusCodes.Status500InternalServerError
                );
            }

            //Deleting graduate's user information

            User? user = userDAO.Get(graduateId);

            if (user == null)
            {
                Console.Error.WriteLine("Failed to retrieve graduate's user");

                transaction.Rollback();

                return Results.Json(
                    data: new ErrorResult(0, "Unexpected server error"),
                    statusCode: StatusCodes.Status500InternalServerError
                );
            }

            if (!userDAO.UnjoinGraduate(graduateId))
            {
                Console.Error.WriteLine("Failed to unjoin graduate from the user");

                transaction.Rollback();

                return Results.Json(
                    data: new ErrorResult(0, "Unexpected server error"),
                    statusCode: StatusCodes.Status500InternalServerError
                );
            }

            if (!userDAO.Delete(user.id))
            {
                Console.Error.WriteLine("Failed to delete the graduate's user");

                transaction.Rollback();

                return Results.Json(
                    data: new ErrorResult(0, "Unexpected server error"),
                    statusCode: StatusCodes.Status500InternalServerError
                );
            }

            if (!graduateDAO.Delete(graduateId))
            {
                Console.Error.WriteLine("Failed to delete graduate");

                transaction.Rollback();

                return Results.Json(
                    data: new ErrorResult(0, "Unexpected server error"),
                    statusCode: StatusCodes.Status500InternalServerError
                );
            }

            transaction.Commit();

            return Results.Json(
                data: true,
                statusCode: StatusCodes.Status200OK
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());

            transaction.Rollback();

            return Results.Json(
                data: new ErrorResult(0, "Unexpected server error"),
                statusCode: StatusCodes.Status500InternalServerError
            );
        }
        finally
        {
            transaction.Dispose();
            connection?.Close();
        }
    }
}