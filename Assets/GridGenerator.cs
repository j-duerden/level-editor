using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GridGenerator : MonoBehaviour
{
	[SerializeField]
	private GridManager gridManager;
	
	[SerializeField]
	private GameObject baseTile;
	
	[SerializeField]
	private InputField widthField;
	
	[SerializeField]
	private InputField lengthField;
	
	[SerializeField]
	private int defaultWidth;
	[SerializeField]
	private int defaultLength;

	private float tileSize;
	
	private void generate(int width, int length)
	{
		GameObject[,] grid = gridManager.GetGrid();
        GameObject[,] objects = gridManager.GetObjectsGrid();
		GameObject levelRoot = gridManager.GetLevelRoot();
		
		if (grid != null)
		{
			for (int y = 0; y < grid.GetLength(0); y++)
			{
				for (int x = 0; x < grid.GetLength(1); x++)
				{
					Destroy(grid[y, x]);
				}
			}
		}
		
		grid = new GameObject[length, width];
        objects = new GameObject[length, width];
		
		for (int y = 0; y < length; y++)
		{
			for (int x = 0; x < width; x++)
			{
				grid[y, x] = Instantiate(baseTile) as GameObject;
                grid[y, x].transform.SetParent(levelRoot.transform);
                grid[y, x].transform.position = new Vector3(x * tileSize, 0, y * tileSize);
			}
		}

        gridManager.SetGrid(grid);
        gridManager.SetObjectsGrid(objects);
	}
	
	public void GenerateGrid()
	{
		int width = 0;
		int length = 0;
		if (System.Int32.TryParse(widthField.text, out width) && System.Int32.TryParse(lengthField.text, out length))
		{
			generate(width, length);
		}
	}
	
	void Start ()
	{
		tileSize = baseTile.GetComponent<Renderer>().bounds.size.x;
		generate(defaultWidth, defaultLength);
	}
}
