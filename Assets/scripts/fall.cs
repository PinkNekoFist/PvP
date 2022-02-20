using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall : MonoBehaviour
{   
    public float fallspeed;
    private string test;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    
    }
    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.tag == "player"){
            InvokeRepeating("falldown",2,1);
        }
    }
    void falldown(){
        this.transform.Translate(new Vector2(0,-fallspeed)*Time.deltaTime);
    }
}
