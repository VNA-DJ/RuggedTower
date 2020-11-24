using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksMove : MonoBehaviour {
    public static float speed;
    

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        if (transform.name == "Ground" && Application.loadedLevelName != "Menu" )
        {
            StartCoroutine("StopMove");
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameController.instance.Score();
        }
    }

    IEnumerator StopMove()
    {
        transform.Translate(Vector3.down * Time.deltaTime * .5f);
        yield return new WaitForSeconds(5);
        Destroy(GameObject.Find("Ground"));
    }
}
