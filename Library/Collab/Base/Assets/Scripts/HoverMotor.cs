using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HoverMotor : NetworkBehavior
{

    public float speed = 90f;           //forward movement
    public float turnSpeed = 5f;        //rotation

    public float hoverForce = 65f;      //floating!
    public float hoverHeight = 3.5f;    //how high!

    private float powerInput;
    private float turnInput;
    private Rigidbody carRigidBody;

    private Quaternion originalRotation = new Quaternion(0, 0, 0,0);
    public float resetMovement = 20f;

    private void Awake()
    {
        carRigidBody = GetComponent<Rigidbody>();
    }

 
    // Update is called once per frame
    void Update()
    {
        powerInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

        

        //if (Mathf.Abs(Vector3.Dot(transform.up, Vector3.down)) < 0.60f){
        //    transform.rotation = originalRotation;
        //}

        //if (Mathf.Abs(Vector3.Dot(transform.right, Vector3.down)) > 0.60f)
        //{
        //    transform.rotation = originalRotation;
        //}

    }

    private void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, -transform.up);       //forward and down
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, hoverHeight))
        {
            float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
            Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
            carRigidBody.AddForce(appliedHoverForce, ForceMode.Acceleration);
        }

        carRigidBody.AddRelativeForce(0f, 0f, powerInput * speed);
        carRigidBody.AddRelativeTorque(0f, turnInput * turnSpeed, 0f);
    }
}
