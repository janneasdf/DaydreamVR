using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPhotoPicker : MonoBehaviour {

    public void Open()
    {
        // Move image picker to be child of this game object
        var photoPicker = Utilities.GetState().PhotoPicker;
        photoPicker.transform.SetParent(transform, false);
        photoPicker.transform.SetAsLastSibling();
        transform.SetAsLastSibling();

        // Set the photo holder that will display the picked photo
        var pickerComponent = photoPicker.GetComponent<PhotoPicker>();
        var debugPickerComponent = photoPicker.GetComponent<DebugPhotoPicker>();
        if (pickerComponent) { pickerComponent.photoHolder = gameObject; }
        else { debugPickerComponent.photoHolder = gameObject; }

        // Set picker active in case it was inactive
        photoPicker.SetActive(true);
    }
}
