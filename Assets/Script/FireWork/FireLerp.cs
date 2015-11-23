using UnityEngine;
using System.Collections;

public class FireLerp : MonoBehaviour {
	public GameObject fire;
	public GameObject target;
	public float time;

	private float distance;
	private float moveSpeed;
	private float startTime;
	private float firction;
	private bool moved = false;
	// Use this for initialization
	void Start () {
		distance = Vector3.Distance (target.transform.position, fire.transform.position);
		moveSpeed = distance / time;
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if ((fire.transform.position.y >= (target.transform.position.y-10))&&!moved) {
			moved = true;
			Invoke("hidefireGameobject",1);
			Invoke("destoryGameobject",4);
		} 
		firction = (Time.time - startTime) * moveSpeed / distance;
		fire.transform.position = new Vector3 (fire.transform.position.x, Mathf.Lerp (0, distance, firction), fire.transform.position.z);
	}

	private void destoryGameobject(){
		Destroy(gameObject);
	}
	private void hidefireGameobject(){
		fire.GetComponent<MeshRenderer>().enabled = false;
	}
}
