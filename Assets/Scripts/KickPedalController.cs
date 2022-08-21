using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickPedalController : MonoBehaviour
{
    public Material defaultMaterial;
    public Material triggeredMaterial;
    [Range(0, 100)] public float velocity;//设置范围，在Inspector中显示滑动条，默认为80
    public bool isTriggered;//被按下的状态

    private GameObject kick;
    private DrumsController kickController;

    // Start is called before the first frame update
    void Start()
    {
        velocity = 80.0f;
        kick = GameObject.Find("Kick");
        kickController = kick.GetComponent<DrumsController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Foot")
        {
            kickPedalTriggered();
        }
    }
    public void OnTriggerStay(Collider other)
    {

    }
    public void OnTriggerExit(Collider other)
    {
        kickPedalUnTriggered();
    }
    public void kickPedalTriggered()
    {
        isTriggered = true;//kickPedal的isTriggered属性，不是kick的isTiggered属性
        GetComponent<Renderer>().material = triggeredMaterial;
        kickController.setVelocity(velocity);// 将kickPedal的速度传给kick
        kickController.drumTriggered();// 触发KickPedal时，调用Kick的drumTriggered()方法
    }
    public void kickPedalUnTriggered()
    {
        isTriggered = false;
        GetComponent<Renderer>().material = defaultMaterial;
        kickController.drumReleased();
    }
}
