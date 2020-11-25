using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class level: MonoBehaviour
{
   public static level instance;
   public Text text;
   public Button ADD;
   public Button RED;

   public  int value_level=1;
   
   void Start()
   {
       instance = this;
       text.text = value_level.ToString();
       ADD.onClick.AddListener(AddFunction);
       RED.onClick.AddListener(RedFunction);
   }

   void AddFunction()
   {
       if(value_level >= 15) return;
       value_level ++;
       text.text = value_level.ToString();
      
   }



   void RedFunction()
   {
       if(value_level <= 1) return;
       value_level --;
       text.text = value_level.ToString();
  
   }

}
