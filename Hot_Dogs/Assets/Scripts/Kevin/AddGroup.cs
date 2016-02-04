using UnityEngine;
using System.Collections;

public class AddGroup : MonoBehaviour {
	
    [SerializeField]
    private float speed;
    private bool falling = true;
    private int randomhotdog;
    [SerializeField]
    private Sprite dog1;
    [SerializeField]
    private Sprite dog2;
    [SerializeField]
    private Sprite dog3;
    [SerializeField]
    private Sprite dog4;

    void Start()
    {
        randomhotdog = Random.Range(1, 5);
        if (randomhotdog == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = dog1;
        }
        else if (randomhotdog == 2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = dog2;
        }
        else if (randomhotdog == 3)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = dog3;
        }
        else if (randomhotdog == 4)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = dog4;
        }
    }
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
