using UnityEngine;

public class CardEffectController
{
    private ModelController modelController;
    public CardEffectController(ModelController model)
    {
        modelController = model;
    }
    public void MoveCursor(Vector2 displacement)
    {
        modelController.batting.ActiveStrikeZone.MoveCrosshair(displacement);
    }
}