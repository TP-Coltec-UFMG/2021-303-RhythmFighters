using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishAttack : MonoBehaviour
{
    private Movimento movimento;

    void Awake(){
        movimento = gameObject.GetComponentInParent<Movimento>();
    }

    public void setCanMove(){
        this.movimento.canMove = true;
    }
}
