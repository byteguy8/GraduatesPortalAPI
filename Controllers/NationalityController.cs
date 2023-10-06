using Microsoft.AspNetCore.Mvc;

namespace UsersAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class NationalityController: Controller
{
    [HttpGet]
    public IResult getAll()
    {
        var connection = Database.GetConnection();

        try
        {
            var nationalityDAO = new NationalityDAO(connection);
            return Results.Ok(nationalityDAO.GetAll());
        }
        finally
        {
            connection?.Close();
        }
    }

}