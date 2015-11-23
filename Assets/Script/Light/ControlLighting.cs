using UnityEngine;
using System.Collections;

public class ControlLighting : MonoBehaviour {

	public GameObject[] Lighting=new GameObject[4];//正对着的light,右边的light,左边的light,后面的light
	private float Light_intensity; // 存储当前的光强
	private Color start_Color;
	private Color end_Color;
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
			ChangeLightIntensity (0.01f);
		} else if (Input.GetKey (KeyCode.DownArrow)) {//点击下箭头光强减少
			ChangeLightIntensity (-0.01f);
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {//更换颜色
			ChangeColor();
		}
	}


	//改变光照的强度
	private void ChangeLightIntensity(float inten){
		Light_intensity += inten;
		if (Light_intensity > 1) {
			Light_intensity = 1;
		} else if (Light_intensity < 0) {
			Light_intensity = 0;
		}
		for (int i=0; i<4; i++) {
			Lighting[i].GetComponent<Light>().intensity = Light_intensity;
		}

	}

	//改变光的颜色
	private void ChangeColor(){
		for (int i=0; i<4; i++) {
			Lighting[i].GetComponent<Light>().color = Color.Lerp(start_Color,end_Color,1);
		}
	}
}
