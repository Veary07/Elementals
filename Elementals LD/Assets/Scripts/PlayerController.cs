using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int playerNumber = 1;

    public GunController gun;

    private Rigidbody rb;
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Vector3 playerDirection;

    private float rayLenght;
    private float moveSpeed;
    [SerializeField] private float startingMoveSpeed = 25.0F;


    #region DashMove
    [SerializeField] private float dashSpeed = 75.0f;
    [SerializeField] private float dashCoolDown = 2f;
    private bool canDash = true;


    #endregion


    float leftStickX;
    float leftStickY;

    void Start()
    {
        moveSpeed = startingMoveSpeed;
        rb = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (playerNumber ==1)
        {
            if (Input.GetKeyDown("joystick 1 button 0") && canDash) 
            {
                StartCoroutine(DashMove());
            }
            moveInput = new Vector3(Input.GetAxisRaw("HorizontalP"), 0f, Input.GetAxisRaw("VerticalP"));
        }


        else if (playerNumber == 2)
        {
            if (Input.GetKeyDown("joystick 2 button 0") && canDash)
            {
                StartCoroutine(DashMove());
            }
            moveInput = new Vector3(Input.GetAxisRaw("HorizontalP 2"), 0f, Input.GetAxisRaw("VerticalP 2"));
        }


        else if (playerNumber == 3)
        {
            moveInput = new Vector3(Input.GetAxisRaw("HorizontalP 3"), 0f, Input.GetAxisRaw("VerticalP 3"));
        }


        else if (playerNumber == 4)
        {
            moveInput = new Vector3(Input.GetAxisRaw("HorizontalP 4"), 0f, Input.GetAxisRaw("VerticalP 4"));
        }

        

        moveVelocity = moveInput * moveSpeed;


        //rotate with controller

            if (playerNumber == 1)
            {
                playerDirection = Vector3.right * Input.GetAxisRaw("HorizontalR") + Vector3.forward * Input.GetAxisRaw("VerticalR");
            }

            if (playerNumber == 2)
            {
                playerDirection = Vector3.right * Input.GetAxisRaw("HorizontalR 2") + Vector3.forward * Input.GetAxisRaw("VerticalR 2");
            }

            if (playerNumber == 3)
            {
                playerDirection = Vector3.right * Input.GetAxisRaw("HorizontalR 3") + Vector3.forward * Input.GetAxisRaw("VerticalR 3");
            }

            if (playerNumber == 4)
            {
                playerDirection = Vector3.right * Input.GetAxisRaw("HorizontalR 4") + Vector3.forward * Input.GetAxisRaw("VerticalR 4");
            }


            if (playerDirection.sqrMagnitude > 0.0f)
            {
                transform.rotation = Quaternion.LookRotation(playerDirection,Vector3.up);   
                gun.isFiring = true;

            }
            else
            {
                gun.isFiring = false;
            }
        
    }

    private void FixedUpdate()
    {
        rb.velocity = moveVelocity;
    }

    public int TeamNumber()
    {
        return playerNumber;
    }

    private void DashMove(Vector3 direction)
    {

    }

    IEnumerator DashMove()
    {
        canDash = false;
        moveSpeed = dashSpeed;
        yield return new WaitForFixedUpdate();
        moveSpeed = startingMoveSpeed;
        yield return new WaitForSeconds(dashCoolDown);
        canDash = true;
    }

}
