using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideController : MonoBehaviour
{
    // Start is called before the first frame update
    // 조작법 UI
    float ControllerX;  //컨트롤러 x y값
    float ControllerY;

    Vector2 MoveControllerState;    //컨트롤러 상태값
    Vector2 RotateControllerState;
    float TriggerControllerState;

    public GameObject MoveController;       //이동 회전 트리거 충전기 UI
    public GameObject RotateController;
    public GameObject TriggerController;
    public GameObject Charge;

    AudioSource Audioplayer;
    public AudioClip CorrectSound;      //소리

    bool limit1 = true;     //UI 숨김 및 보이기 체크에 사용될 변수
    bool limit2 = false;
    bool limit3 = false;
    bool limit4 = false;
    float TickTime;
    // Update is called once per frame
    void Start()
    {
        RotateController.SetActive(false);
        TriggerController.SetActive(false);
        Charge.SetActive(false);
        Audioplayer = GetComponent<AudioSource>();
    }
    void HideMoveController()   //이동에 성공하면 UI숨김
    {
        if (((ControllerX = MoveControllerState.x) >= 0.95) || ((ControllerX = MoveControllerState.x) <= -0.95))
        {
            Audioplayer.PlayOneShot(CorrectSound);
            MoveController.SetActive(false);
            limit1 = false;
        }
        if (((ControllerY = MoveControllerState.y) >= 0.95) || ((ControllerY = MoveControllerState.y) <= -0.95))
        {
            Audioplayer.PlayOneShot(CorrectSound);
            MoveController.SetActive(false);
            limit1 = false;
        }
    }
    void ShowRotateController()     //이동에 성공하면 회전 UI출력,회전에 성공하면 UI숨김
    {
        RotateController.SetActive(true);
        if (((ControllerX = RotateControllerState.x) >= 0.8) || ((ControllerX = RotateControllerState.x) <= -0.8))
        {
            Audioplayer.PlayOneShot(CorrectSound);
            RotateController.SetActive(false);
            limit2 = true;
        }
        if (((ControllerY = RotateControllerState.y) >= 0.8) || ((ControllerY = RotateControllerState.y) <= -0.8))
        {
            Audioplayer.PlayOneShot(CorrectSound);
            RotateController.SetActive(false);
            limit2 = true;
        }
    }

    void OnTriggerEnter(Collider col)       //엘리베이터 입구 및 충전기 앞에 가면 그에 맞는 UI출력
    {
        //TriggerControllerState = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);
        if (col.gameObject.tag == "Entrance" && limit3 == false && limit4 == false)
        {
            TriggerController.SetActive(true);
            limit3 = true;
            limit4 = true;
        }
        if (col.gameObject.name == "ChargerEntrance")
        {
            Charge.SetActive(true);
        }
    }

    void HideTriggerController()
    {
        if (TriggerControllerState >= 0.5 && limit4 == true)
        {
            limit4 = false;
            Audioplayer.PlayOneShot(CorrectSound);
            TriggerController.SetActive(false);
        }
    }

    void Update()       //컨트롤러 상태값을 계속 체크할 수 있게 Update에서 체크 -> UI 숨김 및 보이기 판단ㄴ 
    {
        MoveControllerState = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        RotateControllerState = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        TriggerControllerState = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);
        if (limit1 == true)
            HideMoveController();
        if ((limit1 == false) && (limit2 == false))
            TickTime += Time.deltaTime;
        if((TickTime >= 2.0f) && (limit1 == false) && (limit2 == false))
            ShowRotateController();
        if (limit3 == true)
            HideTriggerController();
    }

}
