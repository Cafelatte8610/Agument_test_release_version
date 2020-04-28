using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayResult : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ResultText;
    void Start()
    {
        int maxCombo=HitEvent.max_Combo;
        int sumCombo=HitEvent.sum_combo;
        float accuracy=(float)sumCombo/(float)midi_analyz.EventCount;
        ResultText.GetComponent<Text>().text="Result"+System.Environment.NewLine+System.Environment.NewLine+"最大連続コンボ"+maxCombo+System.Environment.NewLine+"得点"+sumCombo+System.Environment.NewLine+"正確性"+System.Math.Floor(accuracy*100)+"%";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            SceneManager.LoadScene("selection");
        }
    }
}
