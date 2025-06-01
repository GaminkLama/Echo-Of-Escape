using UnityEngine;

public class Cell : MonoBehaviour
{
    public RoomType roomType;
    public SpriteRenderer iconRenderer;
    
    public GameObject doorTop, doorBottom, doorLeft, doorRight;


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

    public void OpenDoor(Vector2Int dir)
    {
        if (dir == Vector2Int.up && doorTop != null)
            doorTop.SetActive(true);
        else if (dir == Vector2Int.down && doorBottom != null)
            doorBottom.SetActive(true);
        else if (dir == Vector2Int.left && doorLeft != null)
            doorLeft.SetActive(true);
        else if (dir == Vector2Int.right && doorRight != null)
            doorRight.SetActive(true);
    }


}
