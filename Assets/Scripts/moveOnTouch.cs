using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOnTouch : MonoBehaviour
{
    private  gamePlayManager gaM;
    private bool collied = false;
    public AudioSource minus;
    // Start is called before the first frame update
    void Start()
    {
        gaM = GameObject.FindObjectOfType<gamePlayManager>();
         GetComponent<AudioSource> ().clip = minus;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name=="BowlingBall"&&!collied) {
            collied = true;
            gaM.updateoCount(collied);
             GetComponent<AudioSource>().Play();
            
                
            
        }
    }
    void Update()
    {
         if (collied) {
            transform.Translate(Vector3.forward);
        }
    }
     public void ChangeScale(int w){
            if(w<100){
            transform.localScale = new Vector3((float)0.6,(float) 0.6,(float) 0.6);
            }
            else if(w>=100&&w<200){
            transform.localScale = new Vector3((float)0.5, (float)0.5, (float)0.5);
            }
            else if(w>=200&&w<300){
             transform.localScale = new Vector3((float)0.4, (float)0.4,(float) 0.4);
            }
             else if(w>=300&&w<400){
             transform.localScale = new Vector3((float)0.3, (float)0.3,(float) 0.3);
            }
     }
}
