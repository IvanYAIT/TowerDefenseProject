public class ResourceManager
{
    public int money = 400;

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
