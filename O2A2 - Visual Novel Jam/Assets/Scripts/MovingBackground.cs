using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed;

    public Vector2 offset;
    Material material;
    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }
    void Update()
    {
        offset = moveSpeed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }

}
