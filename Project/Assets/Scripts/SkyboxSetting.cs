using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxSetting : MonoBehaviour {

    public Material newSky;

	// Use this for initialization
	void Start () {
        RenderSettings.skybox = newSky;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
