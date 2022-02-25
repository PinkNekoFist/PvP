using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_2P : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jump_force,HP,reactspeed,speed;
    private float rats;
    public static bool P2flip;
    private SpriteRenderer sp;
    public GameObject P2bullet;
    public Transform P2firepoint;
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
        if(Input.GetKey(KeyCode.LeftArrow)){
            if(rats<=0){
                rb.velocity = new Vector2(-speed,rb.velocity.y);
                P2flip = true;
                sp.flipX = true;
            }            
        }
        else if(Input.GetKey(KeyCode.RightArrow)){
            if(rats<=0){
                rb.velocity = new Vector2(speed,rb.velocity.y);
                P2flip = false;
                sp.flipX = false;
            }            
        }        
        else if(Input.GetKeyUp(KeyCode.LeftArrow)||Input.GetKeyUp(KeyCode.RightArrow)){
            rb.velocity = new Vector2(0,rb.velocity.y);
        }
        
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, Ground);
        if(isGrounded == true){
            ejt = ExtraJumpTimes;
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) && ejt > 0){
            rb.velocity = new Vector2(rb.velocity.x, jump_force);
            ejt--;
        }
        else if(Input.GetKey(KeyCode.UpArrow) && ejt == 0 && isGrounded == true){
            rb.velocity = new Vector2(rb.velocity.x, jump_force);
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            Instantiate(P2bullet,P2firepoint.position,Quaternion.identity);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "bullet"){
            rb.AddForce(new Vector2(0,3),ForceMode2D.Impulse);
            rats = reactspeed;
        }
    }
    public void hited(float damage){
        HP -= damage;
    }
}
