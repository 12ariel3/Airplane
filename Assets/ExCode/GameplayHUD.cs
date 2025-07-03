using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameplayHUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI lifeUI;
    [SerializeField] HealthBar healthBar;

    [SerializeField] TextMeshProUGUI expUI;

    [SerializeField] TextMeshProUGUI creditsUI;
    





    public void SetHUDHP(Plane plane){
        lifeUI.text = plane.Life.ToString();
        healthBar.SetHP(plane.Life/plane.TotalLife);
    }

    public void setHUDEXP(Plane plane){

    }

    public void setHUDCredits(Plane plane){

    }
}
