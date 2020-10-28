using BestHTTP.WebSocket;
using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
#if UNITY_EDITOR
using UnityEditor;
using System.Threading;
#endif

// static do_time(){


// }

public  static class GlobalConstants
{
    public  static float speed_tar=25;
    public  static float speed_rc=25;
    public static float speed_cha=0;
    public static float speed_a=5;
    public static float clock=1;
    public static float speed_t=0;
    public static float clock_num=0;

}


public class WebScoketController : MonoBehaviour
{

    private WebSocket webSocket;
    public static WebScoketController instance;

    [HideInInspector]
    public float trainTotalTime;

    public string url;
    
    private Tweener tweener;

    private int speedtemp = 0;

    private int result_num=0;
    void Awake()
    {
        Connect(url);
    }

    public void Connect(string str)
    {
        var url = new Uri(str);
        Debug.Log(url);
        webSocket = new WebSocket(url);
        webSocket.OnOpen += OnOpen;
        webSocket.OnMessage += OnMessageReceived;
        webSocket.OnError += OnError;
        webSocket.OnClosed += OnClosed;
        webSocket.Open();
    }

    private void Exit()
    {
        webSocket.OnOpen = null;
        webSocket.OnMessage = null;
        webSocket.OnError = null;
        webSocket.OnClosed = null;
        webSocket = null;

// #if UNITY_EDITOR
//         UnityEditor.EditorApplication.isPlaying = false;
// #else
//         Application.Quit();
// #endif
    }

    void OnOpen(WebSocket ws)
    {
        Debug.Log("连接成功");
        // GameState.instance.ExecuteAll();
    }

    void OnClosed(WebSocket ws, UInt16 code, string msg)
    {
        Debug.Log("closed");
        Exit();
    }

    void OnError(WebSocket ws, Exception ex)
    {
        string errorMsg = string.Empty;
#if !UNITY_WEBGL || UNITY_EDITOR
        if (ws.InternalRequest.Response != null)
            errorMsg = string.Format("Status Code from Server: {0} and Message: {1}", ws.InternalRequest.Response.StatusCode, ws.InternalRequest.Response.Message);
#endif
        Exit();
    }


    void OnMessageReceived(WebSocket ws, string msg)

