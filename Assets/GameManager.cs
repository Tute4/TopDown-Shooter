using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int rondaActual = 1; 
    public Text roundText; 

    void Start()
    {
        UpdateRoundText(); 
    }

    
    void UpdateRoundText()
    {
        if (roundText != null)
        {
            roundText.text = "Ronda: " + rondaActual.ToString();
        }
    }

    
    public void RondaCompletada()
    {
        rondaActual++; 
        UpdateRoundText(); 
    }
    void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            
            Destroy(gameObject);
        }

        
        DontDestroyOnLoad(gameObject);
    }
}

