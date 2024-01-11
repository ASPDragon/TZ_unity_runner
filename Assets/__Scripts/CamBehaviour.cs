using UnityEngine;

public class CamBehaviour : MonoBehaviour {
    public Transform player;
    public Vector3 offset;
    // float smoothRotation = 0.5f;
    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;
    }
}