    {
        //var GlobalConstants=new GlobalConstants();
        Debug.Log(msg);
        if (msg == "21")
        {
            TouchController.instance.sSwipeDirection = SwipeDirection.Up;
        }

        else if (msg == "22")
        {
            TouchController.instance.sSwipeDirection = SwipeDirection.Down;
        }

        else if (msg == "23")
        {
            TouchController.instance.sSwipeDirection = SwipeDirection.Left;
        }

        else if (msg == "24")
        {
            TouchController.instance.sSwipeDirection = SwipeDirection.Right;
        }
       
        if (msg == "01")

        {
            result_num=result_num+1;
			// PowerupController.instance.SetGolds(1);
			TrackGenerator.instance.SetGold(GlodType.Yellow, 45, UnityEngine.Random.Range(0f, 100f));
		}

        if (msg == "02")

        {
            result_num=result_num+1;
			// PowerupController.instance.SetGolds(1);
			TrackGenerator.instance.SetGold(GlodType.Blue, 45, UnityEngine.Random.Range(0f, 100f));
		}

        if (msg == "03")

        {
            result_num=result_num+1;
			//powerupController.instance.SetGolds(1);
			TrackGenerator.instance.SetGold(GlodType.Red, 45, UnityEngine.Random.Range(0f, 100f));
		}

       if (msg == "07")
        {
            result_num=result_num+1;
            PowerupController.instance.SetGolds(2);
        }
        
        else if(msg == "11") {
           // Controller.instance.currentLevelSpeed=30;
            speedtemp=35;
            GlobalConstants.speed_tar=35;
            GlobalConstants.speed_t=System.Math.Abs(GlobalConstants.speed_tar-GlobalConstants.speed_rc)/GlobalConstants.speed_a;
            GlobalConstants.speed_rc=GlobalConstants.speed_tar;
            GlobalConstants.clock=0;
        }

        else if(msg == "12") {
            speedtemp= 40;
            //Controller.instance.currentLevelSpeed=32;
            GlobalConstants.speed_tar=40;
            GlobalConstants.speed_t=System.Math.Abs(GlobalConstants.speed_tar-GlobalConstants.speed_rc)/GlobalConstants.speed_a;
            GlobalConstants.speed_rc=GlobalConstants.speed_tar;
            GlobalConstants.clock=0;
        }

       else if(msg == "13") {
           speedtemp= 45;
            //Controller.instance.currentLevelSpeed=34;
            GlobalConstants.speed_tar=45;
            GlobalConstants.speed_t=System.Math.Abs(GlobalConstants.speed_tar-GlobalConstants.speed_rc)/GlobalConstants.speed_a;
            GlobalConstants.speed_rc=GlobalConstants.speed_tar;
            GlobalConstants.clock=0;
        }

       else if(msg == "14") {
           // Controller.instance.currentLevelSpeed=36;
            speedtemp = 50;
            GlobalConstants.speed_tar=50;
            GlobalConstants.speed_t=System.Math.Abs(GlobalConstants.speed_tar-GlobalConstants.speed_rc)/GlobalConstants.speed_a;
            GlobalConstants.speed_rc=GlobalConstants.speed_tar;
            GlobalConstants.clock=0;
        }

       else if(msg == "15") {
           // Controller.instance.currentLevelSpeed=38;
           speedtemp = 55;
            GlobalConstants.speed_tar=55;
            GlobalConstants.speed_t=System.Math.Abs(GlobalConstants.speed_tar-GlobalConstants.speed_rc)/GlobalConstants.speed_a;
            GlobalConstants.speed_rc=GlobalConstants.speed_tar;
            GlobalConstants.clock=0;
        }

       else if(msg == "16") {
            //Controller.instance.currentLevelSpeed=40;
            speedtemp = 60;
            GlobalConstants.speed_tar=60;
            GlobalConstants.speed_t=System.Math.Abs(GlobalConstants.speed_tar-GlobalConstants.speed_rc)/GlobalConstants.speed_a;
            GlobalConstants.speed_rc=GlobalConstants.speed_tar;
            GlobalConstants.clock=0;
        }

       else if(msg == "17") {
           // Controller.instance.currentLevelSpeed=44;
           speedtemp = 65;
            GlobalConstants.speed_tar=65;
            GlobalConstants.speed_t=System.Math.Abs(GlobalConstants.speed_tar-GlobalConstants.speed_rc)/GlobalConstants.speed_a;
            GlobalConstants.speed_rc=GlobalConstants.speed_tar;
            GlobalConstants.clock=0;
        }

       else if(msg == "18") {
           // Controller.instance.currentLevelSpeed=46;
           speedtemp =70;
            GlobalConstants.speed_tar=70;
            GlobalConstants.speed_t=System.Math.Abs(GlobalConstants.speed_tar-GlobalConstants.speed_rc)/GlobalConstants.speed_a;
            GlobalConstants.speed_rc=GlobalConstants.speed_tar;
            GlobalConstants.clock=0;
        }

       else if(msg == "19") {
           // Controller.instance.currentLevelSpeed=48;
           speedtemp = 75;
            GlobalConstants.speed_tar=75;
            GlobalConstants.speed_t=System.Math.Abs(GlobalConstants.speed_tar-GlobalConstants.speed_rc)/GlobalConstants.speed_a;
            GlobalConstants.speed_rc=GlobalConstants.speed_tar;
            GlobalConstants.clock=0;
        }

        else if(msg == "20") {
            speedtemp = 80;
           // Controller.instance.currentLevelSpeed=50;
            GlobalConstants.speed_tar=80;
            GlobalConstants.speed_t=System.Math.Abs(GlobalConstants.speed_tar-GlobalConstants.speed_rc)/GlobalConstants.speed_a;
            GlobalConstants.speed_rc=GlobalConstants.speed_tar;
            GlobalConstants.clock=0;
        }

        else if (msg == "10")
        {
            //#if UNITY_EDITOR
           // UnityEditor.EditorApplication.isPlaying = false;
            //#else
           // Application.Quit();
           // #endif
         
            GameGlobals.Instance.pauseGameState.ExecuteAll();
        }
        // tweener.Kill();
        // tweener = DOTween.To(() => Controller.instance.currentLevelSpeed, x => Controller.instance.currentLevelSpeed = x, speedtemp, 0.4f).SetEase(Ease.Linear);
        // speed_change();
    }

    void Update() 
    {
        Controller.instance.currentLevelSpeed = Mathf.Lerp(Controller.instance.currentLevelSpeed, speedtemp, Time.deltaTime);
    }

    void speed_change()
    {   
        //if(SceneManager.GetActiveScene().name != "Main") return;
      if (GlobalConstants.clock==0)
      { 
        if (Controller.instance.currentLevelSpeed<GlobalConstants.speed_tar){ 
           Controller.instance.currentLevelSpeed=Controller.instance.currentLevelSpeed+ GlobalConstants.speed_a*GlobalConstants.speed_t/3;
          if(Controller.instance.currentLevelSpeed>=GlobalConstants.speed_tar){
               if(Controller.instance.currentLevelSpeed>=80){
                   Controller.instance.currentLevelSpeed=80;
               }
               GlobalConstants.clock_num+=GlobalConstants.clock_num;
              // return;
          }
      } 

      else if (Controller.instance.currentLevelSpeed>GlobalConstants.speed_tar){ 
          Controller.instance.currentLevelSpeed=Controller.instance.currentLevelSpeed-GlobalConstants.speed_a*GlobalConstants.speed_t/3;
          if(Controller.instance.currentLevelSpeed<=GlobalConstants.speed_tar){
               if(Controller.instance.currentLevelSpeed<=35){
                   Controller.instance.currentLevelSpeed=35;
               }
               GlobalConstants.clock_num+=GlobalConstants.clock_num;
               //return;
          }
       } 

       else{
               GlobalConstants.clock_num+=GlobalConstants.clock_num;
              // return;
           }


        if(GlobalConstants.clock_num==3){
            GlobalConstants.clock_num=0;
            GlobalConstants.clock=1;
        } 

      }
        //Debug.Log(Controller.instance.currentLevelSpeed);
    }
}


