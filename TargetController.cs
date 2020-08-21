using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public const int AMP = 2;
    int rand;
    float x, y, z;
    // Start is called before the first frame update
    void Start()
    {
        x = this.transform.position.x;
        y = this.transform.position.y;
        z = this.transform.position.z;
        rand = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        //どんな動きをしたらいいかわからないのでとりあえず単振動
        float sin = Mathf.Sin(Time.time * rand);
        this.transform.position = new Vector3(x, y + AMP * sin, z);
    }
}
