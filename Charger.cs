using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger : MonoBehaviour
{
    public Material OrigianlMat;
    public MeshRenderer ChargerMat;
    public GameObject ChargerUI;

    void OnTriggerEnter(Collider col)       //손으로 충전케이블 잡으면 깜빡이는거 중지
    {
        if (col.gameObject.name == "GrabVolumeBig")
        {
            ChargerMat.material = OrigianlMat;
            gameObject.GetComponent<Flicker>().enabled = false;
            ChargerUI.SetActive(false);
        }
            
}
}
