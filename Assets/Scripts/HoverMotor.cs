using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverMotor : MonoBehaviour
{

    public float speed = 50f;           //forward movement
    public float turnSpeed = 10f;        //rotation

    public float hoverForce = 20f;      //floating!
    public float hoverHeight = 2.5f;    //how high!

    private float powerInput;
    private float turnInput;
    private Rigidbody carRigidBody;

    private Quaternion originalRotation = new Quaternion(0, 0, 0, 0);

    bool canInput = true;

    private void Awake()
    {
        carRigidBody = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        powerInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

      

        if (Mathf.Abs(Vector3.Dot(transform.up, Vector3.down)) < 0.05f && (transform.position.y < 2f))
        {
            carRigidBody.isKinematic = true;
            transform.rotation = originalRotation;
            carRigidBody.isKinematic = false;
        }

        if (Mathf.Abs(Vector3.Dot(transform.right, Vector3.down)) > 0.95f && (transform.position.y < 2f))
        {
            carRigidBody.isKinematic = true;
            transform.rotation = originalRotation;
            carRigidBody.isKinematic = false;
        }

        if (Input.GetKey("r"))
        {
            carRigidBody.isKinematic = true;
            transform.rotation = originalRotation;
            carRigidBody.isKinematic = false;
        }

        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();

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


        if (canInput)
        {
            carRigidBody.AddRelativeForce(0f, 0f, powerInput * speed);
            carRigidBody.AddRelativeTorque(0f, turnInput * turnSpeed, 0f);
        }


        if (transform.position.y > 7)
        {
            hoverForce = 0f;
            canInput = false;
        }

        if (transform.position.y <= 7)
        {
            hoverForce = 20f;
            canInput = true;
        }
    }
}
