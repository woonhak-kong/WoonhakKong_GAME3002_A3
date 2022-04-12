using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySceneUIController : MonoBehaviour
{

    public GameObject GameOverUI;
    public GameObject GameClearUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGameOver()
    {
        GameOverUI.SetActive(true);
    }

    public void SetGameClear()
    {
        GameClearUI.SetActive(true);
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void OnClickMenu()
    {
        SceneManager.LoadScene("MenuScene");

    }
}
