using System.Collections.Generic;
using UnityEngine;

public class Baller
{
    public Baller(string alias, Crosshair initSwingPos, BallerStats stats, BallerInventory inventory)
    {
        this.alias = alias;
        Crosshair = initSwingPos;
        this.stats = stats;
        Inventory = inventory;
    }

    private string alias;
    private BallerStats stats;

    public BallerInventory Inventory { get; private set; }

    public Crosshair Crosshair { get; }
}

public class BallerStats
{
    public BallerStats(int swingPower, int runningSpeed)
    {
        baseSwingPower = swingPower;
        baseRunningSpeed = runningSpeed;
    }
    private int baseSwingPower;
    private int baseRunningSpeed;
}

public class BallerInventory
{
    public BallerInventory(List<Card> cards)
    {
        this.cards = cards;
    }
    private List<Card> cards;
    
    public List<Card> Cards => cards;
}

public class Card
{
    public Card(CardTribe tribe, List<CardCondition> conditions, List<CardEffect> effects)
    {
        Tribe = tribe;
        this.conditions = conditions;
        this.effects = effects;
    }

    public Deck connectedDeck;
    private List<CardCondition> conditions;
    private List<CardEffect> effects;

    public void Play()
    {
        if (!canPlay()) return;
        foreach (CardEffect effect in effects)
        {
            effect.Perform();
        }
        connectedDeck.Discard(this);
    }

    private bool canPlay()
    {
        foreach (CardCondition condition in conditions)
        {
            if (!condition.CanPerform) return false;
        }

        return true;
    }
    public CardTribe Tribe {get; private set;}
}

public enum CardTribe
{
    None,
    Batting,
    Pitching,
    FieldingRunning,
    Crowd
}

public abstract class CardCondition
{
    public virtual bool CanPerform => true;
}
