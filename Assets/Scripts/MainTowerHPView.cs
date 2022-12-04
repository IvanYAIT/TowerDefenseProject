using TMPro;

public class MainTowerHPView
{
    private TextMeshProUGUI hpText;

    public MainTowerHPView(TextMeshProUGUI hpText)
    {
        this.hpText = hpText;
    }

    public void View(int hp)
    {
        hpText.text = hp.ToString();
    }
}
