using TMPro;

public class MoneyView
{
    private TextMeshProUGUI moneyText;

    public MoneyView(TextMeshProUGUI moneyText)
    {
        this.moneyText = moneyText;
    }

    public void View()
    {
        moneyText.text = ResourceManager.Instance.money.ToString();
    }
}
