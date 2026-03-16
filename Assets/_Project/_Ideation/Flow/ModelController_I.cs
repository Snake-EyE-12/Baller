using System.Collections.Generic;
using UnityEngine;

public class ModelController_I
{
    public ModelController_I()
    {
        general = new GeneralGameController_I();
        batting = new BattingController_I();
        pitching = new PitchingController_I();
        effector = new CardEffectController_I(this);
    }
    public GeneralGameController_I general { get; private set; }
    public BattingController_I batting { get; private set; }
    public PitchingController_I pitching { get; private set; }
    public CardEffectController_I effector { get; private set; }
    
}

public class GeneralGameController_I
{
    private BallGame_I activeBallGame;
    public PlayerDefinition_I player { get; private set; }
    public Lineup_I Lineup {get; private set;}
    public void BuildGame(BallGameDefinition_I def, CardEffectController_I cec)
    {
        activeBallGame = new BallGame_I(def);
        Baller_I[] ballers = new Baller_I[9];
        BallerGenerator_I generator = new BallerGenerator_I();
        for (int i = 0; i < 9; i++)
        {
            List<Card_I> cards = new();
            cards.Add(generator.GetRandomCard(CardTribe_I.Batting, cec));
            cards.Add(generator.GetRandomCard(CardTribe_I.Pitching, cec));
            cards.Add(generator.GetRandomCard(CardTribe_I.FieldingRunning, cec));
            cards.Add(generator.GetRandomCard(CardTribe_I.Crowd, cec));
            ballers[i] = new Baller_I(generator.GetName(), generator.GetSwingSpot(), new BallerStats_I(generator.GetBallerStat(), generator.GetBallerStat()), new BallerInventory_I(cards));
        }
        player = new PlayerDefinition_I(ballers);
        Lineup = new Lineup_I(ballers);
    }

    
    public void DrawBattingDeck()
    {
        player.BattingDeck.FullShuffle();
        player.BattingDeck.Draw(4);
    }



}

public class BattingController_I
{
    
    public StrikeZone_I ActiveStrikeZone { get; private set; }
    public AtBat_I ActiveAtBat { get; private set; }
    private Baller_I activeHitter;
    BallerGenerator_I generator = new BallerGenerator_I();
    public void PrepareInning()
    {
        ActiveStrikeZone = new StrikeZone_I(new Vector2(17, 27));
    }

    public void SetHitter(Baller_I hitter)
    {
        activeHitter = hitter;
        ActiveStrikeZone.SetCrosshair(hitter.Crosshair);
        ActiveAtBat = new AtBat_I();
    }

    public void Pitch()
    {
        ActiveStrikeZone.SetPitch(generator.GetPitch());
        ActiveStrikeZone.SetCrosshair(activeHitter.Crosshair);
    }
}


public class PitchingController_I
{
    
}

public class AtBat_I
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