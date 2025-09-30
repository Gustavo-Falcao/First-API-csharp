using System.Reflection.Metadata.Ecma335;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

UserController userController = new();
userController.GenerateUsers();

app.MapGet("/saud", () =>
{
    return "Bem-vindo!!";
});

app.MapGet("/boas-vindas", () =>
{
    return "Bem-vindo usuário!!";
});

app.MapGet("/data-hora", () =>
{
    var data = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
    return data;
});

app.MapGet("/users", () =>
{
    return userController.GetUsers();
});

app.MapGet("/users/{id}", (string id) =>
{
    User? usuario = userController.FindUser(id);
    if (usuario is null)
    {
        return Results.NotFound("Usuário não encontrado");
    }
    return Results.Ok(usuario);
});

app.MapPost("/addUser", (User user) =>
{
    User usuario = userController.InserirUsuario(user);
    return Results.Created($"/usuarios/{usuario.Id}", usuario);
});

app.MapDelete("/deleteUser/{id}", (string id) =>
{
    if (userController.DeleteUser(id))
    {
        return Results.NoContent();
    }
    return Results.NotFound("Usuário não encontrado");
});

app.MapPut("/users/{id}", (string id, User userAtualizado) =>
{
    User? user = userController.FindUser(id);

    if (user is null)
    {
        return Results.NotFound("Usuário não encontrado");
    }

    user.Nome = userAtualizado.Nome;
    user.Email = userAtualizado.Email;
    user.Idade = userAtualizado.Idade;

    return Results.Ok(user);
});


app.Run();
