using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearDirector : MonoBehaviour
{
    GameObject TimeCounter;
    
    public Text text;   //Textコンポーネント
    float Taketime;
    string outputText;
    
    // Start is called before the first frame update
    void Start()
    {
        //CleraTimeを別のシーンから受け取る
        //PlayerControllerスクリプトのstaticなpassTime()メソッドを呼び出している
        this.Taketime=PlayerController.passTime();

        //float型をstring型に変換する
        this.outputText=Taketime.ToString("F2");

    }

    // Update is called once per frame
    void Update()
    {
        //Textコンポーネントのtextを変更
        text.text="Time : "+this.outputText+"s !!";
    }
}
