﻿using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using MidiJack;

public class MicSpectrumAnalyz : MonoBehaviour
{
    public AudioSource Audiosource;
    // Start is called before the first frame update
    public Text text;

    public int len_spectrum;
    public float[] WaveformData;
    public float[] FreqComponents;
    public float[] keys;

    string[] noteNames = { "ド", "ド♯", "レ", "レ♯", "ミ", "ファ", "ファ♯", "ソ", "ソ♯", "ラ", "ラ♯", "シ" };
    // Update is called once per frame
    public bool[] key_judg;

    public int lengthSec=10;
    void Start()
    {
        Debug.Log(AudioSettings.outputSampleRate);
        Audiosource.loop = true;
        Audiosource.clip = Microphone.Start(null, true, lengthSec, 44100);
        while (!(Microphone.GetPosition(null) > 0)) { }
        Audiosource.Play();
    }

    // float A=0,B=0,C=0;
    bool[] key_Status=new bool[88];
    public bool MIDIStatus=true;
    void AudStop(){
        MIDIStatus=false;
        Audiosource.Stop();
    }

    void Update()
    {
        key_judg = new bool[88];
        for(int i=0;i<88;i++){
            if(MidiMaster.GetKeyDown(i+21)){
                key_Status[i]=true;
                if(MIDIStatus) AudStop();
            }
            if(MidiMaster.GetKeyUp(i+21)){
                key_Status[i]=false;
            }
            key_judg[i]=key_Status[i];
        }
        if(MIDIStatus){
            WaveformData = new float[len_spectrum];
            FreqComponents = new float[len_spectrum];
            float[] keyHzList = {
27.500f,
29.135f,
30.868f,
32.703f,
34.648f,
36.708f,
38.891f,
41.203f,
43.654f,
46.249f,
48.999f,
51.913f,
55.000f,
58.270f,
61.735f,
65.406f,
69.296f,
73.416f,
77.782f,
82.407f,
87.307f,
92.499f,
97.999f,
103.826f,
110.000f,
116.541f,
123.471f,
130.813f,
138.591f,
146.832f,
155.563f,
164.814f,
174.614f,
184.997f,
195.998f,
207.652f,
220.000f,
233.082f,
246.942f,
261.626f,
277.183f,
293.665f,
311.127f,
329.628f,
349.228f,
369.994f,
391.995f,
415.305f,
440.000f,
466.164f,
493.883f,
523.251f,
554.365f,
587.330f,
622.254f,
659.255f,
698.456f,
739.989f,
783.991f,
830.609f,
880.000f,
932.328f,
987.767f,
1046.502f,
1108.731f,
1174.659f,
1244.508f,
1318.510f,
1396.913f,
1479.978f,
1567.982f,
1661.219f,
1760.000f,
1864.655f,
1975.533f,
2093.005f,
2217.461f,
2349.318f,
2489.016f,
2637.020f,
2793.826f,
2959.955f,
3135.963f,
3322.438f,
3520.000f,
3729.310f,
3951.066f,
4186.009f,
        };
            Audiosource.GetOutputData(WaveformData, 0);
            Audiosource.GetSpectrumData(FreqComponents,0,FFTWindow.BlackmanHarris);
            keys = new float[88];
            for(int k = 0; k < 88; ++k) {
                
                FreqComponents[k]*=10000000;
                float hz = keyHzList[k];
                int m = (int)(AudioSettings.outputSampleRate / hz);
                int N = WaveformData.Length - m;
                float diff = 0f;
                for (int n = 0; n < N; ++n) {
                    diff += Mathf.Abs(WaveformData[n] - WaveformData[n + m]);
                }
                diff *= 1.0f / N;
                keys[k] = diff;
            }
            // string s="";
            for(int i=0;i<1;i++){
                int Ind=System.Array.IndexOf(keys,keys.Min());
                // Debug.Log(keys[Ind]+" "+keys[Ind+1]);
                if(keys[Ind]>0.001f){
                    key_judg[Ind]=true;
                    keys[Ind]=100;
                }
                
            }
        }
        // //鍵盤で全探索
        // for (int i = 0; i < 88; i++)
        // {
        //     if (BinarySearch(plaing_spectrum, key_freq[i]))
        //     {
        //         key_judg[i] = true;
        //     }
        //     else
        //     {
        //         key_judg[i] = false;
        //     }
        // }

        // フルコンボテスト用
        // for (int i = 0; i < 88; i++)
        // {
        //     key_judg[i]=true;
        // }
    }

    // public double tr_freq(int index)
    // {
    //     return (index * 48000 * 0.5 / currentValues.Length);
    // }
    
    // public bool BinarySearch(List<double> array, int target) //二分探索
    // {
    //     var left = 0;
    //     var right = array.Count - 1;
    //     while (left <= right)
    //     {
    //         var mid = left + (right - left) / 2;
    //         double mid_spe = array[mid];
    //         if (mid_spe + 5.0 >= target && mid_spe - 5.0 <= target) //誤差を考慮して±5の範囲で判定
    //         {
    //             return true;
    //         }
    //         else if (mid_spe < target)
    //         {
    //             left = mid + 1;
    //         }
    //         else
    //         {
    //             right = mid - 1;
    //         }
    //     }
    //     return false;
    // }
}
