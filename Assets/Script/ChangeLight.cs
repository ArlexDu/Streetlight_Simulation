using UnityEngine;
using System.Collections;

public class ChangeLight : MonoBehaviour {

private Transform[] lights = new Transform[3];
	private int currentlight = 0;//当前展示的灯
	// Use this for initialization
	void Start () {
		Transform Light = GameObject.Find ("Lights").transform;
		for (int i=0; i<Light.childCount; i++) {
			lights[i] = Light.GetChild(i);
			if(i!=0){
				lights[i].gameObject.SetActive(false);
			}
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	   if (Input.GetKeyDown (KeyCode.Space)) {
			lights[currentlight].gameObject.SetActive(false);
			currentlight = (currentlight+1)>2?0:(currentlight+1);
		//	Debug.Log(lights[currentlight].FindChild("Light").localPosition.y);
			lights[currentlight].FindChild("Light").localPosition=new Vector3(0,0,0);
			Debug.Log(lights[currentlight].FindChild("Light").localPosition.y);
			lights[currentlight].gameObject.SetActive(true);
		}
	}
}
