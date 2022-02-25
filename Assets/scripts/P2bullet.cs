using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(movement_2P.P2flip == false){
            rb.velocity = new Vector2(speed,0);
        }
        if(movement_2P.P2flip == true){
            rb.velocity = new Vector2(-speed,0);
        }
        Invoke("die",10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "player"){
            other.gameObject.GetComponent<movement_1P>().hited(10);            
        }
        Destroy(this.gameObject);
    }
    private void die(){
        Destroy(this.gameObject);
    }
}
