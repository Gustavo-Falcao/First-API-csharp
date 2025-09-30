class User
{
    public string Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public int Idade { get; set; }

    public User(string nome, string email, int idade)
    {
        Id = GeradorId.GerarId();
        Nome = nome;
        Email = email;
        Idade = idade;
    }
}