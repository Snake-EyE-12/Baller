using UnityEngine;
using UnityEngine.UI;

public class BattingProgressionDisplay : MonoBehaviour
{
    [SerializeField] private Image image;
    public void Display(AtBat atBat)
    {
        image.fillAmount = (float)atBat.Level.x / atBat.Level.y;
    }

    public void Swing()
    {
        Controller.instance.Swing();
    }
}
