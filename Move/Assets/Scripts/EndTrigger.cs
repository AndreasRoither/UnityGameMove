using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour {

    public GameManager gameManager;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<Collider>().tag == "Player")
            gameManager.CompleteLevel();
    }
}
