using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private float manaAmount = 100;
    private Animator playerAnimatror;
    private Health myHealth;
    private CharacterController NinjaController;

    private bool moveRight = false;
    private bool moveLeft = false;
    private bool isAlive = true;
    private bool flyButton = true;

    public float flySpeed;
    public Image manaImage;
    public Vector3 Dir;


    // Start is called before the first frame update
    void Start()
    {
        playerAnimatror = GetComponent<Animator>();
        NinjaController = GetComponent<CharacterController>();
        myHealth = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {

        if (myHealth.isAlive)
        {
            if (Input.GetKey("d"))
                moveRight = true;
            else
            {
                moveRight = false;
                if (Input.GetKey("a"))
                    moveLeft = true;
                else
                {
                    moveLeft = false;
                    playerAnimatror.SetBool("Go", false);
                }

            }
            if (Input.GetKey("w"))
                flyButton = true;
            else flyButton = false;

        }
        else
           NinjaController.enabled = false;
    }
    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        Fly();
        if (moveRight)
            MoveRight();
        else if (moveLeft)
            MoveLeft();
    }
    private void MoveRight()
    {
        if (NinjaController.isGrounded)
        {
            playerAnimatror.applyRootMotion = true;
            FlipCharacterSide("right");

            playerAnimatror.SetBool("Go", true);                      
        }
    }

    private void MoveLeft()
    {
        if (NinjaController.isGrounded)
        {
            
                playerAnimatror.applyRootMotion = true;
                FlipCharacterSide("left");
                playerAnimatror.SetBool("Go", true);
           

        }
    }

    IEnumerator Wait(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        playerAnimatror.SetBool("Attack", false);

    }

    private void Fly()
    {

        float speed = 5f * Time.fixedDeltaTime;

        if (flyButton)
            if (manaAmount > 0)
            {
                playerAnimatror.applyRootMotion = false;
                Vector3 dir = new Vector3(0, flySpeed * Time.fixedDeltaTime, 0);
                NinjaController.Move(dir);
                manaAmount = manaAmount - 80 * Time.fixedDeltaTime;
                manaImage.fillAmount = manaAmount / 100;
            }
            else playerAnimatror.applyRootMotion = true; 

        if (!NinjaController.isGrounded) // player can be in the air during fall;
        {       
            Vector3 moveDirection = Vector3.zero;
            playerAnimatror.SetBool("Fly", true);
            if (moveRight)
            {
                FlipCharacterSide("right");
                moveDirection.x = 3 * Time.fixedDeltaTime;
                NinjaController.Move(moveDirection);


            }
            else if (moveLeft)
            {
                FlipCharacterSide("left");
                moveDirection.x = -3 * Time.fixedDeltaTime;
                NinjaController.Move(moveDirection);
            }
        }
        
        if (!flyButton)
        {
            
            if (!NinjaController.isGrounded)// If player in the air
            playerAnimatror.applyRootMotion = true;

            if (NinjaController.isGrounded)
            {    
                playerAnimatror.applyRootMotion = true;
                playerAnimatror.SetBool("Fly", false);
                if (manaAmount < 100)
                    manaAmount = manaAmount + 50 * Time.fixedDeltaTime;
            }
            manaImage.fillAmount = manaAmount/100 ;

        }



    }
    private void FlipCharacterSide(string side)
    {
        if (side == "right")
        {
            if (transform.rotation.eulerAngles.y != 90)
            {
                transform.localRotation = Quaternion.Euler(0, 90, 0);   //change to global/local rotation relative to unity north
            }
        }
        else if (side == "left")
        {
            if (transform.rotation.eulerAngles.y != -90)
            {
                transform.localRotation = Quaternion.Euler(0, -90, 0);      //change to global/local rotation relative to unity north
            
            }
            
        }
        
    }

}
/*      FlipCharacterSide("right");
                moveDirection = new Vector3(0, 0, speed);
                transform.Translate(moveDirection);
                MageController.enabled = false;
*/
