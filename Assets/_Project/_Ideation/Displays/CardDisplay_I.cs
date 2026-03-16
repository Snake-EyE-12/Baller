using TMPro;
using UnityEngine;

public class CardDisplay_I : MonoBehaviour
{
    [SerializeField] private TMP_Text textbox;
    private Card_I displayedCard;
    public void Display(Card_I card)
    {
        displayedCard = card;
        textbox.text = card.Tribe.ToString();
    }

    public void Use()
    {
        Controller_I.instance.PlayCard(displayedCard);
    }
}
