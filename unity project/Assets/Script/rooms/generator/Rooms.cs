using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms : MonoBehaviour {

    public Vector2 Pos;
    public int typeRoom;

    public Rooms(Vector2 newPos, int newType)
    {
        Pos = newPos;
        typeRoom = newType;
    }
}
