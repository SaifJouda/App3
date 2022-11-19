using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    //General Stats
    public float speed = 3.0f;

    //Position
    public float currentPositionX;
    public float currentPositionY;

    //rigid body
    Rigidbody2D rigidbody2d;

    //direction
    float horizontal; 
    float vertical;
    Vector2 lookDirection = new Vector2(1,0);
    
    //face direction
    bool faceRight = true;

    //animator
    Animator animator;


    
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();

        //currentHealth = maxHealth;
    }



    void FixedUpdate()
    {

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);
        
        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
                
        //animator.SetFloat("Look X", lookDirection.x);
        //animator.SetFloat("Look Y", lookDirection.y);
        //animator.SetFloat("Speed", move.magnitude);
        if(move.x!=0 || move.y!=0)
            animator.SetBool("isMoving",true);
        else
            animator.SetBool("isMoving",false);

        currentPositionX = transform.position.x;
        currentPositionY = transform.position.y;



        //Pause Game
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(Time.timeScale == 0)
                Time.timeScale = 1;
            else
                Time.timeScale = 0;
        }

        
        if(horizontal <0 && !faceRight)
            Flip();
        if(horizontal >0 && faceRight)
            Flip();



        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);

      
    }



    void Flip()
    {
        
        Vector3 currentScale = transform.localScale;
        currentScale.x*=-1;
        transform.localScale=currentScale;

        faceRight = !faceRight;
        
    }

  


}
