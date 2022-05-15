using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    [SerializeField]
    private int _speed = 3;

    [SerializeField]
    private int PowerUpID;

    [SerializeField]
    private AudioClip _powerupClip;

    
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y <= -6)
        {
            Destroy(this.gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        AudioSource.PlayClipAtPoint(_powerupClip, transform.position);
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            
            switch(PowerUpID)
            {
                case 0:
                    player.TripleShotEnable();
                    break;

                case 1:
                    player.SpeedBoostEnable();
                    break;

                case 2:
                    player.SheildsEnable();
                    break;

                default:
                    Debug.Log("Default Value");
                        break;

            }
            
            Destroy(this.gameObject);
        }
    }
}
