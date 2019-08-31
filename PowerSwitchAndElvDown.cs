using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PowerSwitchAndElvDown : MonoBehaviour
{
    AudioSource Audioplayer;
    public AudioClip Beep;           //소리
    private bool limit = true;
    void OnTriggerEnter(Collider col)
    {
        Audioplayer = GetComponent<AudioSource>();
        if (col.gameObject.name == "SwitchTrigger")
        {
            Audioplayer.PlayOneShot(Beep);
            SceneManager.LoadScene("Inside");       //충전기 전원스위치 누르면 씬 전환할거임
        }
        if (col.gameObject.name == "DownButton" && limit == true)   //엘베버튼 누르면 내려감
        {
            limit = false;
            GameObject.Find("DownButtonHand").SetActive(false);
            Audioplayer.PlayOneShot(Beep);
            col.gameObject.GetComponent<Button>().onClick.Invoke();
        }
        if (col.gameObject.name == "B2Button")   //엘베버튼 누르면 내려감
        {
            Audioplayer.PlayOneShot(Beep);
            col.gameObject.GetComponent<Button>().onClick.Invoke();
        }
    }
}
