using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnOnFloor : MonoBehaviour
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
        Debug.Log($"Collision with {collision.gameObject.name}");
        if (collision.gameObject.CompareTag("Floor"))
        {
            StartCoroutine(Respawn());
            Debug.Log("Respawning in 2 seconds");
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("Respawning now!");
        this.transform.position = _startPosition;
        this.transform.rotation = _startRotation;
    }
}
