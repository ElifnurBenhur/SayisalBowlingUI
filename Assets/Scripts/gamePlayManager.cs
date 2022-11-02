

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gamePlayManager : MonoBehaviour
{
    private TMP_Text oCountText;
    private int oCount = 10;
    private int hedef;
    private string kalan;
     public AudioClip right,wrong,res;
    private string resTxt;
    void Start()
    {
        
        oCountText= GameObject.Find("Scores").GetComponent<TMP_Text>();
        kalan="10";
        hedef = Random.Range(0, 10);

    }
    void Update()
    {
        kalan=oCount.ToString();
        oCountText.text = "Hedef: "+hedef+" \nKalan: " + kalan +"\n"+setAns();
     }


    public void updateoCount(bool collied)
    {
        if (collied)
        {
            oCount--;
            
        }

    }
   
    string setAns()
    {
        
            if (oCount == hedef)
            {
                resTxt = "!!!DOGRU!!!";

            }
            else if(oCount<hedef)
            {
                resTxt = "_ULASAMADIN_";
            }
    
           else if (oCount>hedef)
        {
            resTxt = "...Yanit Bekliyor...";
        }
        return resTxt;
    }
   
}
