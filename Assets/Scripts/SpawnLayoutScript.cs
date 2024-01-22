using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLayoutScript : LayoutScript
{
    [SerializeField] private GameObject player;

    public override void SetUpLayout()
    {
        Instantiate(player, this.transform.position, Quaternion.identity);
    }     
}
