using UnityEngine;
using System.Collections;

public class AddGroup : MonoBehaviour {
	
    [SerializeField]
    private float speed;
    private bool falling = true;
	private PlayerNumber hotDogNr;


    void OnCollisionEnter2D(Collision2D other)
    {
		if (other.gameObject.tag == Tags.PLAYERTAG)
        {
            gameObject.AddComponent<Rigidbody2D>();
			gameObject.GetComponent<Rigidbody2D>().mass = 0.3f;

            falling = false;
			tag = Tags.PLAYERTAG;

        }
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == Tags.BORDERTAG)
		{
			Destroy(gameObject);
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
