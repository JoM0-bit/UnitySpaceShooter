using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private int points = 250;

    private Player _player;

    [SerializeField]
    private float _speed = 1.0f;

    [SerializeField]
    private float _roatationspeed = 25.0f;

    private Animator _animator;

    private CircleCollider2D _circleCollider;

    private SpawnManager _spawnManager;

    public bool MovingLeft = false;
    public bool MovingRight = false;
    public bool MovingUp = false;

    AudioManager _audioManager;



    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();

        if (_player == null)
        {
            Debug.Log("The Player is NULL");
        }

        _animator = gameObject.GetComponent<Animator>();

        if( _animator == null)
        {
            Debug.Log("Animator is Null");
        }

        _circleCollider = gameObject.GetComponent<CircleCollider2D>();

        if(_circleCollider == null)
        {
            Debug.Log("Circle Collider Null");
        }

        _audioManager = GameObject.Find("Audio_Manager").GetComponent<AudioManager>();

        if(_audioManager == null)
        {
            Debug.LogError("AudioManager Null");
        }
        
    }

    
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.Rotate(Vector3.forward* _roatationspeed* Time.deltaTime);
        if (MovingLeft == true)
        {
            transform.Translate(new Vector3(1, Random.Range(-1,1), 0) * _speed * Time.deltaTime, Space.World);
        }
        else if (MovingRight == true){
            transform.Translate(new Vector3(-1, Random.Range(-1, 1), 0) * _speed * Time.deltaTime, Space.World);
        }
        else if (MovingUp == true)
        {
            transform.Translate(new Vector3(Random.Range(-1, 1), 1, 0) * _speed * Time.deltaTime, Space.World);
        }

        if( transform.position.y > 7.6 || transform.position.y < -6.2f)
        {
            Destroy(gameObject);
        }

        if (transform.position.x > 11 || transform.position.x < -11)
        {
            Destroy(gameObject);
        }
        
    }

    public void updateMovment(int direction)
    {
        if (direction == 0)
        {
            MovingUp = true;
        }
        
        else if (direction == 1)
        {
            MovingRight = true;
        }
        else if(direction == 2)
        {
            MovingLeft = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _audioManager.explosion();
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().Damage();
            _animator.SetTrigger("IsDestroyed");
            Destroy(_circleCollider);
            Destroy(this.gameObject,2.8f);
        }

        if (collision.tag == "Enemy")
        {
            _animator.SetTrigger("IsDestroyed");
            Destroy(_circleCollider);
            Destroy(this.gameObject,2.8f);
        }

        if (collision.tag == "Projectile")
        {
            _animator.SetTrigger("IsDestroyed");
            Destroy(collision.gameObject);
            Destroy(_circleCollider);
            _player.addScore(points);
            Destroy(this.gameObject,2.8f);
        }
    }
}
