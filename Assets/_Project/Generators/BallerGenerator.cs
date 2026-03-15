


using UnityEngine;

public class BallerGenerator
{
    public string GetName()
    {
        return "Baller";
    }
    public Crosshair GetSwingSpot()
    {
        float x = 0.1f + Random.value * 0.8f;
        float y = 0.1f + Random.value * 0.8f;

        return new Crosshair(new Vector2(x, y), 5);
    }

    public PitchedBall GetPitch()
    {
        float x = 0.1f + Random.value * 0.8f;
        float y = 0.1f + Random.value * 0.8f;
        return new PitchedBall(new Vector2(x, y));
    }

    public int GetBallerStat()
    {
        return Mathf.RoundToInt(Random.value * 10);
    }

    public Card GetRandomCard(CardTribe tribe, CardEffectController controller)
    {
        return tribe switch
        {
            CardTribe.Batting  => GetBattingCard(controller),
            CardTribe.Pitching => GetPitchingCard(controller),
            CardTribe.FieldingRunning => GetActionCard(controller),
            CardTribe.Crowd => GetCrowdCard(controller),
            _ => null
        };
    }

    private Card GetBattingCard(CardEffectController controller)
    {
        return new Card(CardTribe.Batting, new(), new(){new CardEffectBatMovement(controller, GetDirectionVector6(1))});
    }

    private Card GetPitchingCard(CardEffectController controller)
    {
        return new Card(CardTribe.Pitching, new(), new(){new CardEffectBatMovement(controller, GetDirectionVector6(1))});
    }

    private Card GetActionCard(CardEffectController controller)
    {
        return new Card(CardTribe.FieldingRunning, new(), new(){new CardEffectBatMovement(controller, GetDirectionVector6(1))});
    }

    private Card GetCrowdCard(CardEffectController controller)
    {
        return new Card(CardTribe.Crowd, new(), new(){new CardEffectBatMovement(controller, GetDirectionVector6(1))});
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