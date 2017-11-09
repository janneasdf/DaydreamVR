using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPhotoPicker : MonoBehaviour {
    public GameObject photoPickerPrefab;

    public void Open()
    {
        var photoPicker = Instantiate(photoPickerPrefab) as GameObject;
        photoPicker.transform.SetParent(transform, false);
        photoPicker.GetComponent<PhotoPicker>().photoHolder = gameObject;
    }
}
