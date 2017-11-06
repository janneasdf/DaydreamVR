using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackpadMovement : MonoBehaviour {

    public float movementSpeed = 1.0f;

    GameObject sceneCamera;

	// Use this for initialization
	void Start () {
        sceneCamera = GameObject.FindWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		if (GvrControllerInput.IsTouching)
        {
            Debug.Log(GvrControllerInput.TouchPosCentered.magnitude);
            var inputDir = GvrControllerInput.TouchPosCentered;
            if (inputDir.magnitude < 0.4) return;

            //inputDir = inputDir.normalized;

            var fwd = sceneCamera.transform.forward;
            fwd.y = 0;
            fwd = fwd.normalized;
            var hor = Vector3.ProjectOnPlane(fwd, Vector3.up).normalized;

            var direction = (inputDir.x * hor + inputDir.y * fwd).normalized;
            transform.position += direction * Time.deltaTime * movementSpeed;
        }
	}
}
