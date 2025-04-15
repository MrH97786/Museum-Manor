using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SceptreController : MonoBehaviour
{
    public ParticleSystem particles;

    public LayerMask layerMask;
    public Transform fireSource;
    public float distance = 10;

    private bool rayActivate = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(x => Fire());
        grabInteractable.deactivated.AddListener(x => cancelFire());
    }

    public void Fire()
    {
        particles.Play();
        rayActivate = true; 
    }

    public void cancelFire()
    {
        particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        rayActivate = false;  
    }

    // Update is called once per frame
    void Update()
    {
        if (rayActivate)
        {
            RaycastCheck();
        }
    }

    void RaycastCheck()
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(fireSource.position, fireSource.forward, out hit, distance, layerMask);

        if (hasHit)
        {
            hit.transform.gameObject.SendMessage("Break", SendMessageOptions.DontRequireReceiver);
        }
    }
}
