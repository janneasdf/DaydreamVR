using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoPicker : MonoBehaviour {

    [Tooltip("Object which we'll put the chosen image to.")]
    public GameObject photoHolder;

    [Tooltip("Parent for the images to be shown.")]
    public GameObject contentHolder;

    [Tooltip("Prefab for the image objects in the scrollView.")]
    public GameObject uiImagePrefab;

	// Use this for initialization
	void Start () {
        var photoPaths = Utilities.GetAllGalleryImagePaths().GetRange(0, 6);
        Debug.Log(string.Join(",", photoPaths.ToArray()));
        foreach (var path in photoPaths)
        {
            var imageObject = Instantiate(uiImagePrefab) as GameObject;
            imageObject.transform.SetParent(contentHolder.transform);
            var image = imageObject.GetComponent<UnityEngine.UI.RawImage>();
            image.texture = Utilities.LoadImageAsTexture(path);
            Debug.Log("Set texture :" + path);
            Debug.Log(image.texture.ToString());
        }
	}
}
