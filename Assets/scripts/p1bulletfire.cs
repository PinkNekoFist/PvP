using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1bulletfire : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(movement_1P.P1flip == false){
            rb.velocity = new Vector2(speed,0);
        }
        if(movement_1P.P1flip == true){
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
            other.gameObject.GetComponent<movement_2P>().hited(10);
            
        }
        Destroy(this.gameObject);
    }
    private void die(){
        Destroy(this.gameObject);
    }
}
