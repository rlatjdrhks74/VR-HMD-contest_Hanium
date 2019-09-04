using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    public Renderer joystick;
    public Color OriginColor;

    // Start is called before the first frame update
    void Start()
    {
        OriginColor = joystick.material.color; //조이스틱 칼라정보 저장

    }

    // Update is called once per frame
    void Update()
    {
        //색 점멸
        float flicker = Mathf.Abs(Mathf.Sin(Time.time * 4));
        joystick.material.color = OriginColor * flicker * 2;
    }
}
