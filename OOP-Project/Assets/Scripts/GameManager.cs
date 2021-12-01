using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //ENCAPSULATION
    private int numberFlowers;
    public int NumberFlowers
    {
        get { return numberFlowers; }
        set 
        { 
            numberFlowers = value; 
            Debug.Log("Num flowers: " + numberFlowers);
        }
    }


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
