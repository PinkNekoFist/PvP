using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_2P : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float jump_force;
    private int jt = 2;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow)){
            rb.velocity = new Vector2(-speed,rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow)){
            rb.velocity = new Vector2(speed,rb.velocity.y);
        }
        else{
            rb.velocity = new Vector2(0,rb.velocity.y);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) && jt > 0){
            rb.AddForce(new Vector2(0,jump_force),ForceMode2D.Impulse);
            jt--;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "floor"){
            jt = 2;
        }
    }
}
