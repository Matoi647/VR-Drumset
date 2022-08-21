using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumsEmulator : MonoBehaviour
{
    private string[] drumNames =
    {
        "Kick", "Snare",
        "Tom_Hi", "Tom_Mid", "Tom_Low",
        "HiHat", "CrashCymbal01", "CrashCymbal02", "Ride"
    };
    private KeyCode[] myDrumCode =
    {
        KeyCode.A, KeyCode.S, KeyCode.D,
        KeyCode.F, KeyCode.G, KeyCode.H, 
        KeyCode.J, KeyCode.K, KeyCode.L
    };

    private GameObject[] drums;
    private DrumsController[] drumsControllers;
    private GameObject drumset;

    private GameObject kickPedal;
    private KickPedalController kickPedalController;

    private GameObject hiHatPedal;
    private HiHatPedalController hiHatPedalController;
    // Start is called before the first frame update
    void Start()
    {
        drums = new GameObject[9];
        drumsControllers = new DrumsController[9];

        kickPedal = GameObject.Find("KickPedal");
        kickPedalController = kickPedal.GetComponent<KickPedalController>();
        hiHatPedal = GameObject.Find("HiHatPedal");
        hiHatPedalController = hiHatPedal.GetComponent<HiHatPedalController>();

        drumset = GameObject.Find("Drumset");
        for(int i = 0 ;i < 9; i++)
        {
            drums[i] = drumset.transform.Find(drumNames[i]).gameObject;
            drumsControllers[i] = drums[i].GetComponent<DrumsController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)||Input.GetKeyDown(KeyCode.Space))
        {
            hiHatPedalController.hiHatPedalSwitched();
        }

        if(Input.GetKeyDown(myDrumCode[0]))// Kick单独处理，通过KickPedal触发
        {
            kickPedalController.kickPedalTriggered();
        }
        if (Input.GetKeyUp(myDrumCode[0]))
        {
            kickPedalController.kickPedalUnTriggered();
        }
        for (int i = 1; i < 9; i++)
        {
            if(Input.GetKeyDown(myDrumCode[i]))
            {
                drumsControllers[i].drumTriggered();
            }
            if (Input.GetKeyUp(myDrumCode[i]))
            {
                drumsControllers[i].drumReleased();
            }
        }
    }
}
