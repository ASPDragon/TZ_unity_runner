using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private float limitValue;
    private float deltaX;
    public Rigidbody ball;
    public float sideForce;

    // Update is called once per frame
    void FixedUpdate() {
        if (Input.GetMouseButton(0)) {
            var cursor = Input.mousePosition;
            Vector3 worldCursor = Camera.main.ScreenToWorldPoint(new Vector3(cursor.x, cursor.y, 
                                                               Vector3.Distance(Camera.main.transform.position,
                                                               ball.gameObject.transform.position)));
            float targetX = (ball.gameObject.transform.worldToLocalMatrix * worldCursor).x;
            Vector3 resultPos = ball.gameObject.transform.localToWorldMatrix *
                                                  new Vector3(Math.Sign(targetX) * sideForce * Time.deltaTime, 0, 0);
            Debug.DrawLine(ball.gameObject.transform.position, resultPos, Color.red);
            ball.gameObject.transform.position += resultPos;
        }
    }
}
