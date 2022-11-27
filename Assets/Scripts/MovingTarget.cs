using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovingTarget : MonoBehaviour, ITrigger
{
    public Transform pointA;
    public Transform pointB;
    public float speed;
    private Vector3 target;
    public MovingTarget targetOne;
    public MovingTarget targetTwo;

    private void Start() {
        target = new Vector3(pointA.position.x, transform.position.y, transform.position.z);
    }

    void Update()
    {
        float step = speed * Time.deltaTime;

        if (Math.Abs(transform.position.x - target.x) == 0f)
        {
            ChangeTarget();
        }

        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }
    
    private void ChangeTarget()
    {
        if (transform.position.x == pointA.position.x)
        {
            target = new Vector3(pointB.position.x, target.y, transform.position.z);
        }
        else 
        {
            target = new Vector3(pointA.position.x, target.y, transform.position.z);
        }
    }

    public void HideTarget()
    {
        target = new Vector3(target.x, 2.5f, transform.position.z);
    }

    public void ShowTarget()
    {
           target = new Vector3(target.x, 1.03f, transform.position.z); 
    }

    public void TurnTriggerOn()
    {
        HideTarget();
        if(targetOne != null)
        {
            targetOne.enabled = true;
            targetOne.ShowTarget();
        }
        
        if(targetTwo != null)
        {
            targetTwo.enabled = true;
            targetTwo.ShowTarget();
        }

    }
}
