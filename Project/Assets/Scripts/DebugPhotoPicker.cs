using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPhotoPicker : PhotoPickerBase {

    public List<Texture2D> debugImages;

	void Start () {
        Debug.Log("Populating photo picker with debug images. ");
        foreach (var debugImage in debugImages)
        {
            AddGalleryPhoto(debugImage);
        }
	}
}
