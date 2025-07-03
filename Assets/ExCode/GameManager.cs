using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public TextMeshProUGUI CreditsUI;
    private int credits;
    public int Credits{
        get => credits;
        set => credits = value;
    }

    public TextMeshProUGUI creditsObtainedUI;
    private int creditsObtained;
    public int CreditsObtained{
        get => creditsObtained;
        set => creditsObtained = value;
    } 

    public TextMeshProUGUI totalCreditsUI;
    private int totalCredits;
    public int TotalCredits{
        get => totalCredits;
        set => totalCredits = value;
    }


    public TextMeshProUGUI totalGemsUI;
    private int totalGems;
    public int TotalGems{
        get => totalGems;
        set => totalGems = value;
    }


    

    public GameObject rewardCanvas;
    public GameObject gameplayHUD;

    public bool gameOver;
    
    
    private void Awake() {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver){

        }
        
    }
}
