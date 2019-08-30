using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttonflick : MonoBehaviour
{
    public Renderer[] joystick;
    public Color OriginColor;

    // Start is called before the first frame update
    void Start()
    {
        OriginColor = joystick[0].material.color; //조이스틱 칼라정보 저장

    }

    // Update is called once per frame
    void Update()
    {
        //색 점멸
        float flicker = Mathf.Abs(Mathf.Sin(Time.time * 4));
        joystick[0].material.color = OriginColor * flicker * 2;
        joystick[1].material.color = OriginColor * flicker * 2;
        if (OVRInput.Get(OVRInput.Button.One) || OVRInput.Get(OVRInput.Button.Two))
            SceneManager.LoadScene("Outside");
    }
}
