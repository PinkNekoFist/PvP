using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall : MonoBehaviour
{   
    public float fallspeed;
    private Rigidbody2D rb;
    private bool destroy;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= -5 && destroy == false){
            destroy = true;
            Invoke("I",10);
        }
    }
    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.tag == "player"){
            Invoke("falldown",2);
        }
    }
    void falldown(){
        rb.isKinematic = false;
        rb.constraints = RigidbodyConstraints2D.None;
    }
    void I(){
        //destroy = true;
        rb.isKinematic = true;
        Instantiate(this.gameObject, new Vector2(transform.position.x, -2), Quaternion.identity);
        D();
        destroy = true;
    }
    void D(){
        Destroy(this.gameObject);
    }
   
}
