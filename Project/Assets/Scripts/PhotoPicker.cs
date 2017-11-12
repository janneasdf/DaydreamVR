using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoPicker : PhotoPickerBase {

	void Start () {
        Debug.Log("Populating photo picker with images from gallery. ");
        var photoPaths = Utilities.GetAllGalleryImagePaths();
        Debug.Log(string.Join(",", photoPaths.ToArray()));
        foreach (var path in photoPaths)
        {
            AddGalleryPhoto(Utilities.LoadImageAsTexture(path));
        }
	}
}
