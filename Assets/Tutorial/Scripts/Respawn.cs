using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    Vector3 _startPosition;
    Quaternion _startRotation;

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = this.transform.position;
        _startRotation = this.transform.rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            StartCoroutine(RespawnObject());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boundary"))
        {
            StartCoroutine(RespawnObject());
        }
    }

    IEnumerator RespawnObject()
    {
        yield return new WaitForSeconds(2);
        this.transform.position = _startPosition;
        this.transform.rotation = _startRotation;
    }
}
