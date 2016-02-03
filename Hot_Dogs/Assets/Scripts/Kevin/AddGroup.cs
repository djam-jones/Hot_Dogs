using UnityEngine;
using System.Collections;

public class AddGroup : MonoBehaviour {
    [SerializeField]
    private float speed;
    private bool falling = true;
    private movement mof;
    // Use this for initialization
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Base")
        {
            gameObject.AddComponent<Rigidbody2D>();
            if(gameObject.GetComponent<movement>() as movement == null)
            {
                gameObject.AddComponent<movement>();
            }

            falling = false;
            tag = "Base";

        }
    }
    void Update()
    {
        if (falling == true)
        {
            transform.position -= new Vector3(0, speed, 0);
        }
    }
}
