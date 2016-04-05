using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

    Transform player;

    Vector3 velocity = Vector3.zero;

    [SerializeField]
    float offset = -9f;

    [SerializeField]
    float smooth = 0.3f;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
	    if(player != null)
        {
            Vector3 targetPosition = new Vector3(player.position.x, player.position.y, player.position.z + offset);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smooth);

        }
	}
}
