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
        if(hp > 0)
            hpText.text = hp.ToString();
        else
            hpText.text = "0";

    }
}
