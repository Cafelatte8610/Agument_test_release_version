using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;

public class MusicViewer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    public GameObject NodeParent;
    void Start(){
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("MusicData");
        query.OrderByDescending("PlayCount");
        query.Limit = 100;
        query.FindAsync ((List<NCMBObject> MusicList ,NCMBException e) => {
            if (e != null) {
                Debug.Log("検索失敗時の処理");
                //検索失敗時の処理
            } else {
                foreach (NCMBObject Data in MusicList) {
                    // Debug.Log(Data["Title"]);
                    // Debug.Log(Data["Comment"]);
                    // Debug.Log(Data["PlayCount"]);
                    GameObject MusicNode = Instantiate (prefab, transform.position, transform.rotation) as GameObject;
                    MusicNode.transform.SetParent(NodeParent.transform);
                    NodeMaster node =  MusicNode.GetComponent<NodeMaster>();
                    node.ViewData( (Data["Title"]).ToString() , (Data["Comment"]).ToString() , System.Convert.ToInt32(Data["PlayCount"]) , (Data["ID"]).ToString() );
                    // Node.ViewData(Data["Title"].ToString(),Data["Comment"].ToString(),(int)Data["PlayCount"]);
                }
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
