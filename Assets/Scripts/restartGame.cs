using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class restartGame : MonoBehaviour
{
    public bool restart;
    // Start is called before the first frame update
    void Start()
    {
      restart=false;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name=="BowlingBall"){
         restart=true;
      
        }
       
    }
}
