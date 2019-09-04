using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateEnter : MonoBehaviour
{
    public GameObject Card;
    // Start is called before the first frame update

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "CenterEyeAnchor")
            Card.SetActive(true);
    }
}
