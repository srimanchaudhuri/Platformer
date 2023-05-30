using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    bool gameEnd = false;
    [SerializeField] private float restartDelay = 1f;
//    [SerializeField] private GameObject CompleteLevelUI;

    public void EndGame () { 
        gameEnd = true;
        Invoke("Restart", restartDelay);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
