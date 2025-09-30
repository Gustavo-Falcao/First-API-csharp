class UserController
{
    private List<User> users = new ();

    public List<User> GetUsers()
    {
        return users;
    }
    public void GenerateUsers()
    {
        users.Add(new User("Clementine Bauch", "Nathan@yesenia.net", 23));
        users.Add(new User("Patricia Lebsack", "Julianne.OConner@kory.org", 29));
        users.Add(new User("Chelsey Dietrich", "Lucio_Hettinger@annie.ca", 35));
        users.Add(new User("Mrs. Dennis Schulist", "Karley_Dach@jasper.info", 47));
        users.Add(new User("Kurtis Weissnat", "Telly.Hoeger@billy.biz", 41));
    }

    public User InserirUsuario(User user)
    {
        users.Add(user);
        return user;
    }

    public User? FindUser(string id)
    {
        User? userEncontrado = null;
        foreach (User user in users)
        {
            if (user.Id == id)
            {
                userEncontrado = user;
            }
        }

        return userEncontrado;
    }

    public bool DeleteUser(string id)
    {
        User? user = FindUser(id);
        if (user is not null)
        {
            users.Remove(user);
            return true;
        }
        else
        {
            return false;
        }
    }
}