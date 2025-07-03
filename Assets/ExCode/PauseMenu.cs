using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused;

    public void Resume(){
        Time.timeScale = 1f;
        gameIsPaused = false;
    }


    public void Pause(){
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    
}
