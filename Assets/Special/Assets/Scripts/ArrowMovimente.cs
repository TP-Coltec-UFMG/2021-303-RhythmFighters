using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovimente : MonoBehaviour
{
    [SerializeField]
    public float speed = 5f;
    Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = -1;
        body.velocity = new Vector2( 0, speed * move);
    }
}
