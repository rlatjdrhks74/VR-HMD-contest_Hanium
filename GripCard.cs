using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GripCard : MonoBehaviour
{
    public GameObject CardUI;
    public GameObject ReaderUI;
    public GameObject Reader;

    public Material OrigianlMat;
    public Material Flick;
    public MeshRenderer ReaderMat;
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "CardImage")
        {
            CardUI.SetActive(false);
            ReaderUI.SetActive(true);
            ReaderMat.material = Flick;
            Reader.GetComponent<Flicker>().enabled = true;
        }
    }
}
