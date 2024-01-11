using UnityEngine;
using PathCreation.Examples;

public class Collisions : MonoBehaviour {
    public int score;
    public Material[] materials;
    Renderer rend;
    private GameObject lastTriggeredGo = null;
    PlayerMovement movement;
    // Start is called before the first frame update
    void Start() {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = materials[score];
        movement = GetComponent<PlayerMovement>();
    }

    void OnCollisionEnter(Collision col) {
        Transform rootT = col.gameObject.transform.root;
        GameObject go = rootT.gameObject;

        if (go == lastTriggeredGo)
            return;
        lastTriggeredGo = go;

        switch (go.GetComponent<Collider>().tag) {
            case "Coin":
                Coins coin = (Coins) go.GetComponent(typeof(Coins));
                if (score == coin.score) {
                    Destroy(go);
                    rend.sharedMaterial = materials[++score];
                }
                break;
            case "Finish":
                movement.enabled = false;
                break;
        }
    }

    void OnTriggerEnter(Collider col) {
        PlayerMovement movement = GetComponent<PlayerMovement>();
        if (col.tag == "Obstacle") {
            if (score > 0) {
                rend.sharedMaterial = materials[--score];
            }
            else {
                movement.enabled = false;
            }
        }
    }
}
