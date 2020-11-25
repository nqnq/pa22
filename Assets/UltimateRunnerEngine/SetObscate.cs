using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObscate : MonoBehaviour
{
    private GameObject oparent;
    void Awake()
    {
        oparent = new GameObject();
        oparent.transform.SetParent(transform);
        oparent.transform.localPosition = Vector3.zero;
    }
    //public static SetObscate instance;
    public List<GameObject> obstructs = new List<GameObject>();
    
    // private GameObject glodParents2;

    // void Awake(){
    //     instance=this;
    // }

    public void SetObstruct(float x, float z,string str)
    {
        GameObject player = GameObject.Find("Player");
        if(gameObject.activeSelf) {
            GameObject ob ;

            for (int i = 0; i < oparent.transform.childCount; i++)
            {
                transform.GetChild(i).transform.localPosition = Vector3.one * 1000;
            }

            if(oparent.transform.Find(str) == null) 
            {
                GameObject oo = null;
                foreach(GameObject item in obstructs)
                {
                    if(item.name == str) {
                        oo = item;
                    }
                }

                ob = GameObject.Instantiate<GameObject>(oo);
                ob.transform.SetParent(oparent.transform);
                ob.name = str;

            } else {
                ob = transform.Find(str).gameObject;
            }
                
            // Vector3 newpos = new Vector3(x, 0,  z);
            Vector3 newpos = new Vector3(x, 0.0f, player.transform.position.z + z);
            ob.transform.position = newpos;
            
        //    CancelInvoke("DisplayGlod2");
        //    Invoke("DisplayGlod2", 1.5f);
        }
    }

    public void DisplayGlod2()        //延迟1.5s消失
    {
        // for (int i = 0; i < glodParents2.transform.childCount; i++)
        // {
        //     Destroy(glodParents2.transform.GetChild(i).gameObject);
        // }
    }

}
