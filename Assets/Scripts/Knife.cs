using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Knife : MonoBehaviour
{
    public bool isAxe;

    public void AttachToHand(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.gameObject.tag == "Hand")
        {
            HandPhysics handScript = args.interactorObject.transform.gameObject.GetComponent<Controller>().handPhysics;
            if(handScript.isHoldingSomething)
            {
                return;
            }   
            if(isAxe){
                transform.position = new Vector3(0,-0.09f,0);
                transform.rotation = Quaternion.Euler(0,180,0);
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
        args.interactorObject.transform.gameObject.GetComponent<Controller>().handPhysics.isHoldingSomething = false;
        Invoke("DeleteWeapon", 10f);
    }

    private void DeleteWeapon()
    {
        Destroy(this.gameObject);
        
    }
}
