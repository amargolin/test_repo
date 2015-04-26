using UnityEngine;
using System.Collections.Generic;


public class PlayerScript : MonoBehaviour {
	public float playerspeed = 2.0f;
	private float currentSpeed = 0.0f;

	public List<KeyCode> upButton;
	public List<KeyCode> downButton;
	public List<KeyCode> leftButton;
	public List<KeyCode> rightButton;

	private Vector3 lastMovement = new Vector3();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
