using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiHatController : DrumsController//继承了DrumsController
{
    public AudioClip closed_AudioClip;//闭镲音频
    public AudioClip open_AudioClip;//开镲音频
    private GameObject hiHatPedal;
    private HiHatPedalController hiHatPedalController;
    // Start is called before the first frame update
    protected override void Start()//继承父类的start方法，用于初始化
    {
        base.Start();
        hiHatPedal = GameObject.Find("HiHatPedal");
        hiHatPedalController = hiHatPedal.GetComponent<HiHatPedalController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void drumTriggered()//重写drumTriggered方法
    {
        isTriggered = true;
        my_AudioSource.volume = 1.0f;//碰撞时重新设置音量
        GetComponent<Renderer>().material = triggeredMaterial;
        outputVolume = my_AudioSource.volume * velocity / 100.0f;
        if(hiHatPedalController.onPedalDown == false)//如果没有踩下踏板，播放闭镲音频
            my_AudioSource.PlayOneShot(closed_AudioClip, outputVolume);
        else//否则播放开镲音频
            my_AudioSource.PlayOneShot(open_AudioClip, outputVolume);
    }
}
