using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager
{
    public float master;
    public float sfx;
    public float music;

    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new AudioManager();
            }

            return instance;
        }
    }
}
