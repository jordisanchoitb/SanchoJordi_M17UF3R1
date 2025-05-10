using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBullet : MonoBehaviour
{
    public float speed = 25f;
    public float lifetime = 10f;

    public void Launch(Vector3 direction)
    {
        GetComponent<Rigidbody>().velocity = direction.normalized * speed;

        transform.rotation = Quaternion.LookRotation(direction);

        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("colisionado con:" + collision.gameObject.name);
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.Hurt(10f);
        }
        Destroy(gameObject);
    }
}
