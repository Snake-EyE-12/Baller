using UnityEngine;

public class CardEffectController_I
{
    private ModelController_I modelController;
    public CardEffectController_I(ModelController_I model)
    {
        modelController = model;
    }
    public void MoveCursor(Vector2 displacement)
    {
        modelController.batting.ActiveStrikeZone.MoveCrosshair(displacement);
    }
}