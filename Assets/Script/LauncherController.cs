using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    public Collider bola; 
	public KeyCode input; 
	public float maxForce;
	public float maxTimeHold; 
	private Renderer renderer;
	private bool isHold;
	public Color color;
	public bool toYellow, toRed;

	private void Start()
  {
    isHold = false;
	toYellow = false;
	toRed = false;
	
  }
  private void Update(){
	if(Input.GetKeyDown(KeyCode.Space)){
		renderer = GetComponent<Renderer>();
        renderer.material.color = Color.red;
		toRed=false;
                
            }else if(Input.GetKeyUp(KeyCode.Space)){
                renderer.material.color = Color.yellow;
				toYellow=false;
           		}
			}
	void OnTriggerStay(){
		toRed=true;
	}

	void OnTriggerExit(){
		toYellow=true;
	}

	private void OnCollisionStay(Collision collision)
	{
		if (collision.collider == bola)
		{
			ReadInput(bola);
		}
	}
	
	
	private void ReadInput(Collider collider)
	{
		if (Input.GetKey(input) && !isHold)
		{
			StartCoroutine(StartHold(collider));
		}
	}

	private IEnumerator StartHold(Collider collider){
		isHold=true;
		float force = 0.0f;
		float timeHold= 0.0f;

		while(Input.GetKey(input)){
			force = Mathf.Lerp(0,maxForce,timeHold/maxTimeHold);
			yield return new WaitForEndOfFrame();
			timeHold += Time.deltaTime;


		}
		collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * maxForce);
		isHold=false;

	}
}

