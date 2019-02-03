using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


static class GameData
{
    public static GameObject playerRefObj;

    public static void RegisterPlayerObj(GameObject go)
    {
        playerRefObj = go;
    }
}

