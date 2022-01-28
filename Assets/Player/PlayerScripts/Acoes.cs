using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acoes : MonoBehaviour
{
    private Animator animator;
    
    private int playerID;

    void Awake(){
        animator = gameObject.GetComponent<Info>().animator;
        playerID = gameObject.GetComponent<Info>().playerID;
    }


    void OnEnable(){
        Metronome.OnMetronomeTick += ExecuteAction;
    }

    void OnDisable(){
        Metronome.OnMetronomeTick += ExecuteAction;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Basico" + this.playerID)){
            Uppercut();
        };
    }

    //Evento de tick do metronomo
    public void ExecuteAction(){
        transform.Find("Body").GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value);
    }


    //Ataques
    public void Uppercut(){
        animator.SetTrigger("Uppercut");
    }
}
