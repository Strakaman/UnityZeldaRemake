using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


static class GameData
{
    private static GameObject player;
    public static GameObject playerRefObj
    {
        get
        {
            if (player == null)
            {
            if (GameObject.FindObjectOfType<Player>() != null)
            {
                player = GameObject.FindObjectOfType<Player>().gameObject;
            }
            }
            return player;
        }
        set { player = value; }
    }

    public static void RegisterPlayerObj(GameObject go)
    {
        playerRefObj = go;
    }

    public static Vector2 leftVector = new Vector2(-1, 0);
    public static Vector2 rightVector = new Vector2(1, 0);
    public static Vector2 upVector = new Vector2(0, 1);
    public static Vector2 downVector = new Vector2(0, -1);
}

