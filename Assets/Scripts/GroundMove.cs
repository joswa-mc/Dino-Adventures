using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    private MeshRenderer meshRendeerer;
    private void Awake()
    {
        meshRendeerer = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        float speed = GameManage.Instance.GameSpeed / transform.localScale.x;
        meshRendeerer.material.mainTextureOffset += speed * Time.deltaTime * Vector2.right;
    }
}
