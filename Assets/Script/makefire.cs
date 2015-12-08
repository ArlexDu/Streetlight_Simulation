using UnityEngine;
using System.Collections;

public class makefire : MonoBehaviour {
    public GameObject fire;
    private GameObject firebone;
	// Use this for initialization
	void Start () {
        firebone=(GameObject)Instantiate(fire, transform.position, transform.rotation);
    }
	
	// Update is called once per frame
	void Update () {
        firebone.transform.position = transform.position;
        firebone.transform.rotation = transform.rotation;
	}
}
