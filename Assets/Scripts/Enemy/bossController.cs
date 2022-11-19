using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossController : MonoBehaviour
{
    public float speed=1.0f;
    //public bool vertical=false;
    //public float changeTime = 2.0f;
    private GameObject player;

    public float playerSpotDistance=15f;

    public GameObject projectileGameObject;
    public GameObject bossSummon;

    Rigidbody2D rigidbody2D;
    //float timer;
    bool broken = true;
    
    float difX;
    float difY;
    float difXpos, difYpos;

    Animator animator;


    //face direction
    bool faceRight = true;

    //attack
    public Transform attackPoint;
    public float attackRange = 5.0f;
    public LayerMask playerLayer;
    public int Damage=-1; //Value must be negative
    //Attack Cooldown
    private float attackCooldown = 4.0f;
    bool isAttackCooldown;
    float attackCooldownTimer;

    private float spawnCooldown = 9.0f;
    public bool isSpawnCooldown;
    public float spawnCooldownTimer;

    //Direction to player
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player=GameObject.Find("Player");
        isAttackCooldown=true;
        attackCooldownTimer=attackCooldown;

        isSpawnCooldown=true;
        spawnCooldownTimer=spawnCooldown;
    }

    void Update()
    {
        
        if (player != null)
        {
            difX=player.transform.position.x-attackPoint.transform.position.x;
            difY=player.transform.position.y-attackPoint.transform.position.y;
            direction = new Vector2(difX,difY);
            attackPoint.transform.up=direction;
        }

        
    }
    
    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;
        
        int horizontal=0;
        int vertical=0;

        //only follow player when in range
        difXpos=difX;
        difYpos=difY;
        if(difXpos<0)
            difXpos=difXpos*-1;
        if(difYpos<0)
            difYpos=difYpos*-1;
        if(difXpos<playerSpotDistance && difYpos<playerSpotDistance)
        {
            //Debug.Log(difX);
            if(difX>attackRange)
                horizontal=1;
            else if(difX<-attackRange)
                horizontal=-1;
            else
                horizontal=0;

            if(difY>attackRange)
                vertical=1;
            else if(difY<-attackRange)
                vertical=-1;
            else
                vertical=0;
        }

        if(player!=null && difX<=attackRange && difX>=-attackRange && difY<=attackRange && difY>=-attackRange ) 
        {
            if(isSpawnCooldown==false)
                {Spawn();}
            else if(isAttackCooldown==false)
                {Attack();}
        }

        if(horizontal!=0 || vertical!=0)
        {
            animator.SetBool("isMoving",true);
        }
        else
        {
            animator.SetBool("isMoving",false);
        }

        //Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2D.MovePosition(position);

        if(horizontal <0 && !faceRight)
            Flip();
        if(horizontal >0 && faceRight)
            Flip();

        if (isAttackCooldown)
        {
            attackCooldownTimer -= Time.deltaTime;
            if (attackCooldownTimer <= 0)
                isAttackCooldown = false;
        }

        if(isSpawnCooldown)
        {
            spawnCooldownTimer -= Time.deltaTime;
            if(spawnCooldownTimer <=0)
                isSpawnCooldown = false;
        }
        
    }


    void Attack()
    {
        //Attack animation
        animator.SetTrigger("attack");

        GameObject projectileObject = Instantiate(projectileGameObject, attackPoint.transform.position,attackPoint.transform.rotation);

        //Projectile projectile = projectileObject.GetComponent<projectile>();
        Vector2 launchDirection = attackPoint.transform.up; //= new Vector2(attackPoint.transform.position.x,attackPoint.transform.position.y);
        //Vector2 launchDirection = new Vector2(1,0);

        projectileObject.GetComponent<projectile>().Launch(launchDirection);

        //        Instantiate(projectileGameObject, attackPoint.transform.position, attackPoint.transform.rotation);

        isAttackCooldown=true;
        attackCooldownTimer=attackCooldown;
    }

    void Spawn()
    {
        animator.SetTrigger("summon");

        Instantiate(bossSummon, attackPoint.transform.position,Quaternion.identity);

        isAttackCooldown=true;
        attackCooldownTimer=attackCooldown;

        isSpawnCooldown=true;
        spawnCooldownTimer=spawnCooldown;
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
        Gizmos.DrawWireSphere(attackPoint.position,playerSpotDistance);
    }

    void Flip()
    {
        
        Vector3 currentScale = transform.localScale;
        currentScale.x*=-1;
        transform.localScale=currentScale;

        faceRight = !faceRight;
        
    }
}
