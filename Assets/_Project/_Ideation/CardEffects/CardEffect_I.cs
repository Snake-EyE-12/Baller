using UnityEngine;

public class CardEffectBatMovement_I : CardEffect_I
{
    protected Vector2 movement;
    public CardEffectBatMovement_I(CardEffectController_I effector, Vector2 displacement) : base(effector)
    {
        movement = displacement;
    }

    public override void Perform()
    {
        effectController.MoveCursor(movement);
        Debug.Log("Moved: " + movement);
    }
}





public abstract class CardEffect_I
{
    protected CardEffectController_I effectController;
    public CardEffect_I(CardEffectController_I effector)
    {
        effectController = effector;
    }

    public abstract void Perform();
}
