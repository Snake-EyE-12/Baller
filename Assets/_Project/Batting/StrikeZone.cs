using UnityEngine;

public class StrikeZone
{
    public StrikeZone(Vector2 size)
    {
        this.size = size;
    }
    private Crosshair activeCrosshair;
    private PitchedBall activePitch;
    private Vector2 size;
    private float movementScaleMultiplier = 0.1f;
    public Crosshair Crosshair => activeCrosshair;
    public PitchedBall Pitch => activePitch;

    public void SetCrosshair(Crosshair crosshair)
    {
        activeCrosshair = crosshair;
    }

    public void SetPitch(PitchedBall pitch)
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
        
    }
}

public struct Crosshair
{
    public Crosshair(Vector2 pos, int baseSize)
    {
        Position = pos;
        BaseSize = baseSize;
    }
    public Vector2 Position { get; set; }
    public int BaseSize { get; private set; }
}

public class PitchedBall
{
    public PitchedBall(Vector2 pos)
    {
        Position = pos;
    }
    public Vector2 Position { get; set; }
    private BallMovement movement;
}

public abstract class BallMovement
{
    
}
