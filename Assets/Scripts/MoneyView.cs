using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyView
{
    private Text moneyText;

    public MoneyView(Text moneyText)
    {
        this.moneyText = moneyText;
    }

    public void View()
    {
        moneyText.text = ResourceManager.Instance.money.ToString();
    }
}
