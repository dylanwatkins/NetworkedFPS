using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class SoundController : MonoBehaviour
{

    public AudioMixer mixer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            mixer.SetFloat("Volume", -80f);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            mixer.SetFloat("Volume", -20f);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            mixer.SetFloat("Volume", 0f);
        }
    }

}

