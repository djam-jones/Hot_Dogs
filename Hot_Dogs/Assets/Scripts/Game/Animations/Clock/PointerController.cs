using UnityEngine;
using System.Collections;

public class PointerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;

    private Vector3 turnSpeed;

    // Use this for initialization
    void Start()
    {
        turnSpeed = new Vector3(0, 0, 0.1f * speed);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(this.transform.rotation.z);

        if(this.transform.rotation.z >= 0)
        {
            this.transform.Rotate(turnSpeed);
        }
        else
        {

        }


    }
}
