using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class Controller_I : MonoBehaviour
{
    [SerializeField] private ViewAssetContainer_I container;
    public static Controller_I instance;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;

        view = new ViewController_I(container);
        model = new ModelController_I();
    }

    public ViewController_I view {get; private set;}
    private ModelController_I model;


    public void Swing()
    {
        model.batting.ActiveAtBat.PerformSwing();
    }
    public void PlayCard(Card_I card)
    {
        card.Play();
        model.batting.ActiveAtBat.Progress();
        view.DisplayAtBat(model.batting.ActiveStrikeZone, model.general.Lineup.ActiveBatter, model.general.player.BattingDeck, model.batting.ActiveAtBat);
    }

    public void StartGame(BallGameDefinition_I def)
    {
        model.general.BuildGame(def, model.effector);
        view.PrepareGameDefaults();
        
        StartInning();
    }

    private void StartInning()
    {
        StartBattingInning();
    }

    private void StartBattingInning()
    {
        model.batting.PrepareInning();
        model.batting.SetHitter(model.general.Lineup.ActiveBatter);
        model.general.DrawBattingDeck();
        model.batting.Pitch();

        view.DisplayBatting();
        view.DisplayAtBat(model.batting.ActiveStrikeZone, model.general.Lineup.ActiveBatter, model.general.player.BattingDeck, model.batting.ActiveAtBat);

    }

    private void StartPitchingInning()
    {
        
    }
}

public class ViewController_I
{
    public ViewController_I(ViewAssetContainer_I assets)
    {
        sceneControl = new SceneController_I();
        this.assets = assets;
    }
    public SceneController_I sceneControl {get; private set;}
    private ViewAssetContainer_I assets;

    private StrikeZoneDisplay_I zoneDisplay;
    private BattingProgressionDisplay_I bar;
    private BatterDisplay_I batterDisplay;
    private CardHandDisplay_I cardHandDisplay;

    public void PrepareGameDefaults()
    {
        cardHandDisplay = Object.Instantiate(assets.cardHandDisplayPrefab, assets.mainDisplayParent);
    }
    public void DisplayBatting()
    {
        zoneDisplay = Object.Instantiate(assets.zoneDisplayPrefab, assets.mainDisplayParent);
        bar = Object.Instantiate(assets.batProgressionDisplayPrefab, assets.mainDisplayParent);
        batterDisplay = Object.Instantiate(assets.batterDisplayPrefab, assets.mainDisplayParent);
    }

    public void DisplayAtBat(StrikeZone_I zone, Baller_I activeBatter, Deck_I deck, AtBat_I atBat)
    {
        cardHandDisplay.Display(deck, assets.cardDisplayPrefab);
        batterDisplay.Display(activeBatter);
        zoneDisplay.Display(zone);
        bar.Display(atBat);
    }
}