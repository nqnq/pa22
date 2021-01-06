using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myboard : MonoBehaviour
{
    // Start is called before the first frame update
    public static myboard instance;
    public Text text1;
    public Text text2;
    //public Button ADD;
    //public Button RED;

    public int level_num=1;
    void Start()
    {
      instance = this;
      text1.text="难度一: 障碍物识别";
      text2.text="目标: 障碍物"; 
      //ADD.onClick.AddListener(AddFunction2);
      //RED.onClick.AddListener(RedFunction2);
    }

    // Update is called once per frame
  
      void AddFunction2()
      {
       if(level_num>= 5) 
         return;
       level_num ++;
      }

      void RedFunction2()
      {
       if(level_num<=1) 
         return;
       level_num --; 
     
      }

    
    
    void Update()
    {
      if (level_num==1)
      {
            text1.text="难度一: 障碍物识别";
            text2.text="目标: 障碍物";
      }

      else if (level_num==2)
      {
            text1.text="难度二 : 红洋葱识别";
            text2.text="目标: 障碍物, 红洋葱";
      }

      else if (level_num==3)
      {
            text1.text="难度三: 水果识别";
            text2.text="目标: 障碍物, 水果";
      }

      
       else if (level_num==4)
       {
          if(WebScoketController.instance.num_tar==0)
          {
              text1.text="难度四: 随机目标识别";
              text2.text="目标: 障碍物, 面包";
          }
          else if(WebScoketController.instance.num_tar==1)
          {
              text1.text="难度四: 随机目标识别";
              text2.text="目标: 障碍物, 红洋葱";
          }
          else if(WebScoketController.instance.num_tar==2)
          {
              text1.text="难度四: 随机目标识别";
              text2.text="目标: 障碍物, 柿子";
          }  
          else if(WebScoketController.instance.num_tar==3)
          {
              text1.text="难度四: 随机目标识别";
              text2.text="目标: 障碍物, 梨";
          } 
          else if(WebScoketController.instance.num_tar==4)
          {
              text1.text="难度四: 随机目标识别";
              text2.text="目标: 障碍物, 柠檬";
          } 
          else if(WebScoketController.instance.num_tar==5)
          {
              text1.text="难度四: 随机目标识别";
              text2.text="目标: 障碍物, 奶酪";
          } 
          else if(WebScoketController.instance.num_tar==6)
          {
              text1.text="难度四: 随机目标识别";
              text2.text="目标: 障碍物, 辣椒";
          } 
          else if(WebScoketController.instance.num_tar==7)
          {
              text1.text="难度四: 随机目标识别";
              text2.text="目标: 障碍物, 大肉";
          }

       }

      else if (level_num==5)
      {
          if(WebScoketController.instance.num_tar==0)
          {
              text1.text="难度五: 随机目标识别";
              text2.text="目标: 障碍物, 面包";
          }
          else if(WebScoketController.instance.num_tar==1)
          {
              text1.text="难度五: 随机目标识别";
              text2.text="目标: 障碍物, 红洋葱";
          }
          else if(WebScoketController.instance.num_tar==2)
          {
              text1.text="难度五: 随机目标识别";
              text2.text="目标: 障碍物, 柿子";
          }  
          else if(WebScoketController.instance.num_tar==3)
          {
              text1.text="难度五: 随机目标识别";
              text2.text="目标: 障碍物, 梨";
          } 
          else if(WebScoketController.instance.num_tar==4)
          {
              text1.text="难度五: 随机目标识别";
              text2.text="目标: 障碍物, 柠檬";
          } 
          else if(WebScoketController.instance.num_tar==5)
          {
              text1.text="难度五: 随机目标识别";
              text2.text="目标: 障碍物, 奶酪";
          } 
          else if(WebScoketController.instance.num_tar==6)
          {
              text1.text="难度五: 随机目标识别";
              text2.text="目标: 障碍物, 辣椒";
          } 
          else if(WebScoketController.instance.num_tar==7)
          {
              text1.text="难度五: 随机目标识别";
              text2.text="目标: 障碍物, 大肉";
          }

      }
        
    }
    
}
