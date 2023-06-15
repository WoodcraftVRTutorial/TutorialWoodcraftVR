using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInTime : MonoBehaviour
{
    [SerializeField] private float _time = 2.0f;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(_time);
        Destroy(this.gameObject);
    }
}
