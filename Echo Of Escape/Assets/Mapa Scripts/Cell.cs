using UnityEngine;

public class Cell : MonoBehaviour
{
    public RoomType roomType;
    public SpriteRenderer iconRenderer;

    public void SetRoomType(RoomType type)
    {
        this.roomType = type;
    }

    public void SetRoomType(RoomType type, Sprite icon)
    {
        this.roomType = type;
        SetSpecialRoomSprite(icon);
    }

    public void SetSpecialRoomSprite(Sprite icon)
    {
        if (iconRenderer != null)
            iconRenderer.sprite = icon;
        else
            Debug.LogWarning("iconRenderer is not assigned in the inspector.");
    }
}
