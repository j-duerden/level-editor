using UnityEngine;
using System.Collections;

public class TileHighlight : MonoBehaviour 
{

	public Color startColor = Color.red;
	public Color endColor;
	public Renderer rend;
	
	void Start () 
	{
		endColor = rend.material.GetColor ("_Color");
		rend = GetComponent<Renderer> ();
	}

	void OnMouseEnter()
	{
		rend.material.color = startColor;
	}

	void OnMouseExit()
	{
		rend.material.color = endColor;
	}
}
