using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardReader : MonoBehaviour
{
    public GameObject Gateblock;
    public GameObject CardUI;
    public GameObject Reader;
    public GameObject ReaderUI;
    public Canvas Card;

    public Material OrigianlMat;
    public Material Flick;
    public MeshRenderer ReaderMat;

    AudioSource Audioplayer;
    public AudioClip[] Beep;           //소리

    bool check = true;
    bool check1 = true;
    // Start is called before the first frame update

    void OnTriggerEnter(Collider col)
    {
        Audioplayer = GetComponent<AudioSource>();
        if (col.gameObject.name == "GrabVolumeBig" && check1 == true)
        {
            Audioplayer.PlayOneShot(Beep[0]);
            if(check == true)
            {
                CardUI.SetActive(false);
                ReaderUI.SetActive(true);
                ReaderMat.material = Flick;
                Reader.GetComponent<Flicker>().enabled = true;
                check = false;
            }
        }
        if (col.gameObject.name == "Reader" && check == false)        //카드리더기 대면 깜빡이는거 중지하고 게이트 벽 해제
        {
            Audioplayer.PlayOneShot(Beep[1]);
            Gateblock.SetActive(false);
            ReaderMat.material = OrigianlMat;
            Reader.GetComponent<Flicker>().enabled = false;
            Card.GetComponent<Canvas>().enabled = false;
            //Reader.GetComponent<MeshCollider>().enabled = false;
            check = true;
            check1 = false;
        }
    }
}
