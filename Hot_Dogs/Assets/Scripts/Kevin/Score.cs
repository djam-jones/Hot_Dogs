using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

    private BoxCollider2D _box;
    private int _GameTimer;
    private GameObject[] hotdogs;
    private int score;
	// Use this for initialization
	void Start () {
        _box = gameObject.GetComponent<BoxCollider2D>();    
    }
	
	// Update is called once per frame
	void Update () {
        if (_GameTimer == 0)
        {
           _box.enabled = true;
        }

        Debug.Log(score);

        hotdogs = GameObject.FindGameObjectsWithTag(Tags.HOTDOG);

        for (int i = 0; i < hotdogs.Length; i++)
        {
            foreach (GameObject hotdog in hotdogs)
            {
                Physics2D.IgnoreCollision(_box, hotdogs[i].GetComponent<PolygonCollider2D>());
            }           
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == Tags.PLAYERTAG)
        {
            score += 1;
        }
    }

    void OnCollitionExit2D(Collision2D other)
    {
        if (other.transform.tag == Tags.PLAYERTAG)
        {
            score -= 1;
        }
    }
}
