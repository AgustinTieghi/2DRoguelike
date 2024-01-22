using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalLayoutScript : LayoutScript
{
    [SerializeField] private List<Transform> spawnPositions;
    [SerializeField] private List<GameObject> enemies;

    public override void SetUpLayout()
    {
        foreach (Transform pos in spawnPositions)
        {
            Instantiate(enemies[Random.Range(0, enemies.Count)], pos.position, Quaternion.identity, this.transform);
        }
    }
}
