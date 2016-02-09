using UnityEngine;
using System.Collections;

public class UIslide : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private float speed;

    private bool sliding = false;

    // Timer vars
    private float currentTime;
    [SerializeField]
    private float targetTime;
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(sliding == true)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, speed * Time.deltaTime);
        }   
    }

    public void startSlide()
    {
        sliding = true;
    }
}
