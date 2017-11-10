using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class VoiceRecorder : MonoBehaviour {

    private AudioSource microphoneAudioSource;

    void Start()
    {
        microphoneAudioSource = transform.Find("Audio Source").gameObject.GetComponent<AudioSource>();
    }

    public void StartRecord()
    {
        microphoneAudioSource.clip = Microphone.Start(null, true, 10, 16000);
        microphoneAudioSource.loop = false;
        Debug.Log("StartRecord");
    }

    public void StopRecord()
    {
        int recordingPosition = Microphone.GetPosition(null); // do before calling end!
        Microphone.End(null);
        Debug.Log("StopRecord");
    }

    public void PlayRecord()
    {
        microphoneAudioSource.Play();
        Debug.Log("PlayRecord");
    }
}
