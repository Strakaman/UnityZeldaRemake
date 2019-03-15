using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICamera : MonoBehaviour
{

    public GameObject HUD;
    public HUDHeart[] hearts;
    public int currMaxHealth = 5;
    public int maxHealth = 30;
    public Sprite fullHealthSprite;
    public Sprite halfHealthSprite;
    public Sprite emptyHealthSprite;

    // Use this for initialization
    void Start()
    {
        SetPlayerMaxHealth(14);
        UpdateHealth(7);  
    }

    // Update is called once per frame
    void Update()
    {

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
        currMaxHealth = newMaxHealth;
        int newMaxHearts = newMaxHealth / 2;
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < newMaxHearts)
            {
                hearts[i].gameObject.SetActive(true);
            }
            else
            {
                hearts[i].gameObject.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Updates health based on idea that every heart is worth 2 health
    /// 
    /// </summary>
    /// <param name="currHealth"></param>
    public void UpdateHealth(int currHealth)
    {
        int numHearts = currHealth / 2;
        bool halfHeart = (currHealth % 2) > 0;
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < numHearts)
            {
                hearts[i].mi_corazon.sprite = fullHealthSprite;
            }
            else
            {
                hearts[i].mi_corazon.sprite = emptyHealthSprite;
            }
        }
        if (halfHeart)
        {
            hearts[numHearts].mi_corazon.sprite = halfHealthSprite; //due to 0 index, numHearts = index where half heart should be

        }
    }
}
