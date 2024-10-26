using Unity.VisualScripting;
using UnityEngine;

public class FightingController : MonoBehaviour
{
   [Header("Player Movement")]
   public float moveSpeed = 5f;
   public float rotationSpeed = 10f;
   private CharacterController characterController;
   private Animator animator;

   [Header("Player Fight")]
   public float attackCooldown = 0.5f;
   public int attackDamage = 5;
   public string [] attackAnimations ={"Attack1Animation","Attack2Animation","Attack3Animation","Attack4Animation"};
   public float dodgeDistance =2f;
   private float lastataackTime;
   void Awake()
   {
    characterController = GetComponent<CharacterController>();
    animator = GetComponent<Animator>();
   }
   void Update()
   {
    PerformMovement ();
    Dodge();
;     if(Input.GetKeyDown(KeyCode.A))
     {
        AttackMehtod(0);
     }
     else if(Input.GetKeyDown(KeyCode.S))
     {
        AttackMehtod(1);
     }
      else if(Input.GetKeyDown(KeyCode.Z))
     {
        AttackMehtod(2);
     }
      else if(Input.GetKeyDown(KeyCode.X))
     {
        AttackMehtod(3);
     }
   }

   void PerformMovement (){
    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");

     Vector3 movement = new Vector3(-verticalInput,0f,horizontalInput);
     if(movement != Vector3.zero)
     {
        Quaternion targetRotation = Quaternion.LookRotation(movement);
        transform.rotation = Quaternion.Slerp(transform.rotation , targetRotation , rotationSpeed * Time.deltaTime);

        if(horizontalInput >0)
        {
            animator.SetBool("Walking", true);
        }
         else if (horizontalInput<0)
            {
               animator.SetBool("Walking", true);
            }
         else if (verticalInput!=0)
         {
            animator.SetBool("Walking", true);
         }

     }
     else 
     {
        animator.SetBool("Walking" , false);
     }

     characterController.Move(movement * moveSpeed *Time.deltaTime);

   }
   void AttackMehtod( int attackIndex)
   {
       if(Time.time - lastataackTime > attackCooldown)
       {
        animator.Play(attackAnimations[attackIndex]);

        int damage = attackDamage;
        Debug.Log("damage" + (attackIndex+1) + damage);

        lastataackTime = Time.time;

        //looping through opponents

       }
       else 
       {
        Debug.Log("Caannot perform attack yet.Cooldown time remaining.");
       }
   }
   void Dodge()
   {
    if(Input.GetKeyDown(KeyCode.D))
    {
        animator.Play("DodgeFrontAnimation");

        Vector3 dodgeDirection = transform.forward * dodgeDistance;

        characterController.Move(dodgeDirection);
    }
   }
}
