﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class HitEvent : MonoBehaviour
{
    public static int max_Combo=0,sum_combo,Combo=0;
    public MicSpectrumAnalyz MicSpectrumanalyz;
    public bool[] key_judg = new bool[88];

    public GameObject Combo_obj;
    
    Transform Text_trans;
    Vector3 beTrans;
    // Start is called before the first frame update
    void Start()
    {   
        Text_trans=Combo_obj.gameObject.transform;
        beTrans=Combo_obj.gameObject.transform.position;
        // key=new bool[88];
        // for(int i=0;i<88;i++){
        //     key[i]=true;
        // }   
    }
    // Update is called once per frame

    public GameObject pauseUIPrefab;
    private GameObject pauseUIInstance;
    bool EscKey=true;
    void Update()
    {
        key_judg=MicSpectrumanalyz.key_judg;

        if(EscKey && Input.GetKey (KeyCode.Escape)){
            EscKey=false;
            if (pauseUIInstance == null) {
				pauseUIInstance = GameObject.Instantiate (pauseUIPrefab) as GameObject;
				Time.timeScale = 0f;
			} else {
				Destroy (pauseUIInstance);
				Time.timeScale = 1f;
			}

        }
        if(Input.GetKeyUp(KeyCode.Escape)){
            EscKey=true;
        }
    }

    public static void FinPlay(){
        max_Combo=System.Math.Max(max_Combo,Combo);
        SceneManager.LoadScene("ScoreScenes");
    }

    public void GetKeyPos(int x,GameObject notu){
        key_judg=MicSpectrumanalyz.key_judg;
        // Debug.Log(x);
        if(key_judg[x]){
            Combo_pro();
            Destroy(notu);
        }
        // print(x);
        // if(key[x]){
        //     // combo加算
        //     Combo++;
        // }
        
    }
    void Combo_pro(){
        sum_combo++;
        Combo++;
        max_Combo=System.Math.Max(Combo,max_Combo);
        Text Combo_Txt=Combo_obj.GetComponent<Text>();
        // Text_trans.(new Vector3(1.5f, 1.5f),0.3f);
        Text_trans.DOScale(new Vector3(1.1f, 1.1f),0.3f).SetEase(Ease.Linear);
        Text_trans.DOScale(new Vector3(1.0f/1.1f, 1.0f/1.1f),0.1f).SetEase(Ease.Linear);
        Combo_Txt.text=Combo+System.Environment.NewLine+"Combo";
    }

    public void fin_Combo(){
        Combo=0;
        Text Combo_Txt=Combo_obj.GetComponent<Text>();
        Combo_Txt.text=" ";
    }

    // void OnCollisionEnter2D(Collision2D collision) {
    //     if (collision.gameObject.GetComponent<KeyEvent>()) {
    //         int x=collision.gameObject.GetComponent<KeyEvent>().return_key();
    //         if(key[x]){
    //             // combo加算
    //             Combo++;
    //             Destroy(collision.gameObject);
    //         }
    //     }
    // }

}
