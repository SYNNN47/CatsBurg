using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer audioMixer; // Hubungkan AudioMixer di Inspector
    public Slider volumeSlider;   // Hubungkan Slider di Inspector

    void Start()
    {
        // Set nilai default slider ke 50% (0.5)
        volumeSlider.value = 0.5f;

        // Set default volume ke 50% di AudioMixer
        float defaultVolume = Mathf.Log10(volumeSlider.value) * 20; // Konversi ke dB
        audioMixer.SetFloat("MasterVolume", defaultVolume);

        // Tambahkan listener pada slider
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float value)
    {
        // Konversi nilai slider ke dB (desibel)
        float volume = Mathf.Log10(value) * 20;
        audioMixer.SetFloat("MasterVolume", volume);
    }
}
