using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    
    public AudioSource crash;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().clip = crash;
       // Debug.Log("x:"+transform.position.x+",y:"+transform.position.y+",z:"+transform.position.z);
        
    }

    // Update is called once per frame
   public void UpdateLocation(float x,float y)
    {
        float normX=(float)(((x / 45.5))-1);
        float normZ=(float)(((y / 23)*(-1))+10.86);
        transform.position= new Vector3(normX,(float)0.59,normZ);
        //transform.position= new Vector3(-1,4,4);
        //Debug.Log("x:"+transform.position.x+",y:"+transform.position.y+",z:"+transform.position.z);
        
    }
    void OnCollisionEnter(Collision collision)
    {
        GetComponent<AudioSource>().Play();
    }
}
