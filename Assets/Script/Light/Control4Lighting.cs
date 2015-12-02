﻿using UnityEngine;
using System.Collections;

public class Control4Lighting : MonoBehaviour {

	public GameObject[] Lighting=new GameObject[6];//正对着的light,右边的light,左边的light,后面的light
	private float Light_intensity; // 存储当前的光强
	private Color start_Color;
	private Color end_Color;
	private float max_lighting = 3;//最大的光照强度
	//private ArrayList Colors = new ArrayList(){new Color(0.8f,0.8f,0.8f,0.8f),new Color(1f,0,0,1f),new Color(0,1f,0,1f),new Color(0,0,1f,1f)};
	private int current_color = 0;
	// Use this for initialization
	void Start () {
		Light_intensity = Lighting [0].GetComponent<Light> ().intensity;
		//Debug.Log ("color is :"+Lighting [0].GetComponent<Light> ().color);
		start_Color = Color.white;
		end_Color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
	  //点击上箭头光强增加
	  if (Input.GetKey (KeyCode.UpArrow)) {
			ChangeLightIntensity (0.05f);
		} else if (Input.GetKey (KeyCode.DownArrow)) {//点击下箭头光强减少
			ChangeLightIntensity (-0.05f);
		}
	}


	//改变光照的强度
	private void ChangeLightIntensity(float inten){
		Light_intensity += inten;
		if (Light_intensity > max_lighting) {
			Light_intensity = max_lighting;
		} else if (Light_intensity < 0) {
			Light_intensity = 0;
		}
		for (int i=0; i<6; i++) {
			Lighting[i].GetComponent<Light>().intensity = Light_intensity;
		}

	}
	
}