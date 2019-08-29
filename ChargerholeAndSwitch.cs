using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargerholeAndSwitch : MonoBehaviour
{
    public GameObject chargertext;
    public GameObject hole;
    public GameObject circle001;
    public GameObject Switch;
    public GameObject SwitchUI;
    public GameObject SwitchTrigger;

    public Material OrigianlMat;
    public MeshRenderer holeMat;
    public MeshRenderer SwitchMat;

    AudioSource Audioplayer;
    public AudioClip Beep;           //소리

    bool Check;
    void Start()
    {
        SwitchTrigger.SetActive(false);
        SwitchMat.material = OrigianlMat;
        SwitchUI.SetActive(false);
        Switch.GetComponent<Flicker>().enabled = false;
        Audioplayer = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider col)       //충전단자에 충전케이블 꽂으면 충전단자 동그란 꽂는부분 깜빡이는거 중지.
    {
        if (col.gameObject.name == "Charger")
        {
            gameObject.GetComponent<Flicker>().enabled = false;
            chargertext.SetActive(false);
            holeMat.material = OrigianlMat;
            circle001.transform.parent = hole.transform;
            EnableSwitch();                 //충전케이블을 충전단자의 자손으로 만들어서 충전단자가 움직여도 꽂힌 상태가 유지될수잇게
        }
    }
    void EnableSwitch()
    {
            Audioplayer.PlayOneShot(Beep);
            SwitchTrigger.SetActive(true);
            SwitchUI.SetActive(true);
            Switch.GetComponent<Flicker>().enabled = true;     //충전케이블을 충전단자에 꽂으면 전원 스위치 반짝이는거 시작

    }
}
