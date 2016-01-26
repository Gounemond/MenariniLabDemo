using UnityEngine;
using System.Collections;

public class SphereVisionMove : MonoBehaviour {

	public Material schermoMaterial;
	public Texture textureToChange;
	public SceneFadeInOut fadeCube;
	public Transform startPosition;
	public Transform endPosition;
	public GameObject textInstructions;
	
	private bool intoSphere = false;
	private bool isWaiting = true;

	// Use this for initialization
	void Start () 
	{
		textInstructions.SetActive (true);
		schermoMaterial.SetTexture ("_MainTex", textureToChange);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if ((OVRGamepadController.GPC_GetButton (OVRGamepadController.Button.A) || Input.GetKeyDown (KeyCode.Return)) && isWaiting && !intoSphere)
		{
			StartCoroutine(MoveToPosition(endPosition.transform.position,4.0f));
			intoSphere = true;
		}
		
		if ((OVRGamepadController.GPC_GetButton (OVRGamepadController.Button.A) || Input.GetKeyDown (KeyCode.Return)) && isWaiting && intoSphere)
		{
			StartCoroutine(MoveToPosition(startPosition.transform.position,4.0f));
			intoSphere = false;
		}		
	}
	
	public IEnumerator MoveToPosition(Vector3 newPosition, float time)
	{
		float elapsedTime = 0;
		Vector3 startingPos = transform.position;
		isWaiting = false;
		StartCoroutine ( fadeCube.EndScene ());
		while (elapsedTime < time)
		{
			transform.position = Vector3.Lerp(startingPos, newPosition, (elapsedTime / time));
			elapsedTime += Time.deltaTime;
			yield return 0;
		}
		StartCoroutine(fadeCube.StartScene ());
		isWaiting = true;
	}
}
