using UnityEngine;
using System.Collections;

public class BronFireWork : MonoBehaviour {
	//烟花类型
	public GameObject[] FireWorks = new GameObject[3];
	//生成烟花的间隔时间
	private int time;
	//最终选择的烟花
	private GameObject choosefire;
	//所有的烟花可能生成的位置
	private Transform[] positions = new Transform[10];
	//最终选择的位置
	private Transform chooseposition;
	//用于计数，记录每次生成烟花的时间
	private float startTime;
	// Use this for initialization
	void Start () {
		//获得所有的位置点
		Transform allPosition = GameObject.Find ("Position").transform;
		for (int i =0; i<allPosition.childCount; i++) {
			positions[i] = allPosition.GetChild(i);
		}
		CreateFireWorks ();
		startTime = Time.time;
		time = Random.Range (1,6);
	}
	
	// Update is called once per frame
	void Update () {
		if ((Time.time - startTime) > time) {
			CreateFireWorks();
			startTime = Time.time;
			time = Random.Range (0,5);
		}
	}
	//选择烟花的类型
	private void ChooseFireWorks(){
		int n = Random.Range (0,3);
		choosefire = FireWorks [n];
	}
	//选择烟花的位置
	private void ChoosePosition(){
		int n = Random.Range (0,10);
		chooseposition = positions [n];
	}
	//生成烟花
	private void CreateFireWorks(){
		ChooseFireWorks ();
		ChoosePosition ();
		Instantiate (choosefire,chooseposition.position,new Quaternion(0,0,0,0));
	}
}
