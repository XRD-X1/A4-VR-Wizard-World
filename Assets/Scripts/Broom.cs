using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Broom : MonoBehaviour
{
    private Flying flying;
    private void Awake() {
        flying = FindObjectOfType<Flying>();
    }

public void AttachToHand(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.gameObject.tag == "Hand")
        {
            HandPhysics handScript = args.interactorObject.transform.gameObject.GetComponent<Controller>().handPhysics;
            if(handScript.isHoldingSomething)
            {
                return;
            }   
            if(CompareTag("Broom")){
                // transform.position = new Vector3(0,-0.09f,0);
                // transform.rotation = Quaternion.Euler(0,180,0);
                
                transform.position = new Vector3(0.014f,-0.11f,-0.115f);
                transform.rotation = Quaternion.Euler(11,281,-19);

                flying.hasBroomInHand = true;
                flying.isInAir = false;
            }
            else
            {
                transform.position = Vector3.zero;
                transform.rotation = Quaternion.identity;
            }

            transform.SetParent(handScript.grabPoint.transform, false);

            handScript.isHoldingSomething = true;
        }
        
    }

    public void DetachFromHand(SelectExitEventArgs args)
    {
        
        flying.isInAir = true;
        flying.hasBroomInHand = false;
        args.interactorObject.transform.gameObject.GetComponent<Controller>().handPhysics.isHoldingSomething = false;
    }
}
