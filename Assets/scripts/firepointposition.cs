using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firepointposition : MonoBehaviour
{
    // Start is called before the first frame update
    public float Xposition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(movement_1P.P1flip == true){
            transform.localPosition = new Vector2(-Xposition,0);
        }
        if(movement_1P.P1flip == false){
            transform.localPosition = new Vector2(Xposition,0);
        }
    }
}
