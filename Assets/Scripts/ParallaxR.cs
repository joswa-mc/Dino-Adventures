using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxR : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float offset;
    private Vector2 startPosition;
    private float newXPos;
    void Start()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        newXPos = Mathf.Repeat(Time.time * -speed, offset);
        transform.position = startPosition + Vector2.right * newXPos;
    }
}
