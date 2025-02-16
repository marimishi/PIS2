namespace PIS
{
    public interface IRule
    {
        string purpose { get; }
        string[] messages { get; }
        bool Check(User user);
    }
}
