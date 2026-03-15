using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class Controller : MonoBehaviour
{
    [SerializeField] private ViewAssetContainer container;
    public static Controller instance;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;

        view = new ViewController(container);
        model = new ModelController();
    }

    public ViewController view {get; private set;}
    private ModelController model;


    public void Swing()
    {
        model.batting.ActiveAtBat.PerformSwing();
    }
    public void PlayCard(Card card)
    {
        card.Play();
        model.batting.ActiveAtBat.Progress();
        view.DisplayAtBat(model.batting.ActiveStrikeZone, model.general.Lineup.ActiveBatter, model.general.player.BattingDeck, model.batting.ActiveAtBat);
    }

    public void StartGame(BallGameDefinition def)
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

public class ViewController
{
    public ViewController(ViewAssetContainer assets)
    {
        sceneControl = new SceneController();
        this.assets = assets;
    }
    public SceneController sceneControl {get; private set;}
    private ViewAssetContainer assets;

    private StrikeZoneDisplay zoneDisplay;
    private BattingProgressionDisplay bar;
    private BatterDisplay batterDisplay;
    private CardHandDisplay cardHandDisplay;

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

    public void DisplayAtBat(StrikeZone zone, Baller activeBatter, Deck deck, AtBat atBat)
    {
        cardHandDisplay.Display(deck, assets.cardDisplayPrefab);
        batterDisplay.Display(activeBatter);
        zoneDisplay.Display(zone);
        bar.Display(atBat);
    }
}