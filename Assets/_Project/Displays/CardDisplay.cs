using TMPro;
using UnityEngine;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text textbox;
    private Card displayedCard;
    public void Display(Card card)
    {
        displayedCard = card;
        textbox.text = card.Tribe.ToString();
    }

    public void Use()
    {
        Controller.instance.PlayCard(displayedCard);
    }
}
