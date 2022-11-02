using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCvSharp;
using UnityEngine.SceneManagement;

public class FaceDetector : MonoBehaviour
{
    WebCamTexture _wCamT;
    CascadeClassifier cascade;
    OpenCvSharp.Rect myFace;
   public float faceY;
  public  float faceX;
  BallController bc;
  moveOnTouch mt;
  restartGame rg;
    // Start is called before the first frame update
    void Start()
    {
        WebCamDevice[] devices=WebCamTexture.devices;
        bc=GameObject.FindObjectOfType<BallController>();
        mt=GameObject.FindObjectOfType<moveOnTouch>();
        rg=GameObject.FindObjectOfType<restartGame>();
        _wCamT=new WebCamTexture(devices[0].name);
        _wCamT.Play();
        cascade = new CascadeClassifier("Assets/OpenCV+Unity/Demo/Face_Detector/haarcascade_frontalface_default.xml");
    }

    // Update is called once per frame
    void Update()
    {
       // GetComponent<Renderer>().material.mainTexture=_wCamT;
        Mat frame = OpenCvSharp.Unity.TextureToMat(_wCamT);
        findNewFace(frame);
        display(frame);
        if(rg.restart){
                _wCamT.Stop();
                rg.restart=false;
               SceneManager.LoadScene("SayisalBowlingIntro");
        }
    }
       void findNewFace(Mat frame)
    {
        var faces = cascade.DetectMultiScale(frame, 1.1, 2, HaarDetectionType.ScaleImage); //!!!!
        if (faces.Length >= 1)
        {
            Debug.Log(faces[0].Width);
            myFace = faces[0];
            faceX= faces[0].X;
            faceY=faces[0].Y;
            bc.UpdateLocation(faceX,faceY);
            mt.ChangeScale(faces[0].Width);
        }
    }

    void display(Mat frame)
    {
        if (myFace != null)
        {
            frame.Rectangle(myFace, new Scalar(250, 0, 0, 0), 2);
        }
        Texture nText = OpenCvSharp.Unity.MatToTexture(frame);
        GetComponent<Renderer>().material.mainTexture = nText;
    }
}
