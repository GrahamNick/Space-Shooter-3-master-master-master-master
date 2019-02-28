using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeBackgroundColor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (RenderSettings.skybox.HasProperty ("_Tint")) {
			RenderSettings.skybox.SetColor ("_Tint",
				new Color (
					Mathf.Sin (1 * Time.deltaTime), 
					Mathf.Cos (1 * Time.deltaTime), 
					Mathf.Tan (1 * Time.deltaTime)
				)
			);
		} else if (RenderSettings.skybox.HasProperty ("_SkyTint")) {
			RenderSettings.skybox.SetColor ("_SkyTint",
				new Color (
					Time.deltaTime, 
					Time.deltaTime, 
					Time.deltaTime)
				);
		}
	}
}
