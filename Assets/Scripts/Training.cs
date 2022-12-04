using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using State;

public class Training : MonoBehaviour
{
    [SerializeField] private GameObject buttonLeft;
    [SerializeField] private GameObject buttonRight;
    [SerializeField] private GameObject buttonPlay;
    [SerializeField] private List<TextMeshProUGUI> texts;
    [SerializeField] private List<GameObject> darkPanels;

    public static Action<Type> OnPlayBtnPress;

    private int pages;

    void Start()
    {
        pages = 0;
        texts[pages].gameObject.SetActive(true);
        darkPanels[pages].SetActive(true);
    }

    void Update()
    {
        if (pages == 0)
            buttonLeft.SetActive(false);
        else if (pages == texts.Count - 1)
        {
            buttonRight.SetActive(false);
            buttonPlay.SetActive(true);
        }
        else
        {
            buttonLeft.SetActive(true);
            buttonRight.SetActive(true);
            buttonPlay.SetActive(false);
        }
    }

    public void Left()
    {
        if (pages != 0)
        {
            texts[pages].gameObject.SetActive(false);
            darkPanels[pages].SetActive(false);
            pages--;
            texts[pages].gameObject.SetActive(true);
            darkPanels[pages].SetActive(true);
        }
    }

    public void Right()
    {
        if (pages != texts.Count)
        {
            texts[pages].gameObject.SetActive(false);
            darkPanels[pages].SetActive(false);
            pages++;
            texts[pages].gameObject.SetActive(true);
            darkPanels[pages].SetActive(true);
        }
    }

    public void Play() =>
        OnPlayBtnPress?.Invoke(typeof(GameState));
}
