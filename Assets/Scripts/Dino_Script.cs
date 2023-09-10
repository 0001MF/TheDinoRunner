
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Dino_Script : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D player;
    // player variable 

    public  float speed; 
    // walk speed like left right 

    public float jumpspeed;
    // jump force which is req how long jump will will be

    public Transform OnGround;
    // to check is ground or not 

    bool Moving_Right = true;
    //  bool type to check the movement of the player.

   // public bool IsGrounded;         
    // bool type to check player is on ground or not.

    public LayerMask Surface;
    // to check the type of surface.

    public float radius;  
    
    Animator anim;

    private float coin;

    public TextMeshProUGUI textCoin;

    

    [SerializeField] private AudioSource JumpSoundEffect;

    [SerializeField] private AudioSource CoinCollectingEffect;
    [SerializeField] private AudioSource DeathSound;
    private bool Isjumping;

    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("IsRunning", false);
        anim.SetBool("IsJump", false);
        anim.SetBool("isidle", false);
        anim.SetBool("iswalk", false);
        anim.SetBool("IsDead", false);
    }
    private void Update()
    {
        float position = Input.GetAxisRaw("Horizontal");

        transform.Translate(position * speed * Time.deltaTime, 0f, 0f);

       // player.velocity = new Vector2(position * speed, 0);

        if (position >0 && Moving_Right == false)
        {
            Flip();
        }

        else if (position <0  && Moving_Right== true) {
     
            Flip();
        }

       

        if (Input.GetKeyDown(KeyCode.UpArrow) && !Isjumping)
        {
            player.velocity = Vector2.up * jumpspeed;
            Isjumping = true;                                   // its required to jump the player
            JumpSoundEffect.Play(); 

            
        }
      
        if (position!=0)                                       // its required to run the player
        {
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }

        if (IsGrounded())
        {
            //Debug.Log("IsGrounded");
            anim.SetBool("IsJump", false);                         // its required for jump of the player
        }
        else
        {
            Debug.Log("Is Not Grounded");
            anim.SetBool("IsJump", true);
        }

        if (position == 0)                                 // its required for idle position of the player
        {
            anim.SetBool("isidle", true);
        }
        else
        {
            anim.SetBool("isidle", false);
        }

        if (position >0) {                              // its required for walk of the player
            anim.SetBool("iswalk", true);
        }
        else
        {
            anim.SetBool("iswalk", false);
        }
    
    }

    private void OnTriggerEnter2D(Collider2D obj)      // this method is required for coin collection and destroy the coin after collection.
    {
        if (obj.gameObject.CompareTag("Coin"))

        {
            coin +=10;
            textCoin.text = coin.ToString();    
             CoinCollectingEffect.Play();
            Destroy(obj.gameObject);
        }
       
        
    }

    private void OnCollisionEnter2D(Collision2D other)

    {
       if (other.gameObject.CompareTag("Ground")){
            Isjumping = false;
        }
    }

    void Flip()
    {
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        Moving_Right = !Moving_Right;
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(OnGround.position, radius, Surface);
    }

    

    }
    

    






  