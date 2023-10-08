using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public GameObject sfxAudioSource;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void PlayBGM(){

    }

    public void PlaySFX(Vector3 spawnPosition) { 
	
	GameObject.Instantiate(sfxAudioSource, spawnPosition, Quaternion.identity);
}
    }


