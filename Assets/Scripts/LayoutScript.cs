using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutScript : MonoBehaviour
{
    public RoomManager.RoomType roomType;
    private void Start()
    {
        SetUpLayout();
    }
    public virtual void SetUpLayout()
    {

    }
}
