using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    GameObject hpGauge;
    GameObject player;
    float hpDownRate=0.25f;

    // Start is called before the first frame update
    void Start()
    {
        this.hpGauge=GameObject.Find("hpGauge");
        this.player=GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if(this.player.transform.position.x>109f){
            SceneManager.LoadScene("GameclearScene");

        }
    }

    public void DecreaseHp(){
        this.hpGauge.GetComponent<Image>().fillAmount-=hpDownRate;
        if(this.hpGauge.GetComponent<Image>().fillAmount==0){
            //staticな変数loopTimeを初期化
            PlayerController.loopTime=0;
            
            SceneManager.LoadScene("GameoverScene");
        }
       
    }

    public void DisappearHp(){
        SceneManager.LoadScene("GameoverScene");
    }
}
