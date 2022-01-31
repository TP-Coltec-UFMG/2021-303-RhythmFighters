using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
    public Animator animator;
    
    [Range (1, 2)]
    public int playerID = 1;
    public float playerHealth = 100.0f;
    public Slider UI_playerHealth;

    void Start(){
        UI_playerHealth.maxValue = this.playerHealth;
        UI_playerHealth.value = this.playerHealth;
    }

    void Update(){
        UI_playerHealth.value = this.playerHealth;
    }


    public void Damage(float dmg){
        this.playerHealth -= dmg;
    }
}
