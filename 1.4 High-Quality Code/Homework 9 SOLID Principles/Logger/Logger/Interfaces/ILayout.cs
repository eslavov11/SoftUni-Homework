namespace Logger.Interfaces
{
    public interface ILayout
    {
        string LayoutFormat(string type, string message);
    }
}
