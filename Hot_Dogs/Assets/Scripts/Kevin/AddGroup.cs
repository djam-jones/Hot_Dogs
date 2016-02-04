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
			if(gameObject.GetComponent<DogMovement>() as DogMovement == null)
            {
				if(other.gameObject.GetComponent<DogMovement>().dogNr == 1)
					hotDogNr = PlayerNumber.PlayerOne;
				else if(other.gameObject.GetComponent<DogMovement>().dogNr == 2)
					hotDogNr = PlayerNumber.PlayerTwo;

				//hotDogNr = other.gameObject.GetComponent<DogMovement>().playerNr;
				gameObject.AddComponent<DogMovement>();
            }

            falling = false;
			tag = Tags.PLAYERTAG;

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
