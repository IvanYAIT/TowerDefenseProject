using System.Collections;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private int sec = -1;
    private int min;

    public void StartTimer()=> StartCoroutine(TimeFlow());

    IEnumerator TimeFlow()
    {
        while (true)
        {
            if(sec == 59)
            {
                min++;
                sec = -1;
            }
            sec++;
            text.text = min.ToString("D2") + ":" + sec.ToString("D2");
            yield return new WaitForSeconds(1);
        }
    }
}
