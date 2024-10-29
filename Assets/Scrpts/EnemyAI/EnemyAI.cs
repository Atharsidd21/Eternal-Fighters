using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemyAI : MonoBehaviour
{
 [Header("Opponent Movement")]
   public float moveSpeed = 5f;
   public float rotationSpeed = 10f;
  public  CharacterController characterController;
   public Animator animator;

   [Header("Opponent Fight")]
   public float attackCooldown = 0.5f;
   public int attackDamage = 5;
   public string [] attackAnimations ={"Attack1Animation","Attack2Animation","Attack3Animation","Attack4Animation"};
   public float dodgeDistance =2f;
   public int attackCount =0;
   public int RandomNumer;
   public float AttackRadius = 2f;
   public FightingController[] fightingController;
   public Transform[] players;
   public bool isTakingDamage;
   private float lastataackTime;

   [Header("Effects and Sounds")]
    public ParticleSystem attack1Effect;
    public ParticleSystem attack2Effect;
    public ParticleSystem attack3Effect;
    public ParticleSystem attack4Effect;
    public AudioClip[] HitSounds;
    [Header("Health")]
    public int maxHealth = 100;
    public int currentHealth;
     public HealthBar healthbar;

    void Awake()
    {
      currentHealth = maxHealth;
        healthbar.GiveFullHealth(currentHealth);
      CreateRandomNumber();
    }
    void Update()
    {
      //if (attackCount == RandomNumer)
      //{
        //attackCount =0;
        //CreateRandomNumber();
      //}
       for( int i=0 ; i < fightingController.Length; i++)
       {
        if(players[i].gameObject.activeSelf && Vector3.Distance(transform.position , players[i].position) <= AttackRadius)
        {
           animator.SetBool("Walking",false);
           if(Time.time - lastataackTime >attackCooldown)
           {
               int randomAttackIndex = Random.Range(0,attackAnimations.Length);
               if(!isTakingDamage)
               {
                  AttackMehtod(randomAttackIndex);
               }
               //play damage  animation 
               fightingController[i].StartCoroutine(fightingController[i].PlayHitDamageAnimation(attackDamage));
           }
        }
        else
        {

        if(players[i].gameObject.activeSelf)
        {
            Vector3 direction =(players[i].position - transform.position).normalized;
            characterController.Move(direction* moveSpeed * Time.deltaTime);

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation , targetRotation , rotationSpeed  * Time.deltaTime);

            animator.SetBool("Walking" , true);
        }
        }
    }
   
    }

    void AttackMehtod( int attackIndex)
   {
        animator.Play(attackAnimations[attackIndex]);
        int damage = attackDamage;
        Debug.Log("damage" + (attackIndex+1) + damage);
        lastataackTime = Time.time;
   }
    void Dodge()
   {
    
        animator.Play("DodgeFrontAnimation");

        Vector3 dodgeDirection = -transform.forward * dodgeDistance;

        characterController.SimpleMove(dodgeDirection);
    
   }

    void CreateRandomNumber()
    
    {
       RandomNumer = Random.Range(1,5);
    }
    
   public IEnumerator PlayHitDamageAnimation(int takeDamage)
   {
      yield return new WaitForSeconds(0.3f);
      //hit sounds
      if (HitSounds != null && HitSounds.Length>0)
      {
         int randomIndex = Random.Range(0,HitSounds.Length);
         AudioSource.PlayClipAtPoint(HitSounds[randomIndex],transform.position);
      }
       
      //heath decrease
      currentHealth -= takeDamage;
         healthbar.SetHealth(currentHealth);
      if (currentHealth <=0)
      {
         Die();
      }

      animator.Play("HitDamageAnimation");
   }
   void Die()
   {
      Debug.Log("Mar Gya BC");
   }

    public void Attack1Effect()
   {
      attack1Effect.Play();
   }
   public void Attack2Effect()
   {
      attack2Effect.Play();
   }
   public void Attack3Effect()
   {
      attack3Effect.Play();
   }
   public void Attack4Effect()
   {
      attack4Effect.Play();
   }

}
      
         
       
      





       
       

