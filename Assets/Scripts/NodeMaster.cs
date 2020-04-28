using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeMaster : MonoBehaviour
{
    public GameObject Title_obj=null;
    public GameObject Comment_obj=null;
    public GameObject Count_obj=null;
    public string pub_Title="";
    public string pub_Comment="";
    public string pub_ID ="";
    public int pub_Count = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    bool flag=true;

    public void ViewData(string title,string comment,int count,string ID){
        if(flag){
            Text Title_text = Title_obj.GetComponent<Text>();
            Text Comment_text = Comment_obj.GetComponent<Text>();
            Text Count_Text = Count_obj.GetComponent<Text>();
            pub_Title=title;
            pub_Comment=comment;
            pub_ID=ID;
            pub_Count=count;
            Title_text.text=title;
            Comment_text.text=comment;
            Count_Text.text=count.ToString();
            flag=false;
        }
    }
}
