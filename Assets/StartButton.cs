using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartButton : MonoBehaviour
{

    public Button startButton;

    private int currentLevel;

    void Start()
    {
        currentLevel = Application.loadedLevel;
        Button playButton = startButton.GetComponent<Button>();
        playButton.onClick.AddListener(NextLevel);
    }

    public void NextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}
