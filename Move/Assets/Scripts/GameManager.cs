using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private bool gameEnded = false;

    public float restartDelay = 1f;
    public GameObject completeLvlUI;
    public GameObject player;

    public void CompleteLevel()
    {
        completeLvlUI.SetActive(true);
        player.GetComponent<PlayerMovement>().SetShouldMove(false);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

	public void EndGame()
    {
        Debug.Log("ende");
        if (!gameEnded)
        {
            gameEnded = true;
            Invoke("Restart", restartDelay);
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
