using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    public GameObject follow;
    public float parallaxFX;
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float temp = (follow.transform.position.x * (1 - parallaxFX));
        float dist = (follow.transform.position.x * parallaxFX);
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + length)
        {
            startpos += length; 
        }
        else if (temp < startpos - length)
        {
            startpos -= length;
        }

    }
}
