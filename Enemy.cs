using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 6f;

    private Player _player;

    [SerializeField]
    private GameObject _laserprefab;

    private float _canfire = 0f;

    [SerializeField]
    private float _firerate = 3.5f;

    private int Enemypoints = 100;

    private Animator _animator;
    
    private BoxCollider2D _boxCollider;

    private AudioManager _audioManager;

    [SerializeField]
    private AudioClip _laserAudio;

    [SerializeField]
    private AudioClip _explosionClip;

    private bool isDead = false;

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
        Fire();
    }

    void Movement()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y <= -7.46f)
        {
            transform.position = new Vector3(Random.Range(-9f,9f), 9.4f,transform.position.z);
        }
    }

    void Fire()
    {
        StartCoroutine(EnemyFire());
    }

    IEnumerator EnemyFire()
    {
        if (isDead == true)
        {
            yield break;
        }
        if (Time.time > _canfire)
        {
            _firerate = Random.Range(1.0f, 6.0f);
            _canfire = Time.time + _firerate;
            Instantiate(_laserprefab, transform.position + new Vector3(0, -2.0f, 0), Quaternion.identity);
        }
        
    
}

    private void OnTriggerEnter2D(Collider2D other)
    {
        _audioManager.explosion();
        if (other.tag == "Player")
        {
            isDead = true;
            other.transform.GetComponent<Player>().Damage();
            _animator.SetTrigger("OnEnemyDeath");
            Destroy(_boxCollider);
            _speed = 2;
            Destroy(this.gameObject, 2.8f);

        }

        
        if (other.tag == "Projectile")
        {
            isDead = true;
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
