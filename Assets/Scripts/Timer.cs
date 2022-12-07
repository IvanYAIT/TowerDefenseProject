using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Image levelEnd;
    [SerializeField] private AudioSource music;
    [SerializeField] int startSec;
    [SerializeField] int startMin;
    private Color levelEndColor;
    private float volume;
    private int sec = -1;
    private int min;
    private bool isEnd = false;
    private bool isCoroutineStart = false;

    public void StartTimer()
    {
        levelEndColor = levelEnd.GetComponent<Image>().color;
        volume = music.volume / 100;
        StartCoroutine(TimeFlow());
    }

    public void Check()
    {
        if (!isEnd)
        {
            if (min == startMin)
            {
                if (sec == startSec)
                {
                    levelEnd.gameObject.SetActive(true);
                    isEnd = true;
                }
            }
        }
        else
        {
            if (!isCoroutineStart)
            {
                StartCoroutine(End(levelEndColor));
                isCoroutineStart = true;
            }
        }
    }

    IEnumerator TimeFlow()
    {
        while (true)
        {
            if (sec == 59)
            {
                min++;
                sec = -1;
            }
            sec++;
            text.text = min.ToString("D2") + ":" + sec.ToString("D2");
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator End(Color color)
    {
        while (true)
        {
            color.a += 0.01f;
            music.volume -= volume;
            levelEnd.GetComponent<Image>().color = color;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
