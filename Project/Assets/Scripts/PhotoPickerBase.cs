using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoPickerBase : MonoBehaviour {

    [Tooltip("Object which we'll put the chosen image to.")]
    public GameObject photoHolder;

    [Tooltip("Parent for the images to be shown.")]
    public GameObject contentHolder;

    [Tooltip("Prefab for the image objects in the scrollView.")]
    public GameObject uiImagePrefab;

    [Tooltip("Prefab for image object spawned after picking photo. ")]
    public GameObject scenePhotoPrefab;

    protected void AddGalleryPhoto(Texture2D texture)
    {
        // Create the clickable photo object
        var imageObject = Instantiate(uiImagePrefab);
        imageObject.transform.SetParent(contentHolder.transform, false);

        // Set the texture
        var image = imageObject.GetComponent<RawImage>();
        image.texture = texture;

        // Set button click callback
        var button = imageObject.GetComponent<Button>();
        button.onClick.AddListener(() => { PickPhoto(texture); });
    }

    // Close the photo picker (by setting it inactive)
    public void Close()
    {
        gameObject.SetActive(false);
    }

    // Called by gallery photo
    public void PickPhoto(Texture pickedImageTexture)
    {
        // Instantiate image object on top of photoHolder
        var scenePhoto = Instantiate(scenePhotoPrefab);
        scenePhoto.transform.SetParent(photoHolder.transform, false);
        var targetImage = scenePhoto.GetComponent<RawImage>();
        targetImage.texture = pickedImageTexture;

        // Close photo picker
        Close();
    }
}
