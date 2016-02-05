using UnityEngine;
using System.Collections;

public class SalesmanController : MonoBehaviour
{
    private Animator anims;

    // Timer variables.
    private float currentTime;
    private float targetTime;
    // Use this for initialization
    void Start()
    {
        anims = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > targetTime)
        {
            anims.SetTrigger("Eat");
            targetTime = Random.Range(10, 30);
            currentTime = 0;
            anims.SetTrigger("Idle");
        }
    }
}
