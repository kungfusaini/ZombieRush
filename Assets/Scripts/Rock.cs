using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Object
{
    [SerializeField] private Vector3 topPos;
    [SerializeField] private Vector3 bottomPos;
    [SerializeField] private float speed;
    [SerializeField] private float waitTime;
    [SerializeField] private float angle;


    void Start()
    {
        StartCoroutine(Move(bottomPos));
    }

    protected override void Update()
    {
        
        transform.Rotate(0, angle, 0,Space.Self);

        if (GameManager.instance.PlayerActive) {
            base.Update();
        }
    }

    IEnumerator Move(Vector3 target)
    {
        //while the distance between the target > 0.2..
        while (Mathf.Abs((target - transform.localPosition).y) > 0.20f)
        {
            //...if the target is up, go up, else go down
            Vector3 direction = target.y == topPos.y ? Vector3.up : Vector3.down;
            //transform.localPosition += direction * Time.deltaTime * speed;
            transform.Translate(speed * direction * Time.deltaTime, Space.World);
            yield return null;

        }
       
        yield return new WaitForSeconds(waitTime);

        //if the target was the top, new target is the bottom
        Vector3 newTarget = target.y == topPos.y ? bottomPos : topPos;

        StartCoroutine(Move(newTarget));
    }
}
