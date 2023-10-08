using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Collider bola;
    public float multiplier;
    public Color color;
    private Renderer renderer;
    private Animator animator;

    public AudioManager audioManager;
    public VFXManager vfxManager;

    private void Start(){
        
        renderer = GetComponent<Renderer>();
        animator = GetComponent<Animator>();
        renderer.material.color = color;
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.collider == bola){
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;

            //animasi
            animator.SetTrigger("Hit");

            //play SFX
            audioManager.PlaySFX(collision.transform.position);

            //play vfx
            vfxManager.PlayVFX(collision.transform.position);

        }
    }

    
}
