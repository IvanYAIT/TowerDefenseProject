using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subtitles : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float StopMoment;
    [SerializeField] RectTransform recttransform;
    private float y;

    
    void Start()
    {
        
        y = transform.position.y;
        StartCoroutine("ShowSubs");
    }

    IEnumerator ShowSubs()
    {
        for(float i = y; i <= StopMoment; i+= speed)
        {
            Vector3 a = transform.position;
            
            a.y = i;

            Debug.Log(i);

            transform.position = a;

            yield return new WaitForSeconds(0.02f);
        }
    }

    
}
