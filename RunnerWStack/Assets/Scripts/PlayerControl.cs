using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    bool isRunning = true;
    bool isRotating = false;
    public int layer = 3;
    public int lm;
    float rotationForce;  
    public GameObject cameraMain;
    public GameObject paintButton;
    private SwerveInputSystem _swerveInputSystem;
    [SerializeField] private float swerveSpeed = 0.4f;
    [SerializeField] private float maxSwerveAmount = 0.9f;
    public float speedForward = (Vector3.forward.z)/15;
    
    private void Awake() {
        _swerveInputSystem = GetComponent<SwerveInputSystem>();
        paintButton.SetActive(false);
    }
    void Start()
    {
        lm = 1 << layer;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    private void Update() {
     
    }
    private void FixedUpdate() 
    {
         if(isRunning){
            anim.SetBool("Running",true);
            float swerveAmount = Time.fixedDeltaTime * swerveSpeed * _swerveInputSystem.MoveFactorX;
            swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
            transform.Translate(swerveAmount, 0, speedForward);
        }

        if (isRotating){
            rb.velocity = new Vector3(rotationForce, rb.velocity.y, rb.velocity.z);
        }
    }
    private void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(0, 0, 0);
    }
    private void OnTriggerEnter(Collider other) {
        var tag = other.tag;
        if (tag == "Stop"){
            isRunning = false;
            anim.SetBool("Coloring",true);
            anim.SetBool("Running", false);
            paintButton.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other) {
        var tag = other.tag;
        if (tag == "Rotating"){
            isRotating = false;
            rotationForce = 0.0f;
        }
    }
}
