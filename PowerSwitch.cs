using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PowerSwitch : MonoBehaviour
{
    AudioSource Audioplayer;
    public AudioClip Beep;           //소리
    void OnTriggerEnter(Collider col)
    {
        Audioplayer = GetComponent<AudioSource>();
        if (col.gameObject.name == "SwitchTrigger")
        {
            Audioplayer.PlayOneShot(Beep);
            SceneManager.LoadScene("Inside");       //충전기 전원스위치 누르면 씬 전환할거임
        }
    }
}
