using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkybox : MonoBehaviour {

    public Material otherSkybox;  // assign via inspector

    public ChangeSkybox()
    {
    }

    // Use this for initialization
    void Start () {
        RenderSettings.skybox = otherSkybox;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
