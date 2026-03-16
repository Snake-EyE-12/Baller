using System.Collections.Generic;
using UnityEngine;

public class CardHandDisplay_I : MonoBehaviour
{
    [SerializeField] private RectTransform cardParentContainer;
    private List<CardDisplay_I> cardDisplays = new();
    public void Display(Deck_I deck, CardDisplay_I cardPrefab)
    {
        DestroyCurrent();
        foreach (var card in deck.Hand)
        {
            CardDisplay_I newCard = Instantiate(cardPrefab, cardParentContainer);
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