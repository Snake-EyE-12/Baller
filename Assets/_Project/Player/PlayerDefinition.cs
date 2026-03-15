using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerDefinition
{
    public PlayerDefinition(Baller[] startingTeam)
    {
        team = new Team();
        BattingDeck = new Deck();
        PitchingDeck = new Deck();
        ActionDeck = new Deck();
        CrowdDeck = new Deck();

        foreach (Baller member in startingTeam)
        {
            AddTeamMember(member);
        }
    }
    
    private Team team;
    public Deck BattingDeck {get; private set;}
    public Deck PitchingDeck {get; private set;}
    public Deck ActionDeck {get; private set;}
    public Deck CrowdDeck {get; private set;}


    public void AddTeamMember(Baller recruit)
    {
        team.Add(recruit);
        foreach (Card card in recruit.Inventory.Cards)
        {
            AddCard(card);
        }
    }

    public void RemoveTeamMember(Baller recruit)
    {
        team.Remove(recruit);
        foreach (Card card in recruit.Inventory.Cards)
        {
            RemoveCard(card);
        }
    }

    private void AddCard(Card card)
    {
        Deck match = GetMatchingDeck(card.Tribe);
        match.Add(card);
    }

    private void RemoveCard(Card card)
    {
        Deck match = GetMatchingDeck(card.Tribe);
        match.Remove(card);
    }

    private Deck GetMatchingDeck(CardTribe tribe)
    {
        return tribe switch
        {
            CardTribe.Batting => BattingDeck,
            CardTribe.Pitching => PitchingDeck,
            CardTribe.FieldingRunning => ActionDeck,
            CardTribe.Crowd => CrowdDeck,
            _ => null
        };
    }
}

public class Team
{
    private List<Baller> ballers = new();

    public void Add(Baller baller)
    {
        ballers.Add(baller);
    }

    public void Remove(Baller baller)
    {
        ballers.Remove(baller);
    }
}
public class Lineup
{
    public Lineup(Baller[] initial)
    {
        SetOrder(initial);
        index = 0;
    }
    private int index;
    private Baller[] line;
    public void SetOrder(Baller[] order)
    {
        line = order;
    }

    public Baller Advance()
    {
        index = (index + 1) % line.Length;
        return line[index];
    }
    public Baller ActiveBatter => line[index];
}
public class Deck
{
    private List<Card> inFull = new();
    private List<Card> hand = new();
    private List<Card> discard = new();
    private List<Card> draw = new();
    public List<Card> Hand => hand;
    public List<Card> Discards => discard;
    public List<Card> DrawPile => draw;
    public void FullShuffle()
    {
        discard.Clear();
        hand.Clear();
        draw = inFull;
    }
    
    public void Add(Card card)
    {
        inFull.Add(card);
        card.connectedDeck = this;
    }

    public void Remove(Card card)
    {
        inFull.Remove(card);
    }

    public void Shuffle()
    {
        draw = discard;
        draw.OrderBy((x) => Random.value);
    }

    public void Draw(int amount)
    {
        int possible = hand.Count + discard.Count;
        amount = Mathf.Max(amount, possible);
        for (int i = 0; i < amount; i++) Draw();
    }
    private void Draw()
    {
        if (draw.Count == 0) Shuffle();
        Card top = draw[0];
        draw.RemoveAt(0);
        hand.Add(top);
    }

    public void Discard(Card card)
    {
        hand.Remove(card);
        discard.Add(card);
    }
}