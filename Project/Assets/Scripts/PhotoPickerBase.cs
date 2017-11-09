using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoPickerBase : MonoBehaviour {
    public void Close()
    {
        gameObject.SetActive(false);
    }
}
