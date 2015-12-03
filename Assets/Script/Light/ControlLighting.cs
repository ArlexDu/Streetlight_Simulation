using UnityEngine;
using System.Collections;

public class ControlLighting : MonoBehaviour {

	private GameObject[] Lighting=new GameObject[6];//正对着的light,右边的light,左边的light,后面的light
	private float Light_intensity ; // 存储当前的光强
	private float old_intensity; // 存储上一次变化的光强
	private Color start_Color;
	private Color end_Color;
	private int max_lights;
	private float max_lighting = 3;//最大的光照强度
	private ArrayList Colors = new ArrayList(){new Color(0.8f,0.8f,0.8f,0.8f),new Color(1f,0,0,1f),new Color(0,1f,0,1f),new Color(0,0,1f,1f)};
	private int current_color = 0;
	// Use this for initialization
	void Start () {
		Debug.Log ("parent name is :"+transform.parent.parent.name);
		if (transform.parent.parent.name == "ShowLight4") {
			max_lights = 6;
		} else {
			max_lights = 4;
		}
		for (int i = 0; i < max_lights; i++) {
			Lighting[i] = transform.GetChild(i).gameObject;
		}
		start_Color = Color.white;
		end_Color = Color.red;
		Light_intensity = Lighting [0].GetComponent<Light> ().intensity;
		old_intensity = 1f;
	}
	
	// Update is called once per frame
	void Update () {
	    //点击上箭头光强增加
		//测试专用
	   /*if (Input.GetKey (KeyCode.UpArrow)) {
			ChangeLightIntensity (0.05f);
		} else if (Input.GetKey (KeyCode.DownArrow)) {//点击下箭头光强减少
			ChangeLightIntensity (-0.05f);
		}*/

		if (old_intensity < Light_intensity) {
			Debug.Log ("change up");
			ChangeLightIntensity (0.05f);
		} else if(old_intensity > Light_intensity){
			ChangeLightIntensity (-0.05f);
			Debug.Log ("change down");
		}
	}


	//改变光照的强度
	private void ChangeLightIntensity(float inten){
		old_intensity += inten;
		if (old_intensity > max_lighting) {
			old_intensity = max_lighting;
		} else if (Light_intensity < 0) {
			Light_intensity = 0;
		}
		for (int i=0; i<max_lights; i++) {
			Lighting[i].GetComponent<Light>().intensity = old_intensity;
		}
		if ((old_intensity >= Light_intensity) && (inten>0)) {
			old_intensity = Light_intensity;
		}else if((old_intensity <= Light_intensity) && (inten<0)){
			old_intensity = Light_intensity;
		}
	}

	public void changeIntensity(float i){
		Light_intensity = i;
	}

	
}
