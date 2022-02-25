using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_1P : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float jump_force,HP,reactspeed;
    private float rats;
    private SpriteRenderer sp;
    public GameObject P1bullet;
    public Transform P1firepoint;
    public static bool P1flip;
    private bool isGrounded;
    public Transform GroundCheck;
    public float CheckRadius;
    public LayerMask Ground;
    public int ExtraJumpTimes;
    private int ejt;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        rats = reactspeed;
        ejt = ExtraJumpTimes;
    }

    // Update is called once per frame
    void Update()
    {
        rats-=Time.deltaTime;
        if(Input.GetKey(KeyCode.A)){
            if(rats<=0){
                rb.velocity = new Vector2(-speed,rb.velocity.y);
                P1flip = true;
                sp.flipX = true;
            } 
        }
        else if (Input.GetKey(KeyCode.D)){
           if(rats<=0){
                rb.velocity = new Vector2(speed,rb.velocity.y);
                P1flip = false;
                sp.flipX = false;
            }
        }
        else if(Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.D)){
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
        if(Input.GetKeyDown(KeyCode.S)){
            Instantiate(P1bullet,P1firepoint.position,Quaternion.identity);
        }
    }
    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "bullet"){
            rats = reactspeed;
            rb.AddForce(new Vector2(0,3),ForceMode2D.Impulse);
        }
    }
    public void hited(float damage){
        HP -= damage;
    }
}
