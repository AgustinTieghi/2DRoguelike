using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> doors = new List<GameObject>();
    [SerializeField] private List<GameObject> layouts = new List<GameObject>();
    private List<GameObject> chosenLayouts = new List<GameObject>();

    public enum RoomType
    {
        Normal,
        Boss,
        Treasure,
        Spawn
    }
    public RoomType type;
    void Start()
    {
        CheckAbjacentRooms();
        ChooseLayout(type);
        int rnd = Random.Range(0, chosenLayouts.Count);
        Instantiate(chosenLayouts[rnd], this.transform.position, Quaternion.identity, this.transform);
    }

    void ChooseLayout(RoomType type)
    {       
        foreach (GameObject layout in layouts)
        {
            if(layout.GetComponent<LayoutScript>().roomType == type)
            {
                chosenLayouts.Add(layout);
            }
        }
    }
    void CheckAbjacentRooms()
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

        if (LevelGeneration.instance.usedPositions.Count > 0)
        {
            foreach (Vector3 pos in LevelGeneration.instance.usedPositions)
            {
                for (int i = 0; i < possiblePositions.Count; i++)
                {
                    if (this.transform.position + possiblePositions[i] == pos)
                    {
                        doors[i].SetActive(false);
                    }
                }
            }
        }
    }

}
