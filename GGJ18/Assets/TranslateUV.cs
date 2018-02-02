using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateUV : MonoBehaviour {
    public Material material;
    public float xScrollSpeed;
    public float yScrollSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float offsetX = Time.time * xScrollSpeed;
        float offsetY = Time.time * yScrollSpeed;
        material.SetTextureOffset("_MainTex", new Vector2(offsetX, offsetY));
	}
}
