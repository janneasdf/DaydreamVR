﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PhotoChooser : MonoBehaviour {

    public void OpenPhotoChooser()
    {
        //var testStrings = new List<string>();
        //testStrings.Add("test1");
        //testStrings.Add("test2");
        //Debug.Log("Test: " + string.Join(",", testStrings.ToArray()));

        Debug.Log("Opened photo chooser!");
        SetImage();
        Debug.Log("First path: " + GetAllGalleryImagePaths()[0]);
        Debug.Log("Paths: " + string.Join(",", GetAllGalleryImagePaths().ToArray()));

    }

    // This function was found Unity forums
    private List<string> GetAllGalleryImagePaths()
    {
        List<string> results = new List<string>();
        HashSet<string> allowedExtesions = new HashSet<string>() { ".png", ".jpg", ".jpeg" };

        try
        {
            AndroidJavaClass mediaClass = new AndroidJavaClass("android.provider.MediaStore$Images$Media");

            // Set the tags for the data we want about each image.  This should really be done by calling; 
            //string dataTag = mediaClass.GetStatic<string>("DATA");
            // but I couldn't get that to work...

            const string dataTag = "_data";

            string[] projection = new string[] { dataTag };
            AndroidJavaClass player = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = player.GetStatic<AndroidJavaObject>("currentActivity");

            string[] urisToSearch = new string[] { "EXTERNAL_CONTENT_URI", "INTERNAL_CONTENT_URI" };
            foreach (string uriToSearch in urisToSearch)
            {
                AndroidJavaObject externalUri = mediaClass.GetStatic<AndroidJavaObject>(uriToSearch);
                AndroidJavaObject finder = currentActivity.Call<AndroidJavaObject>("managedQuery", externalUri, projection, null, null, null);
                bool foundOne = finder.Call<bool>("moveToFirst");
                while (foundOne)
                {
                    int dataIndex = finder.Call<int>("getColumnIndex", dataTag);
                    string data = finder.Call<string>("getString", dataIndex);
                    if (allowedExtesions.Contains(Path.GetExtension(data).ToLower()))
                    {
                        string path = @"file:///" + data;
                        results.Add(path);
                    }

                    foundOne = finder.Call<bool>("moveToNext");
                }
            }
        }
        catch (System.Exception e)
        {
            // do something with error...
        }

        return results;
    }

    //[SerializeField]
    //private RawImage m_image;
    //[SerializeField]
    //private Text m_text;

    public RawImage m_image;
    public Text m_text;

    public void SetImage()
    {
        m_text.text = "Getting paths... ";
        List<string> galleryImages = GetAllGalleryImagePaths();
        var allPaths = string.Join(", ", galleryImages.ToArray());
        //m_text.text = "Paths: " + allPaths;
        m_text.text = "Paths: " + string.Join(",", galleryImages.ToArray()) + " Image count: " + galleryImages.Count;
        if (galleryImages.Count == 0) return;

        var t = new Texture2D(2, 2);
        var random = new System.Random();
        var imageToShow = galleryImages[random.Next(galleryImages.Count)];
        (new WWW(imageToShow)).LoadImageIntoTexture(t);
        m_image.texture = t;
    }
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
