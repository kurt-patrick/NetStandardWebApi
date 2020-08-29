namespace Request_Throttling.Interfaces
{
    public interface IUserStore
    {
        Models.User FindByUsername(string identifier);
    }
}