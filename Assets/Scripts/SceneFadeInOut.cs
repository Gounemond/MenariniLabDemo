using UnityEngine;
using System.Collections;

public class SceneFadeInOut : MonoBehaviour
{
	[Tooltip("The lower, the slower")]
	public float fadeSpeed = 1.5f;          // Speed that the screen fades to and from black.
	
	[Tooltip("0 for Tropical, 2 for Underwater, 3 for desert, 4 for asteroids")]
	public int sceneToLoad = 0;				
	
	[Tooltip("Delay in seconds for the scene start")]
	public float delay = 0;
		
	void Awake ()
	{
		StartCoroutine (StartScene());
	}
	
	
	void Update ()
	{

	}
	
	
	void FadeToClear ()
	{
		// Lerp the colour of the texture between itself and transparent.
		GetComponent<Renderer>().material.color = Color.Lerp(GetComponent<Renderer>().material.color, Color.clear, fadeSpeed * Time.deltaTime);
	}
	
	
	void FadeToBlack ()
	{
		// Lerp the colour of the texture between itself and black.
		GetComponent<Renderer>().material.color = Color.Lerp(GetComponent<Renderer>().material.color, Color.black, fadeSpeed * Time.deltaTime);
	}
	
	
	public IEnumerator StartScene ()
	{
		// Fade the texture to clear.
		while (GetComponent<Renderer>().material.color.a > 0.05f)
		{
			FadeToClear();
			yield return 0;
		}
		
		// If the texture is almost clear...
		if(GetComponent<Renderer>().material.color.a <= 0.05f)
		{
			// ... set the colour to clear and disable the GUITexture.
			GetComponent<Renderer>().material.color = Color.clear;
		}
	}
		
	// Fade the texture to black.
	public IEnumerator EndScene ()
	{
	
		// Start fading towards black.
		while (GetComponent<Renderer>().material.color.a < 0.95f)
		{
			FadeToBlack();
			yield return 0;
		}
			
		// If the screen is almost black...
		if(GetComponent<Renderer>().material.color.a >= 0.95f)
		{
			GetComponent<Renderer>().material.color = Color.black;
		}
	}
	
	// Fade the texture to black.
	public IEnumerator GameOverScene ()
	{
		
		// Start fading towards black.
		while (GetComponent<Renderer>().material.color.a < 0.95f)
		{
			FadeToBlack();
			yield return 0;
		}
		
		// If the screen is almost black...
		if(GetComponent<Renderer>().material.color.a >= 0.95f)
		{
			GetComponent<Renderer>().material = Resources.Load ("Materials/FadeCubeMaterialTextured") as Material;
			yield return new WaitForSeconds(5);
			// ... reload the level.
			Application.LoadLevel(0);
		}
	}
}