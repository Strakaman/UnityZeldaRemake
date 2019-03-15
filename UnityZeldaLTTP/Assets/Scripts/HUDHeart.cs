using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDHeart : MonoBehaviour
{

    public Image mi_corazon;

    void Awake()
    {
        mi_corazon = GetComponent<Image>();
    }

}
