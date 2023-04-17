using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    Vector3 velocity;
    [SerializeField] float movementSpeed = 8f;
    public CharacterController controller;

    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = .1f;
    public LayerMask groundMask;

    bool isGrounded;

    static bool stopMovement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Awake() {
        QualitySettings. vSyncCount = 1;
        Application. targetFrameRate = 30;
    }
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if(isGrounded && velocity.y<0){
            velocity.y = -2f;
        }
        if(!stopMovement){
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        Vector3 move = transform.right * horizontalInput + transform.forward * verticalInput ;
        controller.Move(move*movementSpeed*Time.deltaTime);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    public void StopMovement(){
        stopMovement = true;
    }

    public void StartMovement(){
        stopMovement = false;
    }
}
