using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Completed;

public class InputManager : MonoBehaviour
{
    public Player player;
    
    public void MovePlayer(float hAxis, float vAxis)
    {
        if (player != null)
            player.Move(hAxis, vAxis);
    }
}
