using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlideEagle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=new Vector3(transform.position.x-0.1f,transform.position.y,transform.position.z);
        if(transform.position.x<-13){
            transform.position=new Vector3(13,3,0);

        }
        if(Input.GetMouseButtonDown(0)){
            SceneManager.LoadScene("GameScene3");

        }
    }
}
