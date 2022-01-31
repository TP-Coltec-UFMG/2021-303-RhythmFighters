using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acoes : MonoBehaviour
{
    private Info info;
    private Movimento movimento;

    [SerializeField]
    private int iframe = 0;

    void Awake(){
        info = gameObject.GetComponent<Info>();
        movimento = gameObject.GetComponent<Movimento>();
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
        if (this.iframe > 0) {
            iframe --;
        }

        if (Input.GetButton("Basico" + this.info.playerID) && movimento.IsGrounded() && movimento.canMove == true){
            Uppercut();
        }
    }

    //Evento de tick do metronomo
    public void ExecuteAction(){
        //transform.Find("Body").GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value);
    }


    //Ataques
    public void Uppercut(){
        movimento.canMove = false;
        this.info.animator.SetTrigger("Uppercut");
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.layer == LayerMask.NameToLayer("Attack") && this.iframe == 0){
            GameObject preferredHit = null;

            var allCollisions = new Collider2D[6];
            var filter = new ContactFilter2D();
            filter.SetLayerMask(LayerMask.GetMask("Attack"));
            filter.useTriggers = true;

            this.GetComponent<Collider2D>().OverlapCollider(filter,allCollisions);
            foreach (Collider2D collision in allCollisions){
                if (collision != null){
                    var currHit = collision.gameObject;

                    if (preferredHit == null || preferredHit.GetComponent<ColliderScript>().priority < currHit.GetComponent<ColliderScript>().priority){
                        preferredHit = currHit;
                    }
                }
            }
            ColliderScript hitInfo = preferredHit.GetComponent<ColliderScript>();
            var knockbackDirection = new Vector2(hitInfo.knockbackDirection.x * preferredHit.GetComponentInParent<Movimento>().lookDirection, hitInfo.knockbackDirection.y);
            receiveDamage(hitInfo.damage, knockbackDirection, hitInfo.knockbackStrength, hitInfo.iframeDur);
            //Debug.Log(this.gameObject);
        }
    }

    private void receiveDamage(float damage, Vector2 knockbackDirection, float knockbackStrength, int iframeDur){
        this.info.Damage(damage);
        this.movimento.Impulse(knockbackDirection, knockbackStrength);
        this.iframe = iframeDur;
    } 
}
