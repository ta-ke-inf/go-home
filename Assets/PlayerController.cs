using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    CapsuleCollider2D capcol;
    GameObject director;
   
   
    float jumpForce=700.0f;
    float stepForce=700.0f;
    float walkForce=30.0f;
    float maxSpeedx=6.0f;
    string enemyTag="Enemy";
    public static float loopTime=0;
     //staticでどこでもアクセス可能
    public float damageForce;

   
    
 

    


    // Start is called before the first frame update
    void Start()
    {
    
        this.rigid2D=GetComponent<Rigidbody2D>();
        this.animator=GetComponent<Animator>();
        this.capcol=GetComponent<CapsuleCollider2D>();
        this.director=GameObject.Find("GameDirector");

     
    }

    // Update is called once per frame
    void Update()
    {
        //ジャンプ
        if(Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y==0){
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2D.AddForce(transform.up*this.jumpForce);
        }
        
     
        //左右移動
        int key=0;
        //自身のx速度を取得
        float speedx=Mathf.Abs(this.rigid2D.velocity.x);

        if(Input.GetKey(KeyCode.RightArrow)) key=1;
        if(Input.GetKey(KeyCode.LeftArrow)) key=-1;
        //一定速度より小さい時だけ力を加える
        if(speedx<maxSpeedx){
            this.rigid2D.AddForce(transform.right*key*walkForce);
        }

        //左右のキーを押しているとき
        if(key!=0){
            this.animator.SetTrigger("RunTrigger");
            transform.localScale=new Vector3(key*5,5,5);
        }
        //左右のキーを押していないとき
        else{
            this.animator.SetTrigger("IdleTrigger");
        }

        if(transform.position.y<-5.0f){
            this.director.GetComponent<GameDirector>().DisappearHp();
        }

        //経過時間を計算
        loopTime+=Time.deltaTime;
       


        


        
    }

    //ぶつかった瞬間
    void OnCollisionEnter2D(Collision2D collision){
        //tag持ちにぶつかったとき
        if(collision.collider.tag==enemyTag){
            //踏むときの足元の位置
            float judgePos=transform.position.y-this.capcol.size.y*2.0f;
            //ループforeach //collision.contactsでぶつかった位置を取得できる//pに代入している
            foreach(ContactPoint2D p in collision.contacts){
                //踏んだとき
                if(p.point.y<judgePos)
                {
                    this.rigid2D.AddForce(transform.up*this.stepForce);
                    Debug.Log("踏んだよ");
                    Destroy(collision.gameObject);
                }
                //踏めなかったとき//敵にぶつかったとき
                else{
                    if(transform.localScale.x>0){
                        this.rigid2D.AddForce(transform.right*this.damageForce*(-1));
                    }
                    else{
                        this.rigid2D.AddForce(transform.right*this.damageForce);
                    }
                    
                    this.animator.SetTrigger("HurtTrigger");
                    //GameObject director=GameObject.Find("GameDirector");
                    this.director.GetComponent<GameDirector>().DecreaseHp();
                }

              
                
            }

            

        }

    }
        //経過時間を渡す関数
    public static float passTime(){ 

        float ClearTime=loopTime;
        //経過時間の初期化
        loopTime=0;
        return ClearTime;
    }

    
}
