


using UnityEngine;

public class BallerGenerator_I
{
    public string GetName()
    {
        return "Baller";
    }
    public Crosshair_I GetSwingSpot()
    {
        float x = 0.1f + Random.value * 0.8f;
        float y = 0.1f + Random.value * 0.8f;

        return new Crosshair_I(new Vector2(x, y), 5);
    }

    public PitchedBall_I GetPitch()
    {
        float x = 0.1f + Random.value * 0.8f;
        float y = 0.1f + Random.value * 0.8f;
        return new PitchedBall_I(new Vector2(x, y));
    }

    public int GetBallerStat()
    {
        return Mathf.RoundToInt(Random.value * 10);
    }

    public Card_I GetRandomCard(CardTribe_I tribe, CardEffectController_I controller)
    {
        return tribe switch
        {
            CardTribe_I.Batting  => GetBattingCard(controller),
            CardTribe_I.Pitching => GetPitchingCard(controller),
            CardTribe_I.FieldingRunning => GetActionCard(controller),
            CardTribe_I.Crowd => GetCrowdCard(controller),
            _ => null
        };
    }

    private Card_I GetBattingCard(CardEffectController_I controller)
    {
        return new Card_I(CardTribe_I.Batting, new(), new(){new CardEffectBatMovement_I(controller, GetDirectionVector6(1))});
    }

    private Card_I GetPitchingCard(CardEffectController_I controller)
    {
        return new Card_I(CardTribe_I.Pitching, new(), new(){new CardEffectBatMovement_I(controller, GetDirectionVector6(1))});
    }

    private Card_I GetActionCard(CardEffectController_I controller)
    {
        return new Card_I(CardTribe_I.FieldingRunning, new(), new(){new CardEffectBatMovement_I(controller, GetDirectionVector6(1))});
    }

    private Card_I GetCrowdCard(CardEffectController_I controller)
    {
        return new Card_I(CardTribe_I.Crowd, new(), new(){new CardEffectBatMovement_I(controller, GetDirectionVector6(1))});
    }

    private Vector2 GetDirectionVector6(float scale)
    {
        int cornerIndex = Random.Range(0, 6); // pick one of the 6 corners
        float angleDeg = cornerIndex * 60f;
        float angleRad = angleDeg * Mathf.Deg2Rad;

        return new Vector2(
            Mathf.Cos(angleRad),
            Mathf.Sin(angleRad)
        ) * scale;
    }
}