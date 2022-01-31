using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entrou : MonoBehaviour
{
    Animator animator;
 
    private void Start()
    {   
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow) && collision.CompareTag("leftArrow"))
        {
            this.animator.Play("correctStrike");
            Destroy(collision.gameObject);        
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && collision.CompareTag("rightArrow"))
        {
            this.animator.Play("correctStrike");
            Destroy(collision.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && collision.CompareTag("upArrow"))
        {
            this.animator.Play("correctStrike");
            Destroy(collision.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && collision.CompareTag("downArrow"))
        {
            this.animator.Play("correctStrike");
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow) && collision.CompareTag("leftArrow"))
        {
            this.animator.Play("correctStrike");
            Destroy(collision.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && collision.CompareTag("rightArrow"))
        {
            this.animator.Play("correctStrike");
            Destroy(collision.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && collision.CompareTag("upArrow"))
        {
            this.animator.Play("correctStrike");
            Destroy(collision.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && collision.CompareTag("downArrow"))
        {
            this.animator.Play("correctStrike");
            Destroy(collision.gameObject);
        }
    }
}
