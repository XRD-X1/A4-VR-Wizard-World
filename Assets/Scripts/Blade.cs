using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class Blade : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip clip;
    private bool played;

    private void Awake() {
        audio.clip = clip;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "target")
        {
            if(!played)
            audio.PlayOneShot(clip, 0.5f);
            played = true;

            transform.parent.GetComponent<Rigidbody>().isKinematic = true;
            transform.parent.transform.parent = other.transform;
            if(other.GetComponent<ITrigger>() != null)
            {
                other.GetComponent<ITrigger>().TurnTriggerOn();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "target")
        {
            transform.parent.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    public void ResetRigid()
    {
        transform.parent.GetComponent<Rigidbody>().isKinematic = false;
    }
}
