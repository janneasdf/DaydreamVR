using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTeleport : MonoBehaviour {

    public GameObject targetPoint;

    void Start()
    {
        targetPoint = GameObject.Find("target");
    }

    public void ProcessGvrController()
    {
        if ( GvrControllerInput.ClickButtonDown )
        {
            if (!targetPoint) return;

            // If the pointer currently has non-null target
            // move the Headset at a fixed height above Pointer's hit point.
            Vector3 targetPosition = targetPoint.transform.position;
            Vector3 newTargetPosition = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);

            transform.position = newTargetPosition;

        }
        

    }


}
