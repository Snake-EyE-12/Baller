using UnityEngine;

public class CardEffectBatMovement : CardEffect
{
    protected Vector2 movement;
    public CardEffectBatMovement(CardEffectController effector, Vector2 displacement) : base(effector)
    {
        movement = displacement;
    }

    public override void Perform()
    {
        effectController.MoveCursor(movement);
        Debug.Log("Moved: " + movement);
    }
}





public abstract class CardEffect
{
    protected CardEffectController effectController;
    public CardEffect(CardEffectController effector)
    {
        effectController = effector;
    }

    public abstract void Perform();
}
