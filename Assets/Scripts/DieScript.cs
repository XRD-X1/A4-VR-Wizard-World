using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieScript : MonoBehaviour
{
    private Animator animator;
    private bool isDead;
    private Rigidbody rigidbody;
    public GameObject target;
    private BoxCollider boxCollider;
    public AudioSource deathAudioSource;
    public AudioSource attackAudioSource;
    public AudioSource idleAudioSource;

    public AudioClip deathAudioClip;





    private void Awake() {
        this.animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();

    }

    private void Update() {
        if(isDead)
        {
            return;
        }
        
        LookAtTarget();
        if(Vector3.Distance(target.transform.position, transform.position) <= 3f){
            animator.Play("attack_short_001");
            return;
        }

       transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z), Time.deltaTime * 4f);
       animator.Play("move_forward_fast");
    }

        public void LookAtTarget() {
        Quaternion quaternion = Quaternion.LookRotation((target.transform.position - transform.position).normalized);
        Quaternion rotateTo = new Quaternion(transform.rotation.x, quaternion.y, transform.rotation.z, quaternion.w);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateTo, Time.deltaTime * 300f);
    }

    public void Die()
    {
        if(!isDead)
        {
            StartCoroutine("dying");
        }
    }

    public IEnumerator dying()
    {
        isDead = true;
        deathAudioSource.PlayOneShot(deathAudioClip);
        rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
        idleAudioSource.enabled = false;
        attackAudioSource.enabled = false;
        yield return new WaitForSeconds(0.3f);
        boxCollider.enabled = false;
        animator.Play("dead");
    }

    public void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
