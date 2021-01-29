using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class tbr_board : MonoBehaviour
{
    // Start is called before the first frame update
    public static tbr_board instance;
    public Text text1;
    public string  msg_tbr;
   // public float  msg_tbr1;
    //public float sum_tbr;
    //public int tbr_num;
    //public float avg_tbr;

    void Start()
    {
      instance = this;
      text1.text="TBR值:";
      //sum_tbr=0;
      //tbr_num=1;
    }

    // Update is called once per frame
  

    void Update()
    {
      msg_tbr=WebScoketController.instance.msg2;
      //msg_tbr1=float.Parse(msg_tbr);

      //msg_tbr1 = Convert.ToSingle(s);
      //msg_tbr2=Convert.ToDouble(msg_tbr2).ToString("f3");
    
      text1.text="TBR值:"+msg_tbr;
     
    }
    
}
