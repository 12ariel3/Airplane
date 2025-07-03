using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] GameObject healthBar;
    [SerializeField] GameObject damageHealthBar;



    public void SetHP(float normalizedValue){
        healthBar.transform.localScale = new Vector3(normalizedValue, 1.0f);
    }

    public void SetDamageHP(float normalizedValue){
        damageHealthBar.transform.localScale = new Vector3(normalizedValue, 1.0f);
    }
}
