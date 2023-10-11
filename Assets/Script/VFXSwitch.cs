using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VFXSwitch : MonoBehaviour
{
   public GameObject vfxSource;
   public Collider bola;

    void OnTriggerEnter(Collider other){
        if(other == bola){
            //play vfx
            PlayVFXSwitch(other.transform.position);

        }
    }

     public void PlayVFXSwitch(Vector3 spawnPosition){
        GameObject.Instantiate(vfxSource, spawnPosition, Quaternion.identity);
    }
}
