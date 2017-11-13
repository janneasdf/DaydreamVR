using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(AudioSource))]
public class VoiceRecorder : MonoBehaviour {

    private AudioSource microphoneAudioSource;
    private Text recordingText;
    private Text playingText;
    private Button recordingButton;
    private Button playingButton;
    private int recordingFlag; // True: recording on
    private int playingFlag; // True: playing on


    void Start()
    {
        microphoneAudioSource = transform.Find("Audio Source").gameObject.GetComponent<AudioSource>();
        recordingButton = transform.Find("ButtonRecord").gameObject.GetComponent<Button>();
        recordingText = recordingButton.transform.Find("RecordingText").gameObject.GetComponent<Text>();
        recordingText.enabled = false;
        playingButton = transform.Find("ButtonPlay").gameObject.GetComponent<Button>();
        playingText = playingButton.transform.Find("PlayingText").gameObject.GetComponent<Text>();
        playingText.enabled = false;
        recordingFlag = 0;
        playingFlag = 0;
    }

    public void StartRecord()
    {
        microphoneAudioSource.Stop();
        playingFlag = 0;

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
        if ( playingFlag == 1 )
        {
            microphoneAudioSource.Stop();
            playingFlag = 0;
        }
        else
        {
            if ( recordingFlag == 0 )
            {
                microphoneAudioSource.Play();
                Debug.Log("PlayRecord");
                playingText.enabled = true;
                playingFlag = 1;
            }
        }
    
    }

    void Update()
    {
        if (!microphoneAudioSource.isPlaying)
        {
            playingText.enabled = false;
            playingFlag = 0;
        }
    }
}
