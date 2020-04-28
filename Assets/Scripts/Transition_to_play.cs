using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NCMB;

public class Transition_to_play : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static string Titile;
    public static string ID;

    public static string getTitle(){
        return Titile;
    }

    public static string getId(){
        return ID;
    }

    // Update is called once per frameGameObject clickedGameObject;

    GameObject SelectNode;

    Vector3 A,B;
    void Update () {
        if (Input.GetMouseButtonDown(0)) A = Input.mousePosition;
        if (Input.GetMouseButtonUp(0)) {
            B=Input.mousePosition;
            if(A==B){
                SelectNode = null;
                
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
                
                if (hit2d) {
                    SelectNode = hit2d.transform.gameObject;
                    NodeMaster NodeScript = SelectNode.GetComponent<NodeMaster>();
                    Titile=NodeScript.pub_Title;
                    ID=NodeScript.pub_ID;
                    int Count=NodeScript.pub_Count;
                    Debug.Log(Count);

                    NCMBObject data = new NCMBObject("MusicData");
                    data.ObjectId=ID;
                    // Debug.Log(data.ObjectId);
                    data.FetchAsync((NCMBException e) => {        
                        if (e != null) {
                            Debug.Log("Error");
                        } else {
                            // Debug.Log(data[Titile]);
                            data["PlayCount"]=Count+1;
                            data.SaveAsync();
                        }
                    });
                    
                    // Debug.Log(NodeScript.pub_Title);
                    SceneManager.LoadScene("PlayMusic");
                }
            }

        }
    }
}
