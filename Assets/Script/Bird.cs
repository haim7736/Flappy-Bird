using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    public AudioSource jumpSoundSource; 
    public Rigidbody2D rigidBody;

    public GameSetting gameSetting;

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            rigidBody.velocity = Vector3.zero;
            rigidBody.AddForce(new Vector2(0, gameSetting.jumpPower),ForceMode2D.Impulse);
            jumpSoundSource.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Spike"))
        {
            GameController.Instance.OnGameOver();
        }
    }
}
