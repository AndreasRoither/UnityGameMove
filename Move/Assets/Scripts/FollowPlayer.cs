
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform player;
    public Vector3 offset;

	// Update is called once per frame
	void Update () {
        if (player != null && !float.IsNaN(player.position.x))
            transform.position = player.position + offset;
	}
}
