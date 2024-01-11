using UnityEngine;

public class Coins : MonoBehaviour
{
    public int score;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.isKinematic = true;
    }

    public void OnBounce() {
        rb.isKinematic = false;
    }
}
