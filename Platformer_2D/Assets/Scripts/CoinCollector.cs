using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinCollector : MonoBehaviour
{
    private int coinsCollected = 0;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText.text = "Score: " + coinsCollected;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "coin")
        {
            coinsCollected++;
            scoreText.text = "Score: " + coinsCollected;
            if (coinsCollected == 7)
            {
                scoreText.text = "CoNgRaTuLaTiOnS";
                Invoke("congrats", 2f);
            }
        }
    }

    public void congrats()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
