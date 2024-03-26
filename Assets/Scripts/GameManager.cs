using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Maze mazePrefab;

    private Maze _mazeInstance;
    
    void Start()
    {
        BeginGame();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) RestartGame();
    }

    private void BeginGame()
    {
        _mazeInstance = Instantiate(mazePrefab) as Maze;
        StartCoroutine(_mazeInstance.Generate());
    }
    
    private void RestartGame()
    {
        StopAllCoroutines();
        Destroy(_mazeInstance.gameObject);
        BeginGame();
    }
}
