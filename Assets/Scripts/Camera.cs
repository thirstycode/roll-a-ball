using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	public Transform Player;
	public float turnSpeed = 3.0f;
	private Vector3 offset;


	// Use this for initialization
	void Start () {
		offset = transform.position - Player.transform.position;
	}
	
	// After Update
	void LateUpdate () {
		transform.position = Player.transform.position + offset;
	}

	void Update (){
		offset = Quaternion.AngleAxis (Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
		transform.position = Player.position + offset; 
		transform.LookAt(Player.position);
	}
}