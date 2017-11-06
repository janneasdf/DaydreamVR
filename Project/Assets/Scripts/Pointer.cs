using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour {

    public GameObject target;
    public Vector3 hitPoint;
    public GameObject pointerDot;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = GvrControllerInput.Orientation;

        var origin = transform.position;
        var direction = transform.forward;
        RaycastHit hitInfo;
        var hit = Physics.Raycast(origin, direction, out hitInfo);
        Debug.DrawRay(origin, direction, Color.red);
        if (hit)
        {
            target = hitInfo.transform.gameObject;
            hitPoint = hitInfo.point;
            pointerDot.transform.position = hitPoint;
            pointerDot.SetActive(true);
        }
        else
        {
            target = null;
            pointerDot.SetActive(false);
        }
	}
}
