using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    Rigidbody2D frogRigid;
    Animator frogAnimator;
    float jumpForce=300.0f;
    float jumpSpan=4.0f;
    float addedTime=0;

    //Start is called before the first frame update
    void Start()
    {

        this.frogRigid=GetComponent<Rigidbody2D>();
        this.frogAnimator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        this.addedTime+=Time.deltaTime;
        if(addedTime>jumpSpan){
            addedTime=0;
            this.frogAnimator.SetTrigger("JumpTrigger");
            this.frogRigid.AddForce(transform.up*jumpForce);
        }
        // if(frogRigid.velocity.y>0.1){
        //     this.frogAnimator.SetTrigger("JumpTrigger");
        // }
        // if(frogRigid.velocity.y<-0.1){
        //     this.frogAnimator.SetTrigger("LandTrigger");
        // }

        
    }
}
