using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnOnFloor : MonoBehaviour
{
    Transform _startTransform;

    // Start is called before the first frame update
    void Start()
    {
        _startTransform = this.transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(2);
        this.transform.position = _startTransform.position;
        this.transform.rotation = _startTransform.rotation;
    }
}
