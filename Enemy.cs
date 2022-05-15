using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 6f;

    private Player _player;

    private int Enemypoints = 100;

    private Animator _animator;
    
    private BoxCollider2D _boxCollider;

    private AudioManager _audioManager;

    [SerializeField]
    private AudioClip _explosionClip;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        if(_player == null)
        {
            Debug.Log("The Player is NULL");
        }

        _boxCollider = gameObject.GetComponent<BoxCollider2D>();

        _animator = gameObject.GetComponent<Animator>();

        if (_animator == null)
        {
            Debug.Log("The Animator is NULL");
        }

        _audioManager = GameObject.Find("Audio_Manager").GetComponent<AudioManager>();

        if (_audioManager == null)
        {
            Debug.LogError("Audio Manager is Null");
        }

        
    }


    void Update()
    {
        Movement();
    }

    void Movement()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y <= -7.46f)
        {
            transform.position = new Vector3(Random.Range(-9f,9f), 9.4f,transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _audioManager.explosion();
        if (other.tag == "Player")
        {
            other.transform.GetComponent<Player>().Damage();
            _animator.SetTrigger("OnEnemyDeath");
            Destroy(_boxCollider);
            _speed = 2;
            Destroy(this.gameObject, 2.8f);

        }

        
        if (other.tag == "Projectile")
        {
            _animator.SetTrigger("OnEnemyDeath");
            Destroy(_boxCollider);
            Destroy(this.gameObject,2.8f);
            _speed = 1;

            if(_player != null)
            {
                _player.addScore(Enemypoints);
            }
                
                Destroy(other.gameObject);
            }
        
    }


}
