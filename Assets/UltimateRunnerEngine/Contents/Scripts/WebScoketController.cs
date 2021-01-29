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
    private int clock_tar=0;
    public int result_num=0;
    public int  num_tar=0;
    public int tar_times=0;

    public string msg;
    public string msg2;
    //public string msg3;
    public int tar_distance;
    System.Random r = new System.Random();
    void Awake()
    {
        Connect(url);
        instance=this;
        tar_distance=50;
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

    }

    void OnOpen(WebSocket ws)
    {
        Debug.Log("连接成功");
        num_tar=TrackGenerator.instance.Set_tar();
        Debug.Log(num_tar*100);
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


    void OnMessageReceived(WebSocket ws, string msg_rv)

    {    
        //var GlobalConstants=new GlobalConstants();
         string []msg_arr=msg_rv.Split(',');
         msg=msg_arr[0];
         msg2=msg_arr[1];
        // msg3=msg_arr[2];
        // Debug.Log(msg_rv);

        //Debug.Log(tar_times*10000);
        //Debug.Log(level.instance.value_level);
         //myboard.instance.level_num=int.Parse(msg3);

        //游戏难度一
        if (myboard.instance.level_num==1)
        {
            if (msg == "01")
           {
            result_num=result_num+1;
            TrackGenerator.instance.SetGold(GlodType.ob, 120, 5f);        
		   }
           if (msg == "02")
          {
            result_num=result_num+1;
            TrackGenerator.instance.SetGold(GlodType.ob, 120, 5f);   
		  }

          if (msg == "03")
          {
            result_num=result_num+1;
            TrackGenerator.instance.SetGold(GlodType.ob, 120, 5f);   
		  }

         if (msg == "04"||msg == "05")
         {
            result_num=result_num+1;
            TrackGenerator.instance.SetGold(GlodType.Blue, tar_distance, 3f);
            TrackGenerator.instance.SetGold(GlodType.ob, 120, 5f);    
		 }

          if (msg == "06")
       {
            result_num=result_num+1;
            TrackGenerator.instance.SetGold(GlodType.Yellow, tar_distance, 3f);
            TrackGenerator.instance.SetGold(GlodType.ob, 120, 5f);
		 }
         if (msg == "07")
         {
            result_num=result_num+1;
            PowerupController.instance.SetGolds(3);
         }
         else if(msg == "11")
         {
            speedtemp=30;
         }

         else if(msg == "12") 
         {
            speedtemp=30;
         }

         else if(msg == "13") 
         {
            speedtemp=30;
         }

         else if(msg == "14") 
         {
            speedtemp =35;
         }

         else if(msg == "15") 
         {
            speedtemp=40;
         }

         else if(msg == "16") 
         {
            speedtemp=45;
         }
         else if(msg == "17") 
         {
            speedtemp=50;
         }
         else if(msg == "18") 
         {
            speedtemp =55;
         }
         else if(msg == "19") 
         {
            speedtemp =60;
         }
         else if(msg == "20") 
         { 
           speedtemp = 65;
         }
         else if (msg == "10") 
         {
            GameGlobals.Instance.pauseGameState.ExecuteAll();  
         }
         else if (msg == "25" || msg == "26" ) 
         {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
         }

         // else if (msg == "1111")
         // {
         //     // SetObscate[] o = FindObjectsOfType<SetObscate>();
         //     // foreach (SetObscate item in o)
         //     // {
         //     //     // x 6.5    z 10-220
         //     //     item.SetObstruct(-6.5f, 100f);
         //     // }
         // }
        }

        //游戏难度二
    
        if (myboard.instance.level_num==2)
        {
         if (msg == "01")
         {
            result_num=result_num+1;
            TrackGenerator.instance.SetGold(GlodType.Yellow, tar_distance, 3f);       
		   }

         if (msg == "02")
         {
            result_num=result_num+1;
			TrackGenerator.instance.SetGold(GlodType.Blue, tar_distance, 3f);
		   }

         if (msg == "03")
         {
            result_num=result_num+1;
			   TrackGenerator.instance.SetGold(GlodType.Red, tar_distance, 3f);
		   }

         if (msg == "04"||msg == "05")
         {
            result_num=result_num+1;
            TrackGenerator.instance.SetGold(GlodType.Yellow, tar_distance, 3f);
            TrackGenerator.instance.SetGold(GlodType.ob, 120, 5f);    
		   }

          if (msg == "06")
         {
            result_num=result_num+1;
			   TrackGenerator.instance.SetGold(GlodType.Red, tar_distance, 3f);
            TrackGenerator.instance.SetGold(GlodType.ob, 120, 5f);
		   }

         if (msg == "07")
         {
            result_num=result_num+1;
            PowerupController.instance.SetGolds(3);
         }
         else if(msg == "11")
         {
            speedtemp=30;
         }

         else if(msg == "12") 
         {
            speedtemp=30;
         }

         else if(msg == "13") 
         {
            speedtemp=30;
         }

         else if(msg == "14") 
         {
            speedtemp =35;
         }

         else if(msg == "15") 
         {
            speedtemp =40;
         }

         else if(msg == "16") 
         {
            speedtemp=45;
         }
         else if(msg == "17") 
         {
            speedtemp=50;
         }
         else if(msg == "18") 
         {
            speedtemp=55;
         }
         else if(msg == "19") 
         {
            speedtemp=60;
         }
         else if(msg == "20") 
         { 
           speedtemp=65;
         }
         else if (msg == "10") 
         {
            GameGlobals.Instance.pauseGameState.ExecuteAll();  
         }
         else if (msg == "25" || msg == "26" ) 
         {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
         }

         // else if (msg == "1111")
         // {
         //     // SetObscate[] o = FindObjectsOfType<SetObscate>();
         //     // foreach (SetObscate item in o)
         //     // {
         //     //     // x 6.5    z 10-220
         //     //     item.SetObstruct(-6.5f, 100f);
         //     // }
         // }
        }

        //游戏难度三
    
        if (myboard.instance.level_num==3)
        {
            if (msg == "01")
           {
            result_num=result_num+1;
            TrackGenerator.instance.SetGold2(GlodType.Yellow, tar_distance, 3f);       
		    }
           if (msg == "02")
          {
            result_num=result_num+1;
			   TrackGenerator.instance.SetGold2(GlodType.Blue, tar_distance, 3f);
		    }

          if (msg == "03")
          {
            result_num=result_num+1;
			   TrackGenerator.instance.SetGold2(GlodType.Red, tar_distance, 3f);
		    }

         if (msg == "04"||msg == "05")
         {
            result_num=result_num+1;
            TrackGenerator.instance.SetGold2(GlodType.Yellow, tar_distance, 3f);
            TrackGenerator.instance.SetGold2(GlodType.ob, 120, 5f);    
		    }

          if (msg == "06")
         {
            result_num=result_num+1;
			   TrackGenerator.instance.SetGold2(GlodType.Red, tar_distance, 3f);
            TrackGenerator.instance.SetGold2(GlodType.ob, 120, 5f);
		    }
         if (msg == "07")
         {
            result_num=result_num+1;
            PowerupController.instance.SetGolds(3);
         }
         else if(msg == "11")
         {
            speedtemp=30;
         }

         else if(msg == "12") 
         {
            speedtemp=30;
         }

         else if(msg == "13") 
         {
            speedtemp=30;
         }

         else if(msg == "14") 
         {
            speedtemp =35;
         }

         else if(msg == "15") 
         {
            speedtemp =40;
         }

         else if(msg == "16") 
         {
            speedtemp = 45;
         }
         else if(msg == "17") 
         {
            speedtemp = 50;
         }
         else if(msg == "18") 
         {
            speedtemp =55;
         }
         else if(msg == "19") 
         {
            speedtemp = 60;
         }
         else if(msg == "20") 
         { 
           speedtemp = 65;
         }
         else if (msg == "10") 
         {
            GameGlobals.Instance.pauseGameState.ExecuteAll();  
         }
         else if (msg == "25" || msg == "26" ) 
         {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
         }

         // else if (msg == "1111")
         // {
         //     // SetObscate[] o = FindObjectsOfType<SetObscate>();
         //     // foreach (SetObscate item in o)
         //     // {
         //     //     // x 6.5    z 10-220
         //     //     item.SetObstruct(-6.5f, 100f);
         //     // }
         // }
        }

        //游戏难度四
    
        if (myboard.instance.level_num==4)
        {
            if (msg == "01")
           {
             
             result_num=result_num+1;
             TrackGenerator.instance.SetGold3(GlodType.Yellow, tar_distance, 3f,num_tar);       
		    }
           if (msg == "02")
          {
            result_num=result_num+1;
			   TrackGenerator.instance.SetGold3(GlodType.Blue, tar_distance, 3f,num_tar);
		    }

          if (msg == "03")
          {
            if (tar_times==5)
            {
               num_tar=TrackGenerator.instance.Set_tar();
               Debug.Log(num_tar*100);
               tar_times=0;
               clock_tar=r.Next(0,2);
            }
            
            if (clock_tar==0)
            {
              result_num=result_num+1;
			     TrackGenerator.instance.SetGold3(GlodType.Red, tar_distance, 3f,num_tar);
              TrackGenerator.instance.SetGold3(GlodType.ob, 120, 5f,num_tar);
              tar_times+=1;
              clock_tar=0;
            }

            else if(clock_tar==1)
            {
              result_num=result_num+1;
			     TrackGenerator.instance.SetGold3(GlodType.Yellow, tar_distance, 3f,num_tar);
              TrackGenerator.instance.SetGold3(GlodType.ob, 120, 5f,num_tar);
              tar_times+=1;
              clock_tar=0;
            }
       
		   } 

         if (msg == "04"||msg == "05")
         {
            result_num=result_num+1;
            TrackGenerator.instance.SetGold3(GlodType.Yellow,tar_distance, 3f, num_tar);
            TrackGenerator.instance.SetGold3(GlodType.ob, 120, 5f, num_tar);    
		  }

          if (msg == "06")
         {
            result_num=result_num+1;
            if (tar_times==5)
            {
               num_tar=TrackGenerator.instance.Set_tar();
               Debug.Log(num_tar*100);
               tar_times=0;
               clock_tar=r.Next(0,2);
            }

            if (clock_tar==0)
            {
              result_num=result_num+1;
			     TrackGenerator.instance.SetGold3(GlodType.Red, tar_distance, 3f,num_tar);
              TrackGenerator.instance.SetGold3(GlodType.ob, 120, 5f,num_tar);
              tar_times+=1;
              clock_tar=0;
            }

            else if(clock_tar==1)
            {
              result_num=result_num+1;
			     TrackGenerator.instance.SetGold3(GlodType.Yellow, tar_distance, 3f,num_tar);
              TrackGenerator.instance.SetGold3(GlodType.ob, 120, 5f,num_tar);
              tar_times+=1;
              clock_tar=0;
            }
			
		  }
         if (msg == "07")
         {
            result_num=result_num+1;
            PowerupController.instance.SetGolds(3);
         }
         else if(msg == "11")
         {
            speedtemp=30;
         }

         else if(msg == "12") 
         {
            speedtemp=30;
         }

         else if(msg == "13") 
         {
            speedtemp=30;
         }

         else if(msg == "14") 
         {
            speedtemp =35;
         }

         else if(msg == "15") 
         {
            speedtemp =40;
         }

         else if(msg == "16") 
         {
            speedtemp = 45;
         }
         else if(msg == "17") 
         {
            speedtemp = 50;
         }
         else if(msg == "18") 
         {
            speedtemp =55;
         }
         else if(msg == "19") 
         {
            speedtemp = 60;
         }
         else if(msg == "20") 
         { 
           speedtemp = 65;
         }
         else if (msg == "10") 
         {
            GameGlobals.Instance.pauseGameState.ExecuteAll();  
         }
         else if (msg == "25" || msg == "26" ) 
         {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
         }

         // else if (msg == "1111")
         // {
         //     // SetObscate[] o = FindObjectsOfType<SetObscate>();
         //     // foreach (SetObscate item in o)
         //     // {
         //     //     // x 6.5    z 10-220
         //     //     item.SetObstruct(-6.5f, 100f);
         //     // }
         // }
        }

         //游戏难度五
    
        if (myboard.instance.level_num==5)
        {
            if (msg == "01")
           {
             
             result_num=result_num+1;
             TrackGenerator.instance.SetGold4(GlodType.Yellow, tar_distance, 3f,num_tar);       
		     }
           if (msg == "02")
          {
            result_num=result_num+1;
			   TrackGenerator.instance.SetGold4(GlodType.Blue, tar_distance, 3f,num_tar);
		    }  

          if (msg == "03")
          {
            if (tar_times==5)
            {
               num_tar=TrackGenerator.instance.Set_tar();
               Debug.Log(num_tar*100);
               tar_times=0;
               clock_tar=r.Next(0,2);
            }

            if (clock_tar==0)
            {
              result_num=result_num+1;
			     TrackGenerator.instance.SetGold4(GlodType.Red, tar_distance, 3f,num_tar);
              TrackGenerator.instance.SetGold4(GlodType.ob, 120, 5f,num_tar);
              tar_times+=1;
              clock_tar=0;
            }

            else if(clock_tar==1)
            {
              result_num=result_num+1;
			     TrackGenerator.instance.SetGold4(GlodType.Yellow, tar_distance, 3f,num_tar);
              TrackGenerator.instance.SetGold4(GlodType.ob, 120, 5f,num_tar);
              tar_times+=1;
              clock_tar=0;
            } 
         
		    }

         if (msg == "04"||msg == "05")
         {
            result_num=result_num+1;
            TrackGenerator.instance.SetGold4(GlodType.Yellow, tar_distance, 3f, num_tar);
            TrackGenerator.instance.SetGold4(GlodType.ob, 120, 5f, num_tar);    
		   }

          if (msg == "06")
          {
            if (tar_times==5)
            {
               num_tar=TrackGenerator.instance.Set_tar();
               Debug.Log(num_tar*100);
               tar_times=0;
               clock_tar=r.Next(0,2);
            }
            if (clock_tar==0)
            {
              result_num=result_num+1;
			     TrackGenerator.instance.SetGold4(GlodType.Red, tar_distance, 3f,num_tar);
              TrackGenerator.instance.SetGold4(GlodType.ob, 120, 5f,num_tar);
              tar_times+=1;
              clock_tar=0;
            }

            else if(clock_tar==1)
            {
              result_num=result_num+1;
			     TrackGenerator.instance.SetGold4(GlodType.Yellow, tar_distance, 3f,num_tar);
              TrackGenerator.instance.SetGold4(GlodType.ob, 120, 5f,num_tar);
              tar_times+=1;
              clock_tar=0;
            }      
		    }

          if (msg == "07")
          {
            result_num=result_num+1;
            PowerupController.instance.SetGolds(3);
          }
          else if(msg == "11")
          {
            speedtemp=30;
          }

          else if(msg == "12") 
          {
            speedtemp=30;
          }

          else if(msg == "13") 
          {
            speedtemp=30;
          }

          else if(msg == "14") 
          {
            speedtemp =35;
          }

          else if(msg == "15") 
          {
            speedtemp =40;
          }

          else if(msg == "16") 
          {
            speedtemp = 45;
          }
          else if(msg == "17") 
          {
            speedtemp = 50;
          }
          else if(msg == "18") 
          {
            speedtemp =55;
          }
          else if(msg == "19") 
          {
            speedtemp = 60;
          }
          else if(msg == "20") 
          { 
           speedtemp = 65;
          }
          else if (msg == "10") 
          {
            GameGlobals.Instance.pauseGameState.ExecuteAll();  
          }
          else if (msg == "25" || msg == "26" ) 
          {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
          }

         // else if (msg == "1111")
         // {
         //     // SetObscate[] o = FindObjectsOfType<SetObscate>();
         //     // foreach (SetObscate item in o)
         //     // {
         //     //     // x 6.5    z 10-220
         //     //     item.SetObstruct(-6.5f, 100f);
         //     // }
         // }
           
        }

    }

  
    public float fireRate=0.3F;
    private float nextFire=0.0F;
    public  string levelstring;

    void Update() 
    {
        //speedtemp=35;
        Controller.instance.currentLevelSpeed = Mathf.Lerp(Controller.instance.currentLevelSpeed, speedtemp, Time.deltaTime);
        levelstring=level.instance.value_level.ToString()+","+myboard.instance.level_num.ToString(); 
        //Debug.Log(levelstring);
        if (Time.time > nextFire) 
        {
            nextFire = Time.time + fireRate;
            if(webSocket != null)
                webSocket.Send(levelstring);  //发送专注度难度
                //Debug.Log("fasong:" + levelstring);     
        }


    }
    
} 
