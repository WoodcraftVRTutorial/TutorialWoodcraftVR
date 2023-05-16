using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ItemCatchHandler : MonoBehaviour
{
    public Vector3 OriginalPos { get { return _originalPos; } set { _originalPos = value; } }
    public Quaternion OriginalRot { get { return _originalRot; } set { _originalRot = value; } }

    // Until the end added to Respawn object to position, if falls on the floor
    private Vector3 _originalPos;
    private Quaternion _originalRot;
    private Rigidbody _rigidBody;
    private bool _isKinematic;
    private const float _respawnTimeInSeconds = 1.5f;

    void Awake()
    {
        _originalPos = this.gameObject.transform.position;
        _originalRot = this.gameObject.transform.rotation;
        _rigidBody = gameObject.GetComponent<Rigidbody>();
        _isKinematic = _rigidBody.isKinematic;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ItemCatcher")
        {
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        GetComponent<Rigidbody>().velocity = Vector2.zero;
        _rigidBody.isKinematic = _isKinematic;
        yield return new WaitForSeconds(_respawnTimeInSeconds);
        this.gameObject.transform.position = _originalPos;
        this.gameObject.transform.rotation = _originalRot;
    }
}
