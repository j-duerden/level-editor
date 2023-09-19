using UnityEngine;
using System.Collections;
using System;

namespace UnityStandardAssets.Characters.FirstPerson
{

	public class CameraMovement : MonoBehaviour 
	{
		private float speed = 10.0f;

		// Use this for initialization
		void Start () 
		{

		}
		
		// Update is called once per frame
		void Update () 
		{
			transform.Translate (Vector3.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime);
			transform.Translate (Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
		}
	}
}
