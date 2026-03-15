using UnityEngine;

public class StrikeZoneDisplay : MonoBehaviour
{
    [SerializeField] private PitchDisplay pitchDisplay;
    [SerializeField] private CrosshairDisplay crosshairDisplay;
    [SerializeField] private RectTransform parentRect;

    public void Display(StrikeZone zone)
    {
        pitchDisplay.Display(zone.Pitch);
        crosshairDisplay.Display(zone.Crosshair);

        pitchDisplay.transform.localPosition = GetPositionInRect(zone.Pitch.Position);
        crosshairDisplay.transform.localPosition = GetPositionInRect(zone.Crosshair.Position);
    }

    private Vector3 GetPositionInRect(Vector2 normalizedPos)
    {
        Rect rect = parentRect.rect;

        float x = (normalizedPos.x - 0.5f) * rect.width;
        float y = (normalizedPos.y - 0.5f) * rect.height;

        return new Vector3(x, y, 0f);
    }
}