using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class VoiceRecorder : MonoBehaviour {

    private AudioSource microphoneAudioSource;
    private Text recordingText;
    private int recordingFlag; // True: recording on


    void Start()
    {
        microphoneAudioSource = transform.Find("Audio Source").gameObject.GetComponent<AudioSource>();
        recordingText = transform.Find("ButtonRecord").gameObject.GetComponent<Button>().transform.Find("RecordingText").gameObject.GetComponent<Text>();
        recordingText.enabled = false;
        recordingFlag = 0;
    }

    public void StartRecord()
    {
        if ( recordingFlag == 1 )
        {
            int recordingPosition = Microphone.GetPosition(null); // do before calling end!
            Microphone.End(null);
            recordingText.enabled = false;
            recordingFlag = 0;
            Debug.Log("StopRecord");
        }
        else
        {
            microphoneAudioSource.clip = Microphone.Start(null, true, 10, 16000);
            microphoneAudioSource.loop = false;
            recordingText.enabled = true;
            recordingFlag = 1;
            Debug.Log("StartRecord");
        }
    }

    public void PlayRecord()
    {
        microphoneAudioSource.Play();
        Debug.Log("PlayRecord");
    }
}
