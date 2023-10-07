using Microsoft.AspNetCore.Mvc;

namespace UsersAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class NationalityController : Controller
{
    [HttpGet]
    public IResult GetAll()
    {
        var connection = Database.GetConnection();

        try
        {
            var nationalityDAO = new NationalityDAO(connection);
            return Results.Ok(nationalityDAO.GetAll());
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
}