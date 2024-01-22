using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class LevelGeneration : MonoBehaviour
{
    [SerializeField] private GameObject room;
    [SerializeField] private GameObject spawnedRoom;
    [SerializeField] private int levelQNT;
    public List<Vector3> usedPositions = new List<Vector3>();
    private List<GameObject> generatedRooms = new List<GameObject>();
    public static LevelGeneration instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        for (int i = 0; i < levelQNT; i++)
        {
            Vector3 spawnPos;

            if (i == 0)
            {
                spawnPos = Vector3.zero;
            }
            else
            {
                spawnPos = PickRoomPos(spawnedRoom);
            }
    
            spawnedRoom = Instantiate(room, spawnPos, Quaternion.identity);
            usedPositions.Add(spawnedRoom.transform.position);
            generatedRooms.Add(spawnedRoom);

            if(i == levelQNT - 1)
            {
                spawnedRoom.GetComponent<RoomManager>().type = RoomManager.RoomType.Boss;
            }
        }
    }

    void Start()
    {
        int rnd = Random.Range(1, generatedRooms.Count);
        generatedRooms[rnd].GetComponent<RoomManager>().type =  RoomManager.RoomType.Treasure;
        generatedRooms[0].GetComponent<RoomManager>().type = RoomManager.RoomType.Spawn;
    }

    Vector3 PickRoomPos(GameObject selectedRoom)
    {
        Vector3 xPos = new Vector3(7, 0, 0);
        Vector3 yPos = new Vector3(0, 5, 0);

        List<Vector3> possiblePositions = new List<Vector3>
        {
            xPos,
            -xPos,
            yPos,
            -yPos
        };

        int rnd = Random.Range(0, possiblePositions.Count);
        if(usedPositions.Count > 0)
        {
            foreach (Vector3 pos in usedPositions)
            {
                while (pos == selectedRoom.transform.position + possiblePositions[rnd])
                {
                    rnd = Random.Range(0, possiblePositions.Count);                    
                }
            }
        }
        
        Vector3 selectedPos = selectedRoom.transform.position + possiblePositions[rnd];
        return selectedPos;
    }
}
