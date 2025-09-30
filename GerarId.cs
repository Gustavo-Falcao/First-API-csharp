class GeradorId
{
    public static string GerarId()
    {
        return Guid.NewGuid().ToString("N");
    }
}