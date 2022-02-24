using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firepointpositionP2 : MonoBehaviour
{
    public float Xposition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(movement_2P.P2flip == true){
            transform.localPosition = new Vector2(-Xposition,0);
        }
        if(movement_2P.P2flip == false){
            transform.localPosition = new Vector2(Xposition,0);
        }
    }
}
