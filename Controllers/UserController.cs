using Microsoft.AspNetCore.Mvc;

namespace UsersAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class UserController: Controller
{
    [HttpGet("Login/{username}/{password}")]
    public IResult login(string username, string password)
    {
        var connection = Database.GetConnection();

        try
        {
            var user = new User
            {
                name = username,
                password = password
            };

            var userDAO = new UserDAO(connection);
            var token = userDAO.Login(user);

            if (token == null)
            {
                return Results.Json(
                    data: new ErrorResult(0, "Incorrect username or password"),
                    statusCode: StatusCodes.Status400BadRequest
                );
            }
            else
            {
                return Results.Json(
                    data: token,
                    statusCode: StatusCodes.Status200OK
                );
            }
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