using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Use this for initialization
    public static GameManager instance;
    public AudioClip[] randomMusic;

    [SerializeField] 
    private bool debugPlayMusic = true;
    void Awake()
    {
        //mainCamBrain = GetComponentInChildren<CinemachineBrain>();
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        if (AudioManager.instance != null && debugPlayMusic)
        {
            AudioManager.instance.PlayMusic(randomMusic[Random.Range(0, randomMusic.Length)]);
        }
    }
}
