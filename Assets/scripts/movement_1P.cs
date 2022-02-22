using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_1P : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float jump_force;
    private bool isGrounded;
    public Transform GroundCheck;
    public float CheckRadius;
    public LayerMask Ground;
    public int ExtraJumpTimes;
    private int ejt;
    // Start is called before the first frame update
    void Start()
    {
        ejt = ExtraJumpTimes;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A)){
            rb.velocity = new Vector2(-speed,rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D)){
            rb.velocity = new Vector2(speed,rb.velocity.y);
        }
        else{
            rb.velocity = new Vector2(0,rb.velocity.y);
        }
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, Ground);
        if(isGrounded == true){
            ejt = ExtraJumpTimes;
        }
        if(Input.GetKeyDown(KeyCode.W) && ejt > 0){
            rb.velocity = new Vector2(rb.velocity.x, jump_force);
            ejt--;
        }
        else if(Input.GetKey(KeyCode.W) && ejt == 0 && isGrounded == true){
            rb.velocity = new Vector2(rb.velocity.x, jump_force);
        }
    }
}
