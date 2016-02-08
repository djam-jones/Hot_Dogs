using UnityEngine;
using System.Collections;

public class AddGroup : MonoBehaviour {
    [SerializeField]
    private float speed;
    private bool falling = true;
    private int randomhotdog;
    private SpriteRenderer sprite;
    [SerializeField]
    private Sprite dog1;
    [SerializeField]
    private Sprite dog2;
    [SerializeField]
    private Sprite dog3;
    [SerializeField]
    private Sprite dog4;
    [SerializeField]
    private float alphacolor;
    private bool Fade;
    private float lerp;


    void Start()
    {
        alphacolor = gameObject.GetComponent<SpriteRenderer>().color.a;
        speed = 0.1f;
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
            if (gameObject.GetComponent<Rigidbody2D>() != null)
            {
                gameObject.AddComponent<Rigidbody2D>();
                gameObject.GetComponent<Rigidbody2D>().mass = 0.3f;
            }

            falling = false;
			tag = Tags.PLAYERTAG;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == Tags.BORDERTAG)
        {
            StartCoroutine(Bounce());
        }
    }

    void Update()
    {
        if (falling == true)
        {
            transform.position -= new Vector3(0, speed, 0);
            speed += 0.001f;
        }
        if (Fade == true)
        {
            alphacolor -= 1f * Time.deltaTime;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphacolor);
        }

    }

    IEnumerator Bounce()
    {       
        speed = (-speed + speed/2);
        yield return new WaitForSeconds(0.3f);
        speed = (speed/4);
        yield return new WaitForSeconds(1f);
        speed = 0.1f;
        Fade = true;
        
        if (alphacolor < 0.01)
        {
            Destroy(gameObject);
        }
    }
}
