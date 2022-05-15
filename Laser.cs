using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float speed_ = 8f;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(Vector3.up  * speed_ * Time.deltaTime);

        if (transform.position.y >= 7.2)
            {
            Destroy(this.gameObject);

            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            
        }
    }

    


}
