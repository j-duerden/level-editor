using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectSpawner : MonoBehaviour {

    [SerializeField]
    private GridManager gridManager;

    [SerializeField]
    private GameObject[] prefabs;
    private int prefabPointer = 0;

    [SerializeField]
    private Text objectText;

    [SerializeField]
    private Slider rotateSlider;

    [SerializeField]
    private Text rotateText;

    private void add(int x, int y, GameObject obj)
    {
		GameObject[,] grid = gridManager.GetGrid();
        GameObject[,] objects = gridManager.GetObjectsGrid();

        if (objects != null && y >= 0 && y < grid.GetLength(0) && x >= 0 && x < grid.GetLength(1))
        {
            Vector3 position = grid[y, x].transform.position;
            Destroy(objects[y, x]);
            objects[y, x] = Instantiate(obj) as GameObject;
            objects[y, x].transform.position = new Vector3(position.x, (obj.GetComponent<Renderer>().bounds.size.y)/2, position.z);
            objects[y, x].transform.Rotate(0, rotateSlider.value, 0);
            objects[y, x].transform.SetParent(grid[y, x].transform);
        }

        gridManager.SetGrid(grid);
    }

    private void updateText()
    {
        objectText.text = prefabs[prefabPointer].name;
    }

    void OnEnable()
    {
        updateText();
    }

	void Start()
	{
		GameObject[,] grid = gridManager.GetGrid();
        GameObject[,] objects = gridManager.GetObjectsGrid();
	}

    void Update()
    {
        rotateText.text = "Object Rotation: " + rotateSlider.value.ToString();
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, 1000.0f))
            {	
                Vector3 position = hitInfo.collider.transform.position;
				add((((int)position.x) / 10), (((int)position.z) / 10), prefabs[prefabPointer]);
            }
        }
    }

    public void AdjustObjectPointer(int direction)
    {
        prefabPointer += direction;

        if (prefabPointer < 0)
        {
            prefabPointer = prefabs.Length - 1;
        }
        else if (prefabPointer >= prefabs.Length)
        {
            prefabPointer = 0;
        }

        updateText();
    }
}
