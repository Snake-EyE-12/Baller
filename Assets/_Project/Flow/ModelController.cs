using System.Collections.Generic;
using UnityEngine;

public class ModelController
{
    public ModelController()
    {
        general = new GeneralGameController();
        batting = new BattingController();
        pitching = new PitchingController();
        effector = new CardEffectController(this);
    }
    public GeneralGameController general { get; private set; }
    public BattingController batting { get; private set; }
    public PitchingController pitching { get; private set; }
    public CardEffectController effector { get; private set; }
    
}

public class GeneralGameController
{
    private BallGame activeBallGame;
    public PlayerDefinition player { get; private set; }
    public Lineup Lineup {get; private set;}
    public void BuildGame(BallGameDefinition def, CardEffectController cec)
    {
        activeBallGame = new BallGame(def);
        Baller[] ballers = new Baller[9];
        BallerGenerator generator = new BallerGenerator();
        for (int i = 0; i < 9; i++)
        {
            List<Card> cards = new();
            cards.Add(generator.GetRandomCard(CardTribe.Batting, cec));
            cards.Add(generator.GetRandomCard(CardTribe.Pitching, cec));
            cards.Add(generator.GetRandomCard(CardTribe.FieldingRunning, cec));
            cards.Add(generator.GetRandomCard(CardTribe.Crowd, cec));
            ballers[i] = new Baller(generator.GetName(), generator.GetSwingSpot(), new BallerStats(generator.GetBallerStat(), generator.GetBallerStat()), new BallerInventory(cards));
        }
        player = new PlayerDefinition(ballers);
        Lineup = new Lineup(ballers);
    }

    
    public void DrawBattingDeck()
    {
        player.BattingDeck.FullShuffle();
        player.BattingDeck.Draw(4);
    }



}

public class BattingController
{
    
    public StrikeZone ActiveStrikeZone { get; private set; }
    public AtBat ActiveAtBat { get; private set; }
    private Baller activeHitter;
    BallerGenerator generator = new BallerGenerator();
    public void PrepareInning()
    {
        ActiveStrikeZone = new StrikeZone(new Vector2(17, 27));
    }

    public void SetHitter(Baller hitter)
    {
        activeHitter = hitter;
        ActiveStrikeZone.SetCrosshair(hitter.Crosshair);
        ActiveAtBat = new AtBat();
    }

    public void Pitch()
    {
        ActiveStrikeZone.SetPitch(generator.GetPitch());
        ActiveStrikeZone.SetCrosshair(activeHitter.Crosshair);
    }
}


public class PitchingController
{
    
}

public class AtBat
{
    private int level;
    private int maxLevel = 4;
    public Vector2Int Level => new Vector2Int(level, maxLevel);

    public void Progress()
    {
        level++;
        if (level >= maxLevel) PerformSwing();
    }

    public void PerformSwing()
    {
        
    }
}