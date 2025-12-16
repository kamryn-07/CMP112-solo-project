using UnityEngine;

public class SoundController : MonoBehaviour
{

    // public methods
    public void RandomiseAudioProperties(AudioSource audio, float volume)
    {

        audio.pitch = Random.Range(0.25f, 1f);
        audio.panStereo = Random.Range(-0.25f, 0.25f);
        audio.volume = Random.Range(volume - (volume / 3.0f), volume + (volume / 3.0f));

    }

}
