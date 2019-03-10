using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICamera : MonoBehaviour {

    public GameObject HUD;
    public HUDHeart[] hearts;
    public int currMaxHealth = 5;
    public int maxHealth = 30;
    public Sprite fullHealthSprite;
    public Sprite halfHealthSprite;
    public Sprite emptyHealthSprite;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void HideHUD()
    {
        HUD.SetActive(false);
    }

    public void ShowHUD()
    {
        HUD.SetActive(true);
    }

    public void SetPlayerMaxHealth(int newMaxHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < newMaxHealth)
            {
                hearts[i].gameObject.SetActive(true);
            }
            else
            {
                hearts[i].gameObject.SetActive(false);
            }
        }
    }

    public void UpdateHealth(int currHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currHealth)
            {
            }
            else
            {
            }
        }
    }
}
