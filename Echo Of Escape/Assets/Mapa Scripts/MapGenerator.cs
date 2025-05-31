using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Header("Room Settings")]
    public Cell roomPrefab;
    public Transform roomParent;
    public int roomCount = 12;
    public float roomSpacing = 10f;

    [Header("Special Room Sprites")]
    public Sprite bossSprite;
    public Sprite shopSprite;
    public Sprite itemSprite;
    public Sprite secretSprite;

    private Dictionary<Vector2Int, Cell> rooms = new();
    private List<Vector2Int> roomPositions = new();

    public CameraFollow cameraFollow; // przypisz w Inspectorze
    void Start()
    {
        GenerateRooms();
    }

    void GenerateRooms()
    {
        Vector2Int start = Vector2Int.zero;
        AddRoom(start);
        Queue<Vector2Int> expansionQueue = new Queue<Vector2Int>();
        expansionQueue.Enqueue(start);

        while (rooms.Count < roomCount && expansionQueue.Count > 0)
        {
            Vector2Int current = expansionQueue.Dequeue();

            foreach (Vector2Int dir in Directions())
            {
                Vector2Int next = current + dir;
                if (!rooms.ContainsKey(next) && Random.value < 0.5f)
                {
                    AddRoom(next);
                    expansionQueue.Enqueue(next);

                    if (rooms.Count >= roomCount)
                        break;
                }
            }
        }

        AssignSpecialRooms();
    }

    void AddRoom(Vector2Int gridPos)
    {
        Vector3 worldPos = new Vector3(gridPos.x * roomSpacing, gridPos.y * roomSpacing, 0);
        Cell room = Instantiate(roomPrefab, worldPos, Quaternion.identity, roomParent);
        room.SetRoomType(RoomType.Normal);
        rooms.Add(gridPos, room);
        roomPositions.Add(gridPos);
    }

    void AssignSpecialRooms()
    {
        if (roomPositions.Count == 0) return;

        // Boss = najdalej od startu
        Vector2Int bossRoom = GetFurthestRoom(Vector2Int.zero);
        rooms[bossRoom].SetRoomType(RoomType.Boss, bossSprite);
        roomPositions.Remove(bossRoom);

        AssignRandomRoom(RoomType.Shop, shopSprite);
        AssignRandomRoom(RoomType.Item, itemSprite);
        AssignRandomRoom(RoomType.Secret, secretSprite);
    }

    void AssignRandomRoom(RoomType type, Sprite icon)
    {
        if (roomPositions.Count == 0) return;
        int index = Random.Range(0, roomPositions.Count);
        Vector2Int pos = roomPositions[index];
        rooms[pos].SetRoomType(type, icon);
        roomPositions.RemoveAt(index);
    }

    Vector2Int GetFurthestRoom(Vector2Int origin)
    {
        Vector2Int furthest = origin;
        float maxDist = -1;
        foreach (var pos in roomPositions)
        {
            float dist = Vector2Int.Distance(origin, pos);
            if (dist > maxDist)
            {
                maxDist = dist;
                furthest = pos;
            }
        }
        return furthest;
    }

    List<Vector2Int> Directions()
    {
        return new List<Vector2Int> {
            Vector2Int.up, Vector2Int.down,
            Vector2Int.left, Vector2Int.right
        };
    }

    public void SwitchToRoom(Vector2Int roomPos)
    {
        if (rooms.ContainsKey(roomPos))
        {
            cameraFollow.MoveToRoom(roomPos, roomSpacing);
        }
    }
}
