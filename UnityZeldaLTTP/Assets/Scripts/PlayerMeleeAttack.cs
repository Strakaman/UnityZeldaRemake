using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collInfo)
    {
        if (collInfo.gameObject.layer.Equals(ProjectTagStrings.ENEMY_LAYER))
        {
            Debug.Log("looks like an enemy is about to be hit");
        }
        else
        {
            Debug.Log("ok guess not: " + collInfo.gameObject.layer);
        }
    }

}
