using UnityEngine;
using PathCreation.Examples;

public class Hero : MonoBehaviour {
    private int score;
    private GameObject lastTriggeredGo = null;
    // Start is called before the first frame update
    void Start()
    {
        score = 2;
    }

    void OnCollisionEnter(Collision col) {
        Transform rootT = col.gameObject.transform.root;
        GameObject go = rootT.gameObject;
        PathFollower follower = GetComponent<PathFollower>();

        if (go == lastTriggeredGo)
            return;
        lastTriggeredGo = go;

        switch (go.GetComponent<Collider>().tag) {
            case "Obstacle":
                if (score > 2)
                    score /= 2;
                else {
                    follower.enabled = false;
                }
                break;
            case "Coin":
                Coins coin = (Coins) go.GetComponent(typeof(Coins));
                if (score == coin.score) {
                    score += coin.score;
                    Destroy(go);
                    print(score);
                }
                else
                    coin.OnBounce();
                break;
            case "Finish":
                follower.enabled = false;
                break;
        }
    }
}
