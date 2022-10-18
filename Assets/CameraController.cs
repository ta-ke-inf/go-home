using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        this.player=GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        //playerの位置を取得
        Vector3 playerPosition=this.player.transform.position;
        //メインカメラの位置の更新
        transform.position=new Vector3(playerPosition.x,transform.position.y,transform.position.z);
    }
}
