using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Score : MonoBehaviour
{

    //public GameObject coin;
    public TextMeshPro scoreText;

    

    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
	{
        if(other.gameObject.CompareTag("Coin"))
		{
            other.gameObject.SetActive(false);
            score++;
            scoreText.SetText("Score: " + score);
            Debug.Log(score);
        }

        if(other.gameObject.CompareTag("Ground"))
		{
            scoreText.SetText("You lost");
            StartCoroutine(waiter());
		}
    }

    IEnumerator waiter()
    {
        //Wait for 4 seconds
        yield return new WaitForSeconds(4);

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
