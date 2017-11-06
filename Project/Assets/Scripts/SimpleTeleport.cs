using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTeleport : MonoBehaviour {

    public Pointer pointer;

    void Start()
    {

    }

    public void Update()
    {
        if ( GvrControllerInput.ClickButtonDown )
        {
            if (!pointer.target) return;

            // If the pointer currently has non-null target
            // move the Headset at a fixed height above Pointer's hit point.
            Vector3 targetPosition = pointer.hitPoint;
            Vector3 newTargetPosition = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);

            transform.position = newTargetPosition;

        }
        

    }


}
