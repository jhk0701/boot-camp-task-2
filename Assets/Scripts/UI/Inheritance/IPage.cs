public interface IPage
{
    public static int Hash { get; }
    public string PageName { get; }

    public void Open();
    public void Close();
}
