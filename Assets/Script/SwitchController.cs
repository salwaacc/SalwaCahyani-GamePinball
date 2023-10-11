using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    private enum SwitchState{
        Off,
        On,
        Blink
}

   public Collider bola;
   public Material onMaterial;
   public Material offMaterial;
   
   private Renderer renderer;
   private SwitchState state;
   
   public ScoreManager scoreManager;
   public float score;
   public VFXSwitch vfxSwitch;


   private void Start(){
    renderer= GetComponent<Renderer>();
    
    Set(false);
    StartCoroutine(BlinkTimerStart(5));
    
   }

   private void OnTriggerEnter(Collider other){
    if(other == bola){
        Toggle();

    }
   }

   private void Set(bool active){
    
    if(active == true){
        state= SwitchState.On;
        renderer.material = onMaterial;
        StopAllCoroutines();
        
    } else {
        state= SwitchState.Off;
        renderer.material = offMaterial;
        StartCoroutine(BlinkTimerStart(5));
    }
   }

    private void Toggle(){
    if (state == SwitchState.On)
    {
      Set(false); 
    }
    else
    {
      Set(true);
    }
    scoreManager.AddScore(score);
  }

   private IEnumerator Blink(int times){
    state= SwitchState.Blink;

    for(int i = 0;i<times;i++){
        renderer.material = onMaterial;
        yield return new WaitForSeconds(0.5f);
        renderer.material = offMaterial;
        yield return new WaitForSeconds(0.5f);
    }
    state= SwitchState.Off;
    StartCoroutine(BlinkTimerStart(5));
   }

    private IEnumerator BlinkTimerStart(float time){
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }

   
}
