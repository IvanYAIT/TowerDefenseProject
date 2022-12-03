using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Training : MonoBehaviour
{
    [SerializeField] private GameObject buttonLeft;
    [SerializeField] private GameObject buttonRight;
    [SerializeField] private List<TextMeshProUGUI> texts;

    private int pages;

    void Start()
    {
        pages = 0;
        texts[pages].gameObject.SetActive(true);
    }

    void Update()
    {
        if (pages == 0)
            buttonLeft.SetActive(false);
        else if (pages == texts.Count-1)
            buttonRight.SetActive(false);
        else
        {
            buttonLeft.SetActive(true);
            buttonRight.SetActive(true);
        }
    }

    public void Left()
    {
        if (pages != 0)
        {
            texts[pages].gameObject.SetActive(false);
            pages--;
            texts[pages].gameObject.SetActive(true);
        }
    }

    public void Right()
    {
        if (pages != texts.Count)
        {
            texts[pages].gameObject.SetActive(false);
            pages++;
            texts[pages].gameObject.SetActive(true);
        }
    }
}
