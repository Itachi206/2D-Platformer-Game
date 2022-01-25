using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    
    public Animator playeranimator;
    private Rigidbody2D rbd2d; 
    public float speed; 
    public float jumpVertical;
    
    private Vector3 respawnPoint;
    public GameObject fallDetector;
   
    public bool isGrounded = false;

    public ScoreController scoreController;

    public void killPlayer()
    {
        Debug.Log("GAME OVER");
        //Destroy(gameObject); 
        playeranimator.SetTrigger("DeathTrigger");
        ReloadLevel();
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene("Restart");
    }

    //public bool deathtrigger = false;

    private void Awake(){ 
        rbd2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void start()
    {
        respawnPoint = transform.position;
    }
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");  
        float vertical = Input.GetAxisRaw("Jump");
        bool crouch = Input.GetKeyDown(KeyCode.LeftControl);
        
        MoveCharacter(horizontal, vertical); 
        PlayerMovementAnimation(horizontal); 
        playerJumpAnimation(vertical);
        PlayerCrouchAnimation(crouch);        

    }

    private void MoveCharacter(float horizontal, float vertical){
        Vector3 position = transform.position;
        //(distance / time)  * (1 / frames per second) 
        position.x += horizontal * speed * Time.deltaTime;       
        transform.position = position;         

        if(vertical > 0 && isGrounded == true)
        {
            //rbd2d.AddForce(new Vector2(0,jumpVertical)); 
           // rbd2d.transform 
          
            // position.y += jumpVertical * Time.deltaTime;   // it will only change the position of player .. player will  not go up just fall from the position
            // transform.position = position;      

            rbd2d.velocity = new Vector2(rbd2d.velocity.x, jumpVertical);
            playeranimator.SetTrigger("Jumptrigger");
        }

        fallDetector.transform.position = new Vector2(rbd2d.transform.position.x, fallDetector.transform.position.y);   // it will move the gameover platform with player
    }
   
    private void PlayerMovementAnimation(float horizontal)
    {   
        playeranimator.SetFloat("Speed", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;

        if(horizontal < 0){
            scale.x = -1f * Mathf.Abs(scale.x);
        } else if(horizontal > 0){
            scale.x = Mathf.Abs(scale.x);
        }         
        transform.localScale = scale;        
    }

    private void playerJumpAnimation(float vertical)
    {
        if(vertical > 0)
        {
            playeranimator.SetBool("Jump", true);
        } else
        {
            playeranimator.SetBool("Jump", false);
        }
    }

    private void PlayerCrouchAnimation(bool crouch)
    {
        if(crouch)
        {
            playeranimator.SetBool("Crouch", true);
        } else
        {
            playeranimator.SetBool("Crouch", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "gameover")
        {
            playeranimator.SetTrigger("DeathTrigger");
            killPlayer();

        }
    }

    public void pickup()
    {
        Debug.Log("Player score 10 points");
        scoreController.IncreaseScore(10);
    }

}
