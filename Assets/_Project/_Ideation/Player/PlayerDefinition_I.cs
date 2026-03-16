using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerDefinition_I
{
    public PlayerDefinition_I(Baller_I[] startingTeam)
    {
        team = new Team_I();
        BattingDeck = new Deck_I();
        PitchingDeck = new Deck_I();
        ActionDeck = new Deck_I();
        CrowdDeck = new Deck_I();

        foreach (Baller_I member in startingTeam)
        {
            AddTeamMember(member);
        }
    }
    
    private Team_I team;
    public Deck_I BattingDeck {get; private set;}
    public Deck_I PitchingDeck {get; private set;}
    public Deck_I ActionDeck {get; private set;}
    public Deck_I CrowdDeck {get; private set;}


    public void AddTeamMember(Baller_I recruit)
    {
        team.Add(recruit);
        foreach (Card_I card in recruit.Inventory.Cards)
        {
            AddCard(card);
        }
    }

    public void RemoveTeamMember(Baller_I recruit)
    {
        team.Remove(recruit);
        foreach (Card_I card in recruit.Inventory.Cards)
        {
            RemoveCard(card);
        }
    }

    private void AddCard(Card_I card)
    {
        Deck_I match = GetMatchingDeck(card.Tribe);
        match.Add(card);
    }

    private void RemoveCard(Card_I card)
    {
        Deck_I match = GetMatchingDeck(card.Tribe);
        match.Remove(card);
    }

    private Deck_I GetMatchingDeck(CardTribe_I tribe)
    {
        return tribe switch
        {
            CardTribe_I.Batting => BattingDeck,
            CardTribe_I.Pitching => PitchingDeck,
            CardTribe_I.FieldingRunning => ActionDeck,
            CardTribe_I.Crowd => CrowdDeck,
            _ => null
        };
    }
}

public class Team_I
{
    private List<Baller_I> ballers = new();

    public void Add(Baller_I baller)
    {
        ballers.Add(baller);
    }

    public void Remove(Baller_I baller)
    {
        ballers.Remove(baller);
    }
}
public class Lineup_I
{
    public Lineup_I(Baller_I[] initial)
    {
        SetOrder(initial);
        index = 0;
    }
    private int index;
    private Baller_I[] line;
    public void SetOrder(Baller_I[] order)
    {
        line = order;
    }

    public Baller_I Advance()
    {
        index = (index + 1) % line.Length;
        return line[index];
    }
    public Baller_I ActiveBatter => line[index];
}
public class Deck_I
{
    private List<Card_I> inFull = new();
    private List<Card_I> hand = new();
    private List<Card_I> discard = new();
    private List<Card_I> draw = new();
    public List<Card_I> Hand => hand;
    public List<Card_I> Discards => discard;
    public List<Card_I> DrawPile => draw;
    public void FullShuffle()
    {
        discard.Clear();
        hand.Clear();
        draw = inFull;
    }
    
    public void Add(Card_I card)
    {
        inFull.Add(card);
        card.connectedDeck = this;
    }

    public void Remove(Card_I card)
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
        Card_I top = draw[0];
        draw.RemoveAt(0);
        hand.Add(top);
    }

    public void Discard(Card_I card)
    {
        hand.Remove(card);
        discard.Add(card);
    }
}