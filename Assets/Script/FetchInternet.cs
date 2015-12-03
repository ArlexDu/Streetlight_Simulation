using UnityEngine;
using System.Collections;
using LitJson;
public class FetchInternet : MonoBehaviour {

	WWW http;
	string url;
	private float lastbright;
	// Use this for initialization
	void Start () {
		url = "http://10.60.42.49:8083/light/getOne?id=1";
		http = new WWW (url);
		StartCoroutine (WaitforRequest(http));
		InvokeRepeating("getInfo",2,0.1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	private void getInfo(){
		StartCoroutine (WaitforRequest(http));
	}
	/*
	 * json 格式：
	 * {
	 * "color" : "000050",
	 * "bright":  "1.5",
	 * "id"    :  2
 	 * }
	 * 
	 */

	IEnumerator WaitforRequest(WWW www){
		yield return www;
		if (www.error != null) {
			Debug.Log ("failed! "+ www.error);
		} else {
			if(www.isDone){
		//		Debug.Log ("succeed!");
				JsonData data = JsonMapper.ToObject(www.text);
				string bright = (string)data["bright"];
		//		Debug.Log("bright is "+ bright);
				//改变灯光的强度
				if(lastbright!=float.Parse(bright)){
					GameObject.Find("Lighting").GetComponent<ControlLighting>().changeIntensity(float.Parse(bright));
					lastbright = float.Parse(bright);
				}
			}
		}
	}
}
