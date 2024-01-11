using System;
using UnityEngine;
using PathCreation.Examples;
using PathCreation;

public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    private float limitValue;
    private float deltaX;
    public Rigidbody ball;
    public float sideForce;
    public PathCreator pathCreator;
    public EndOfPathInstruction endOfPathInstruction;
    public float speed = 5;
    float distanceTravelled;

    void Start() {
        // if (pathCreator != null) {
        //         // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
        //         pathCreator.pathUpdated += OnPathChanged;
        // }
        ball.freezeRotation = true;
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (pathCreator != null) {
            distanceTravelled += speed * Time.fixedDeltaTime;
            Vector3 point = pathCreator.path.GetPointAtDistance(distanceTravelled + speed * Time.fixedDeltaTime);
            Vector3 averageVelocity = (point - ball.gameObject.transform.position) / Time.fixedDeltaTime;
            ball.velocity = averageVelocity;

            if (Input.GetMouseButton(0)) {
                Vector3 sideDir = Vector3.Normalize(Vector3.Cross(averageVelocity.normalized, Vector3.up));
                print(sideDir);
                // Debug.DrawLine(ball.transform.position, ball.transform.position + sideDir, Color.magenta, 10, false);
                Vector3 cursor = Input.mousePosition;
                // Vector3 worldCursor = Camera.main.ScreenToWorldPoint(new Vector3(cursor.x, cursor.y, 
                //                                                 Vector3.Distance(Camera.main.transform.position,
                //                                                 ball.gameObject.transform.position)));
                // float targetX = (ball.gameObject.transform.worldToLocalMatrix * worldCursor).x;
                // Vector3 resultPos = ball.gameObject.transform.localToWorldMatrix *
                //                                     new Vector3(Math.Sign(targetX) * sideForce * Time.fixedDeltaTime, 0, 0);
                // ball.velocity += resultPos;
                // print(transform.rotation);

                Vector3 projectedBall = Camera.main.WorldToScreenPoint(ball.transform.position);
                print("Sign " + Math.Sign(cursor.x - projectedBall.x));
                ball.velocity += sideDir * Math.Sign(cursor.x - projectedBall.x) * Time.deltaTime * sideForce;

                // var projectedCameraPos = Vector3.ProjectOnPlane(sideDir, ball.gameObject.transform.position);
                
            }
        }
    }

    // void OnPathChanged() {
    //     distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
    // }
}
