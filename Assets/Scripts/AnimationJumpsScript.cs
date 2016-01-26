using UnityEngine;
using System.Collections;

public class AnimationJumpsScript : MonoBehaviour {

	public Animator playerAnimator;
	public Animator cameraAnimator;
	
	private bool state1 = false;
	private bool state2 = false;
	private bool state3 = false;
	private bool state4 = false;
	
	void Start () 
	{	
		OVRManager.display.RecenterPose();
		Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log (Time.timeSinceLevelLoad);
		if (Time.timeSinceLevelLoad >= 26 && !state1)
		{
			Time.timeScale = 0.3f;
			state1 = true;
		}
		
		if (Time.timeSinceLevelLoad >= 27.5f && !state2)
		{
			Time.timeScale = 1;
			state2 = true;
		}		
		
		if (Time.timeSinceLevelLoad >= 61 && !state3)
		{
			Time.timeScale = 20;
			state3 = true;
		}
		if (Time.timeSinceLevelLoad >= 96 && !state4)
		{
			Time.timeScale = 1;
			state4 = true;
		}		
	}
}
