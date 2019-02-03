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
}

