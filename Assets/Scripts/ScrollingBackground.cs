using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {

    public float scrollSpeed = 0.1f;


    void Start()
    {

    }

    void Update()
    {
        float offset = Time.time * scrollSpeed;

        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offset, 0);
    }
}
