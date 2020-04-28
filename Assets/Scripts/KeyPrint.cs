using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyPrint : MonoBehaviour
{
    public midi_analyz midi_analyz;
    public GameObject Cube;
    private bool [,] KeyCode;
    // Start is called before the first frame update
    void Start()
    {

    }

    int[] key_pos={ -162 , -159 , -156 , -150 , -147 , -144 , -141 , -138 , -132 , -129 , -126 , -123 , -120 , -117 , -114 , -108 , -105 , -102 , -99 , -96 , -90 , -87 , -84 , -81 , -78 , -75 , -72 , -66 , -63 , -60 , -57 , -54 , -48 , -45 , -42 , -39 , -36 , -33 , -30 , -24 , -21 , -18 , -15 , -12 , -6 , -3 , 0 , 3 , 6 , 9 , 12 , 18 , 21 , 24 , 27 , 30 , 36 , 39 , 42 , 45 , 48 , 51 , 54 , 60 , 63 , 66 , 69 , 72 , 78 , 81 , 84 , 87 , 90 , 93 , 96 , 102 , 105 , 108 , 111 , 114 , 120 , 123 , 126 , 129 , 132 , 135 , 138 , 144};    

    private int i=0;
    private float CrTime;
    bool Ready=false;

    public void PrintStart(){
        KeyCode=midi_analyz.KeyCode;
        Ready=true;
    }

    void Update()
    {
        if(Ready){
            CrTime += Time.deltaTime;
            if(CrTime > 0.1){
                for(int j=0;j<88;j++){
                    if(KeyCode[j,i]){
                        GameObject Notu=(GameObject)Resources.Load("Key");
                        // GameObject Key_obj=Instantiate (Notu, new Vector3((((j+1)-70)*5),150f,-1f), Quaternion.identity) as GameObject;
                        GameObject Key_obj=Instantiate (Notu, new Vector3(key_pos[j],150f,-1f), Quaternion.identity) as GameObject;
                        Key_obj.GetComponent<KeyEvent>().GetObj(Cube);
                    }
                }
                CrTime = 0f;
                i++;
            }
            if(i==midi_analyz.Endtime){
                Invoke("Result", 4.5f);

            }
        }
    }

    void Result(){
        HitEvent.FinPlay();
    }
    
}
