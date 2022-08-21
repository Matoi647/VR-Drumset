using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumsController : MonoBehaviour
{
    public Material defaultMaterial;
    public Material triggeredMaterial;
    [Range(0, 100)] public float velocity;//设置范围，在Inspector中显示滑动条，默认为80
    public bool isTriggered;//被按下的状态

    protected AudioSource my_AudioSource;
    private AudioClip my_AudioClip;
    protected float outputVolume;//由AudioSource.volume和velocity相乘得出最终发出的声音

    // Start is called before the first frame update
    protected  virtual void Start()//虚函数，可被子类重写
    {
        velocity = 80.0f;
        my_AudioSource = GetComponent<AudioSource>();
        my_AudioClip = my_AudioSource.clip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "DrumStick")
        {
            drumTriggered();
        }
    }
    public void OnTriggerStay(Collider other)
    {

    }
    public void OnTriggerExit(Collider other)
    {
        drumReleased();
    }


    public virtual void drumTriggered()
    {
        isTriggered = true;
        my_AudioSource.volume = 1.0f;//碰撞时重新设置音量
        GetComponent<Renderer>().material = triggeredMaterial;
        outputVolume = my_AudioSource.volume * velocity / 100.0f;
        my_AudioSource.PlayOneShot(my_AudioClip, outputVolume);//速度从0到100
    }
    public void drumReleased()
    {
        isTriggered = false;
        GetComponent<Renderer>().material = defaultMaterial;
    }

    // 用于设置速度（音量）
    public void setVelocity(float vel)
    {
        velocity = vel;
    }
}
