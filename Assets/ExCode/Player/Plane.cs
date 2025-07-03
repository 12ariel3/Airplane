using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Plane : MonoBehaviour
{
    
    private int totalLife = 100;
    public int TotalLife{
        get => totalLife;
        set => totalLife = value;
    }

    
    private int life;
    public int Life{
        get => life;
        set => life = value;
    }


   

    // Start is called before the first frame update
    void Start()
    {   
        life = totalLife;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    // public IEnumerator Dead(){
    //     if(!GameManager.Instance.gameOver){
    //         if(life <= 1){
    //             life--;
    //             GameManager.Instance.gameOver = true;
    //             cameraFollow.UnFollow();
    //             rb2D.isKinematic = false;
    //             yield return new WaitForSeconds(1f);
    //             GameManager.Instance.rewardCanvas.SetActive(true);
    //             GameManager.Instance.gameplayHUD.SetActive(false);
    //             GameManager.Instance.CreditsObtained = GameManager.Instance.Credits;
    //             GameManager.Instance.creditsObtainedUI.text = GameManager.Instance.Credits.ToString();
    //         }else{
    //             life--;
    //         }
    //     }
    // }
}
