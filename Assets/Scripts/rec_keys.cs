using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rec_keys : MonoBehaviour
{
    // public GameObject A0,Ash0,B0;
    // public GameObject C1,Csh1,D1,Dsh1,E1,F1,Fsh1,G1,Gsh1,A1,Ash1,B1;
    // public GameObject C2,Csh2,D2,Dsh2,E2,F2,Fsh2,G2,Gsh2,A2,Ash2,B2;
    // public GameObject C3,Csh3,D3,Dsh3,E3,F3,Fsh3,G3,Gsh3,A3,Ash3,B3;
    // public GameObject C4,Csh4,D4,Dsh4,E4,F4,Fsh4,G4,Gsh4,A4,Ash4,B4;
    // public GameObject C5,Csh5,D5,Dsh5,E5,F5,Fsh5,G5,Gsh5,A5,Ash5,B5;
    // public GameObject C6,Csh6,D6,Dsh6,E6,F6,Fsh6,G6,Gsh6,A6,Ash6,B6;
    // public GameObject C7,Csh7,D7,Dsh7,E7,F7,Fsh7,G7,Gsh7,A7,Ash7,B7;
    // public GameObject C8;

    public GameObject[] keysChColor=new GameObject[88];
    public MicSpectrumAnalyz MicSpectrumAnalyz;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool[] keys=MicSpectrumAnalyz.key_judg;
        for(int i=0;i<88;i++){
            if(keys[i]){
                keysChColor[i].GetComponent<Renderer>().material.color = Color.blue;
            }
            else{
                keysChColor[i].GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }
}
