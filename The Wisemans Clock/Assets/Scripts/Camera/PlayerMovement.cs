using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public float movementSpeed = 12f;
    public Animator animator;
    public Transform groundCheck;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpForce = 15;
    public AudioSource walkAudio;
    public AudioSource teleportAudio;
    public Vector3 velocity;
    public Vector3 wew;
    private bool grounded = false;
    private NpcDialogue nearNpc = null;
    private bool _isNearNpc = false;
    // Start is called before the first frame update
    void Start()
    {
        this.controller = this.GetComponent<CharacterController>();
        SmoothSlider.OnStartSlide += onSlide;
        BabyTransition.OnMove += (to,prev)=>onSlide(null);
        walkAudio.mute = false;
        walkAudio.volume = 0;
    }

    private void onSlide(Timestamp timestamp)
    {
        animator.SetTrigger("Teleport");
        teleportAudio.Play();
        //teleportAnimator.SetBool("teleport",true);
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position += new Vector3(0.1f, 0, 0);
        if(!PlayerSingleton.Instance.CanPlayerMove || PlayerSingleton.Instance.occupied)
        {
            wew.Set(0,0,0);
            return;
        }

        bool isKeyDown = Input.GetButton("Horizontal") || Input.GetButton("Vertical");


        grounded = Physics.CheckSphere(groundCheck.position + new Vector3(0, -0.4f, 0), groundDistance, groundMask);
        if (grounded && velocity.y < 0)
            velocity.y = -2;

        if (grounded && velocity.y <= 0 && Input.GetButton("Jump"))
        {
            velocity.y = -gravity * Time.deltaTime + jumpForce;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        wew = move;
        controller.Move(move * Time.deltaTime * movementSpeed);
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        walkAudio.volume = move.magnitude*0.07f;
        if (!grounded)
            walkAudio.volume = 0;
       animator.SetBool("walkingUp", z > 0);
       animator.SetBool("walking", isKeyDown);
       /*
       if (_isNearNpc)
       {
           float distZ = this.transform.position.z - nearNpc.transform.position.z;
           animator.SetBool("walkingUp", distZ < 0);
       }
       */
    }

    public void isNearNpc(NpcDialogue npc)
    {
        nearNpc = npc;
        _isNearNpc = npc != null;
    }

    private Vector3 vecInPix = new Vector3();

    private Vector3 PixelPerfectClamp(Vector3 moveVector, float pixelsPerUnit) {
        vecInPix.Set(Mathf.RoundToInt(moveVector.x*pixelsPerUnit), 0,Mathf.RoundToInt(moveVector.z * pixelsPerUnit));

        return vecInPix / pixelsPerUnit;
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawSphere(groundCheck.position, groundDistance);
    }
}
