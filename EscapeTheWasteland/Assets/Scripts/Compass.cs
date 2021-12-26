using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    [SerializeField] Transform _playerTransform;
    [SerializeField] Transform _escapeVehicleTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateCompass();
    }

    private Vector3 CalculateDelta()
    {
        return (_escapeVehicleTransform.position - _playerTransform.position).normalized;
    }

    private void RotateCompass()
    {
        Vector3 direction = CalculateDelta();

        float angle = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, angle)), 0.2f);
    }
}
