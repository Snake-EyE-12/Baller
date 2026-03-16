using UnityEngine;
using UnityEngine.UI;

public class BattingProgressionDisplay_I : MonoBehaviour
{
    [SerializeField] private Image image;
    public void Display(AtBat_I atBat)
    {
        image.fillAmount = (float)atBat.Level.x / atBat.Level.y;
    }

    public void Swing()
    {
        Controller_I.instance.Swing();
    }
}
