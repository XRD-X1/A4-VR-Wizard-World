using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Flying : MonoBehaviour
{
    public GameObject leftHand;
    public GameObject head;
    public float flyingSpeed = 0.4f;
    private bool isFlying;
    public InputActionReference button;

    public bool isInAir;
    public Rigidbody mainRigidBody;

    public GameObject rightHandParent;
    public GameObject leftHandParent;

    public GameObject leftHandPresence;
    public GameObject rightHandPresence;

    public bool hasBroomInHand;

  
    void Update()
    {
        if(isInAir && !hasBroomInHand)
        {
            StartFalling();
        }
        else if(!isInAir && hasBroomInHand)
        {
            CheckIfFlying();
            FlyIfFlying();
            StartFlying();
        }
        else
        {
            StartFlying();
        }
    }

    private void CheckIfFlying()
    {
        if (button.action.triggered)
        {
            isFlying = !isFlying;
        }
    }

    private void FlyIfFlying()
    {
        if(isFlying)
        {
        Vector3 flyingDir = leftHand.transform.position - head.transform.position;
        transform.position += flyingDir * flyingSpeed;
        leftHandPresence.transform.position += flyingDir * flyingSpeed;
        rightHandPresence.transform.position += flyingDir * flyingSpeed;
        }
    }

    public void StartFalling()
    {
        //Set rigidbodies and hand physics script to off
        leftHandPresence.GetComponent<Rigidbody>().isKinematic = true;
        leftHandPresence.GetComponent<HandPhysics>().enabled = false;

        rightHandPresence.GetComponent<Rigidbody>().isKinematic = true;
        rightHandPresence.GetComponent<HandPhysics>().enabled = false;

        //Setting the hand models as children of parents
        rightHandPresence.transform.SetParent(rightHandParent.transform);
        leftHandPresence.transform.SetParent(leftHandParent.transform);

        rightHandPresence.transform.localRotation = Quaternion.Euler(0, 0, 0);
        leftHandPresence.transform.localRotation = Quaternion.Euler(0, 0, 0);

        mainRigidBody.isKinematic = false;
    }

    public void StartFlying()
    {
        //Setting the hand models free
        leftHandPresence.transform.parent = null;
        rightHandPresence.transform.parent = null;

        mainRigidBody.isKinematic = true;

        //Set rigisbodies and hand physics script to on
        leftHandPresence.GetComponent<Rigidbody>().isKinematic = false;
        leftHandPresence.GetComponent<HandPhysics>().enabled = true;

        rightHandPresence.GetComponent<Rigidbody>().isKinematic = false;
        rightHandPresence.GetComponent<HandPhysics>().enabled = true;
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag != "Broom")
        {
            isInAir = false;
        }
        
    }
}
