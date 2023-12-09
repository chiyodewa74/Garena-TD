using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom : MonoBehaviour
{
    public float DetectRadius; // Define the vertices of your custom polygon
    public Transform DetectPoint;
    public LayerMask allowedLayers; // Specify the allowed layers for detection
    bool DetectingEntity;
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        DetectingEntity = Physics2D.OverlapCircle(DetectPoint.position, DetectRadius, allowedLayers);

        if(DetectingEntity)
        {
            anim.SetTrigger("FadeOut");
        }
        else
        {

            anim.SetTrigger("FadeIn");
        }
    }

    private void OnDrawGizmos()
    {
        if(DetectPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(DetectPoint.position, DetectRadius);
    }
}

