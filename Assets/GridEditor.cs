using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GridEditor : MonoBehaviour
{
	[SerializeField]
	private GridManager gridManager;
	
	[SerializeField]
	private GameObject[] tiles;
	private int tilePointer = 0;
	
	[SerializeField]
	private Text tileTypeText;
	
	private void replace(int x, int y, GameObject rep)
	{
		GameObject[,] grid = gridManager.GetGrid();
		
		if (grid != null && y >= 0 && y < grid.GetLength(0) && x >= 0 && x < grid.GetLength(1))
		{
			Vector3 position = grid[y, x].transform.position;
			Destroy(grid[y, x]);
			grid[y, x] = Instantiate(rep) as GameObject;
			grid[y, x].transform.position = position;
			grid[y, x].transform.SetParent(gridManager.GetLevelRoot().transform);
		}
		
		gridManager.SetGrid(grid);
	}
	
	private void updateText()
	{
		tileTypeText.text = tiles[tilePointer].name;
	}
	
	void OnEnable()
	{
		updateText();
	}
	
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hitInfo;
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, 1000.0f))
			{
				Vector3 position = hitInfo.collider.transform.position;
				replace((((int)position.x)/10), (((int)position.z)/10), tiles[tilePointer]);
			}
		}
	}
	
	public void AdjustTilePointer(int direction)
	{
		tilePointer += direction;
		
		if (tilePointer < 0)
		{
			tilePointer = tiles.Length - 1;
		}
		else if (tilePointer >= tiles.Length)
		{
			tilePointer = 0;
		}
		
		updateText();
	}
}