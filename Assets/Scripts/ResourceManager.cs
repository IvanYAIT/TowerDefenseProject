public class ResourceManager
{
    public int money;

    private static ResourceManager instance;
    public static ResourceManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ResourceManager();
            }

            return instance;
        }
    }
}
