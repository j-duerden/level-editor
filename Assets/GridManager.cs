using UnityEngine;

public class GridManager : MonoBehaviour
{
	[SerializeField]
	private GameObject gridGenerateCanvas;
	[SerializeField]
	private GameObject gridEditCanvas;
	[SerializeField]
	private GameObject spawnerCanvas;
	
	[SerializeField]
	public GameObject levelRoot;
	
	private GameObject[,] grid;

    private GameObject[,] objects;
	
	public GameObject[,] GetGrid()
	{
		return grid;
	}
	
	public void SetGrid(GameObject[,] grid)
	{
		this.grid = grid;
	}

    public GameObject[,] GetObjectsGrid()
    {
        return objects;
    }

    public void SetObjectsGrid(GameObject[,] objects)
    {
        this.objects = objects;
    }

    public GameObject GetLevelRoot()
	{
		return levelRoot;
	}
	
	void Start()
	{
		EnableCanvas(0);
	}
	
	public void EnableCanvas(int type)
	{
		gridGenerateCanvas.SetActive(false);
		gridEditCanvas.SetActive(false);
        spawnerCanvas.SetActive(false);

        switch (type)
		{
		case 0:
			gridGenerateCanvas.SetActive(true);
			break;
		case 1:
			gridEditCanvas.SetActive(true);
			break;
         case 2:
            spawnerCanvas.SetActive(true);
            break;
                    
        }
    }
}
