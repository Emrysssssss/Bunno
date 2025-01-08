using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 playerMoveInput;
    private CharacterController Controller;
    public float Playerspeed = 0.05f;
    private Vector2 aim;
    public Camera Cam;
    private Vector3 Point;
    public float DashPower = 2f;
    public float dashCooldown = 1f;
    private bool canDash = true;
    // Start is called before the first frame update
    void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        LookAt();
        StartCoroutine(Dash());
    }
    public void OnMovementInput(InputAction.CallbackContext context)
    {
        playerMoveInput = context.ReadValue<Vector2>();
    }

    public void OnMouseInput(InputAction.CallbackContext context) 
    {
        aim = context.ReadValue<Vector2>();
    }

    public IEnumerator Dash()
    {
        if (canDash)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                canDash = false;
                Controller.Move(transform.forward * DashPower);
                yield return new WaitForSeconds(dashCooldown);
                canDash = true;
            }
        }
    }

    private void Move()
    {
        playerMoveInput = playerMoveInput.normalized;
        Controller.Move(new Vector3(playerMoveInput.x*Playerspeed,-1000,playerMoveInput.y*Playerspeed*2));
    }
    private void LookAt()
    {
        Ray ray = Cam.ScreenPointToRay(aim);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;
        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Point = ray.GetPoint(rayDistance);
            Vector3 Heightcorrectedpoint = new Vector3(Point.x,transform.position.y,Point.z);
            transform.LookAt(Heightcorrectedpoint);
        }
    }
}
