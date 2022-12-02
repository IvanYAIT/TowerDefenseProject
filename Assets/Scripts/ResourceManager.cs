using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public int money = 100;

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
