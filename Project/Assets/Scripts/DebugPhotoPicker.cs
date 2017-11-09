using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPhotoPicker : MonoBehaviour {

    [Tooltip("Object which we'll put the chosen image to.")]
    public GameObject photoHolder;

    [Tooltip("Parent for the images to be shown.")]
    public GameObject contentHolder;

    [Tooltip("Prefab for the image objects in the scrollView.")]
    public GameObject uiImagePrefab;

    public List<Texture2D> debugImages;

	void Start () {
        Debug.Log("Populating photo picker with debug images. ");
        foreach (var debugImage in debugImages)
        {
            var imageObject = Instantiate(uiImagePrefab);
            imageObject.transform.SetParent(contentHolder.transform, false);
            var image = imageObject.GetComponent<UnityEngine.UI.RawImage>();
            image.texture = debugImage;
        }
	}
}
