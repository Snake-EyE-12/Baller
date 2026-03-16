using System.Collections.Generic;
using UnityEngine;

public class Baller_I
{
    public Baller_I(string alias, Crosshair_I initSwingPos, BallerStats_I stats, BallerInventory_I inventory)
    {
        this.alias = alias;
        Crosshair = initSwingPos;
        this.stats = stats;
        Inventory = inventory;
    }

    private string alias;
    private BallerStats_I stats;

    public BallerInventory_I Inventory { get; private set; }

    public Crosshair_I Crosshair { get; }
}

public class BallerStats_I
{
    public BallerStats_I(int swingPower, int runningSpeed)
    {
        baseSwingPower = swingPower;
        baseRunningSpeed = runningSpeed;
    }
    private int baseSwingPower;
    private int baseRunningSpeed;
}

public class BallerInventory_I
{
    public BallerInventory_I(List<Card_I> cards)
    {
        this.cards = cards;
    }
    private List<Card_I> cards;
    
    public List<Card_I> Cards => cards;
}

public class Card_I
{
    public Card_I(CardTribe_I tribe, List<CardCondition_I> conditions, List<CardEffect_I> effects)
    {
        Tribe = tribe;
        this.conditions = conditions;
        this.effects = effects;
    }

    public Deck_I connectedDeck;
    private List<CardCondition_I> conditions;
    private List<CardEffect_I> effects;

    public void Play()
    {
        if (!canPlay()) return;
        foreach (CardEffect_I effect in effects)
        {
            effect.Perform();
        }
        connectedDeck.Discard(this);
    }

    private bool canPlay()
    {
        foreach (CardCondition_I condition in conditions)
        {
            if (!condition.CanPerform) return false;
        }

        return true;
    }
    public CardTribe_I Tribe {get; private set;}
}

public enum CardTribe_I
{
    None,
    Batting,
    Pitching,
    FieldingRunning,
    Crowd
}

public abstract class CardCondition_I
{
    public virtual bool CanPerform => true;
}
