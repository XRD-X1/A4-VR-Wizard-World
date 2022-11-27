using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPhysics : MonoBehaviour
{
    public Transform target;
    private Rigidbody rb;
    public Collider[] handColliders;
    public GameObject grabPoint;
    public bool isHoldingSomething;
    public float rotationSpedd = 1.0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 200f;
        handColliders = GetComponentsInChildren<Collider>();
    }

    public void EnableHandCollider()
    {
        foreach (var item in handColliders)
        {
            item.enabled = true;
        }
    }

    public void EnableColliderDelay(float delay)
    {
        Invoke("EnableHandCollider",delay);
    }

    public void DisableHandCollider()
    {
        foreach (Collider item in handColliders)
        {

            item.enabled = false;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = (target.position - transform.position) / Time.fixedDeltaTime;

        Quaternion rotationDiff = target.rotation * Quaternion.Inverse(transform.rotation);
        rotationDiff.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis);

        Vector3 rotationDiffInDegrees = angleInDegree * rotationAxis;

        rb.angularVelocity = (rotationDiffInDegrees * Mathf.Deg2Rad * rotationSpedd / Time.fixedDeltaTime);
    }
}
