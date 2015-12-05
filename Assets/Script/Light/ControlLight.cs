using UnityEngine;
using System.Collections;

public class ControlLight : MonoBehaviour {
	private float last;
	private bool move = false;
	private int keep = 1;
	private int stop = 0;
    private bool turn = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	
	void FixedUpdate(){
		if (turn) {
			//添加力矩旋转
			transform.GetComponent<Rigidbody> ().AddTorque (new Vector3 (0, 180, 0));
            turn = false;
		}
		if (Input.GetKeyDown (KeyCode.V)) {
			if(move){
				Debug.Log("wind stop");
				move = false;
			}else{
				move = true;
				last = Time.time;
				Debug.Log("wind begin");
			}
		}
		
		if (move) {
			
			if((Time.time-last)>stop){
	//			Debug.Log("stop is okay");
				if(Mathf.Abs (Time.time -last-stop)<keep){
					Debug.Log("move");
					int strength = Random.Range(0,3)*10;
					//已经用fixed的joint链接，给一个水平力
					transform.GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 0, -1) * strength);
				}else{
					last  = Time.time;
					//mo模拟风力的持续时间
					keep = Random.Range(2,6);
					//模拟没有风的时间
					stop = Random.Range(3,10);
				}
			}
			
		}
	}
    
    public void changturn()
    {
        turn = true;
    }	
}
