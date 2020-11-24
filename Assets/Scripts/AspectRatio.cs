using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectRatio : MonoBehaviour {
    public GameObject backgroundObject;
	// Use this for initialization
	void Start () {
        if (Camera.main.aspect > 0.6f)
        {
            backgroundObject.transform.localScale = new Vector3(1.11f, 1.11f, 1.11f);
            Debug.Log("10:16");
        }
        else
        {
            backgroundObject.transform.localScale = new Vector3(1, 1, 1);
            Debug.Log("9:16");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
