using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePrefab : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.AddComponent<Rigidbody>();
        cube.transform.position = new Vector3(0,1,0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
