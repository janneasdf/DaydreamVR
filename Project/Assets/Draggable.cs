using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour {

    bool dragging = false;
    float originalDistance = 0.0f;
    Transform playerTransform;
    Transform controllerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        controllerTransform = GameObject.Find("GvrControllerPointer").transform;
    }

    private void Update()
    {
        if (dragging)
        {
            // Cast ray to see if there is a drop target behind
            var raycaster = GetComponentInParent<GvrPointerGraphicRaycaster>();
            var ped = new PointerEventData(null);
            var results = new List<RaycastResult>();
            raycaster.Raycast(ped, results);
            RaycastResult? dropTargetHit = null;
            foreach (var hitResult in results) {
                if (hitResult.gameObject.GetComponent<DropTarget>())
                {
                    dropTargetHit = hitResult;
                    break;
                }
            }
            print("Results: " + results.Count);
            if (dropTargetHit.HasValue)
            {
                print("Hit: " + dropTargetHit.Value.gameObject.name);
                // Move dragged object slightly in front of drop target and parallel to it
                var hit = dropTargetHit.Value;
                transform.position = hit.worldPosition + hit.gameObject.transform.forward * 0.07f;
                transform.rotation = hit.gameObject.transform.rotation;

                // Drop the object on the drop target on click
                if (GvrControllerInput.ClickButtonDown)
                {
                    // If button was clicked, attach object to the drop target 
                    // and end dragging
                    EndDrag();
                    print("EndDrag");
                }
            }
            else
            {
                float distance = originalDistance - 0.1f; // draw a little closer
                transform.position = controllerTransform.position + 
                    originalDistance * controllerTransform.forward;
                var lookTarget = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z);
                transform.LookAt(lookTarget);
            }
        }
    }

    public void StartDrag()
    {
        dragging = true;
        var playerTransform = GameObject.FindWithTag("Player").transform;
        originalDistance = (transform.position - playerTransform.position).magnitude;
    }

    public void EndDrag()
    {
        dragging = false;
        // TODO: tell droptarget about this, as well as (maybe) original holder
    }

}
