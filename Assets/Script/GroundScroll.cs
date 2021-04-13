using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroll : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public float speed;
    void Update()
    {
        spriteRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
