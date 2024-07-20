using UnityEngine;

public class MuteAudio : MonoBehaviour
{

    public AudioSource audioSource;
    public bool isAudioMuted = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // The key M allows a use to mute and unmute the audio
        if (Input.GetKeyDown(KeyCode.M))
        {
            isAudioMuted = !isAudioMuted;
            audioSource.mute = isAudioMuted;
        }
    }
}
