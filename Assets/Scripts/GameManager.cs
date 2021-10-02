using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Creates characters array
    [SerializeField]
    private GameObject[] chars;

    private int _charIndex;
    public int CharIndex{
        get { return _charIndex; }
        set { _charIndex = value; }
    }

    private void Awake()
    {   
        // Singleton pattern: only one object by item
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Gameplay") {
            Instantiate(chars[CharIndex]);
        }
    }
}
