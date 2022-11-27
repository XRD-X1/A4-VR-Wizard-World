using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class MagicWand : MonoBehaviour

{

    [Header("Raycast")]
    [SerializeField] LayerMask hittableLayer;
    [SerializeField] float weaponRange;

    public GameObject rayPoint;

    public AudioSource m_MyAudioSource;
    public AudioSource electric_m_MyAudioSource;

    public GameObject m_GameObject;
    public AudioClip m_AudioClip;
    public InputActionReference button;

    Camera mainCam;
     bool m_Play;
     bool spellVisible;
    private bool playSound = false;
    private bool beingHandled = false;
    private int count =0;

    public bool isHolding = false;


    //Detect when you use the toggle, ensures music isn’t played multiple times
    // Start is called before the first frame update
   void Awake()
    {
        //fetches the main camera and stores it in a variable
        mainCam = Camera.main; 
    }

    void Start(){
        m_MyAudioSource = GetComponent<AudioSource>();
        electric_m_MyAudioSource = GetComponent<AudioSource>();
        m_Play = false;
        spellVisible = false;
       waitSome();
    }

void Update()
{

	if(button.action.IsPressed()){
        // if(!electric_m_MyAudioSource.isPlaying){
        //   electric_m_MyAudioSource.enabled = true;
        //     electric_m_MyAudioSource.loop = true;
        //     electric_m_MyAudioSource.Play();
        // }
            // m_MyAudioSource.PlayOneShot(m_AudioClip);
        if( /*some case  */ !beingHandled )
        {
             waitSome();
        }

        
       
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
        

		HandleRaycast();
    } else{
         electric_m_MyAudioSource.enabled = false;
             electric_m_MyAudioSource.loop = false;

        spellVisible = false;
        
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }
}

private void HandleRaycast()
{
   
    if (Physics.Raycast(rayPoint.transform.position, rayPoint.transform.forward, out RaycastHit hit, weaponRange, hittableLayer) )
    {
        if(hit.transform.gameObject.GetComponent<DieScript>() != null)
        {
            hit.transform.gameObject.GetComponent<DieScript>().Die();
        }
    }
    
}

 private void  waitSome(){
         beingHandled = true;
       

        spellVisible = true;

           
 
     }


}
