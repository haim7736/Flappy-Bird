using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public SpriteRenderer topSpike;
    public SpriteRenderer bottomSpike;

    private float _totalHeight = 19.2f;
    private float _scrollSpeed;
    private float _birdPosX;
    private bool _isAddedScore;


    public void Init(float holeSize, float scrollSpeed, float birdPosx)
    {
        var bottomHeight = Random.Range(4f, _totalHeight - holeSize - 4f);
        var topHeight = _totalHeight - bottomHeight - holeSize;

        SetSpikeSize(bottomSpike, bottomHeight);
        SetColliderSize(bottomSpike, bottomHeight);

        SetSpikeSize(topSpike, topHeight);
        SetColliderSize(topSpike, topHeight, true);

        _scrollSpeed = scrollSpeed;
        _birdPosX = birdPosx;
        _isAddedScore = false;
    }

    private void SetSpikeSize(SpriteRenderer spike, float height)
    {
        spike.size = new Vector2(spike.size.x, height);
    }

    private void SetColliderSize(SpriteRenderer spikeSpr, float height, bool isTop = false)
    {
        var collider = spikeSpr.GetComponent<BoxCollider2D>();
        collider.size = new Vector2(collider.size.x, height);
        collider.offset = new Vector2(0f, (isTop ? -1f : 1f) * (height / 2f));
    }
    void Update()
    {
        transform.Translate(new Vector3(-_scrollSpeed * Time.deltaTime, 0f));

        if(transform.position.x < -8f)
        {
            DestroyImmediate(gameObject);
            return;
        }

        if(transform.position.x < _birdPosX && _isAddedScore == false)
        {
            _isAddedScore = true;
            GameController.Instance.AddScore(1);
        }
    }

}
