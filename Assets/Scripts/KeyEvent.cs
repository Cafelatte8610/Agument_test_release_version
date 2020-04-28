using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class KeyEvent : MonoBehaviour
{

    public Vector3 tmp;
    bool fin=true;
    public GameObject HitEvent;

    // public MicSpectrumAnalyz MicSpectrumAnalyz;
    void Start(){
        tmp = this.gameObject.transform.position;
        Vector3 moveto= new Vector3(tmp.x,-130,tmp.z);
        var transF=this.gameObject.transform;
        transF.DOMove(moveto,3f).SetEase(Ease.Linear);
    }
    public void GetObj(GameObject Cube){
        HitEvent=Cube;
        // Debug.Log("Corect");
    }
    // public bool[] key= new bool[88];

    int[] key_pos={ -162 , -159 , -156 , -150 , -147 , -144 , -141 , -138 , -132 , -129 , -126 , -123 , -120 , -117 , -114 , -108 , -105 , -102 , -99 , -96 , -90 , -87 , -84 , -81 , -78 , -75 , -72 , -66 , -63 , -60 , -57 , -54 , -48 , -45 , -42 , -39 , -36 , -33 , -30 , -24 , -21 , -18 , -15 , -12 , -6 , -3 , 0 , 3 , 6 , 9 , 12 , 18 , 21 , 24 , 27 , 30 , 36 , 39 , 42 , 45 , 48 , 51 , 54 , 60 , 63 , 66 , 69 , 72 , 78 , 81 , 84 , 87 , 90 , 93 , 96 , 102 , 105 , 108 , 111 , 114 , 120 , 123 , 126 , 129 , 132 , 135 , 138 , 144};    



    void Update(){
        if(HitEvent==null) Destroy(this.gameObject);
        tmp = this.gameObject.transform.position;
        // bool[] Key=MicSpectrumAnalyz.key_judg;
        if(tmp.y<-57f && tmp.y>-63f) {
            // if(Key[(int)(tmp.x/5)+69]){
            //     Destroy(this.gameObject);
            // }
            HitEvent.GetComponent<HitEvent>().GetKeyPos(BinarySearch(key_pos,(int)tmp.x),this.gameObject);
            // HitEvent.GetKeyPos((int)(tmp.x/5)+69,this.gameObject);
        }
        if(fin && tmp.y<=-88f){
            fin=false;
            HitEvent.GetComponent<HitEvent>().fin_Combo();
        }
        if(tmp.y<-120f) Destroy(this.gameObject);
    }

    int BinarySearch(int[] array, int target){ //二分探索
        var left = 0;
        var right = array.Length - 1;
        while (left <= right){

            int mid = left + (right - left) / 2;
            int mid_ele = array[mid];
            if (mid_ele == target){
                return mid;
            }
            else if (mid_ele < target){
                left = mid + 1;
            }
            else{
                right = mid - 1;
            }
        }
        return -1;
    }
}
