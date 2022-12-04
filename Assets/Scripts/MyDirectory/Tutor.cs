using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutor : MonoBehaviour
{
    [Tooltip("objects that will be shown")]
    [SerializeField] Image[] sprites;
    
    private int i = 0;

    

    IEnumerator LerpShow(Image sprite)
    {
        Color c = sprite.color;
        for (float f = 0.05f;f <=1;f+= 0.05f)
        {
            
            c.a = f;
            sprite.color = c;
            yield return new WaitForSeconds(0.05f);
        }
        c.a = 1;
        sprite.color = c;
    }


    public void Show()
    {
        if(i < sprites.Length)
        {

            StartCoroutine(LerpShow(sprites[i]));
            i++;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
