using System.Collections.Generic;
using UnityEngine;

public class CardHandDisplay : MonoBehaviour
{
    [SerializeField] private RectTransform cardParentContainer;
    private List<CardDisplay> cardDisplays = new();
    public void Display(Deck deck, CardDisplay cardPrefab)
    {
        DestroyCurrent();
        foreach (var card in deck.Hand)
        {
            CardDisplay newCard = Instantiate(cardPrefab, cardParentContainer);
            newCard.Display(card);
            cardDisplays.Add(newCard);
        }
    }

    private void DestroyCurrent()
    {
        cardDisplays.ForEach(c => Object.Destroy(c.gameObject));
        cardDisplays.Clear();
    }
}