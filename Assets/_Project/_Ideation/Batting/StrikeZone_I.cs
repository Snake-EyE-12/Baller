using UnityEngine;

public class StrikeZone_I
{
    public StrikeZone_I(Vector2 size)
    {
        this.size = size;
    }
    private Crosshair_I activeCrosshair;
    private PitchedBall_I activePitch;
    private Vector2 size;
    private float movementScaleMultiplier = 0.1f;
    public Crosshair_I Crosshair => activeCrosshair;
    public PitchedBall_I Pitch => activePitch;

    public void SetCrosshair(Crosshair_I crosshair)
    {
        activeCrosshair = crosshair;
    }

    public void SetPitch(PitchedBall_I pitch)
    {
        activePitch = pitch;
    }

    public void MoveCrosshair(Vector2 along)
    {
        activeCrosshair.Position += along * movementScaleMultiplier;
    }

    public void MovePitch(Vector2 along)
    {
        activePitch.Position += along;
    }

    public float DetermineHitStrength()
    {
        return 0.0f;
    }
}

public struct Crosshair_I
{
    public Crosshair_I(Vector2 pos, int baseSize)
    {
        Position = pos;
        BaseSize = baseSize;
    }
    public Vector2 Position { get; set; }
    public int BaseSize { get; private set; }
}

public class PitchedBall_I
{
    public PitchedBall_I(Vector2 pos)
    {
        Position = pos;
    }
    public Vector2 Position { get; set; }
    private BallMovement_I movement;
}

public abstract class BallMovement_I
{
    
}
