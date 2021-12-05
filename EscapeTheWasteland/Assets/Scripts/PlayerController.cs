using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _runSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MovePlayer(Vector2 direction)
    {
        Vector3 v3Direction = new Vector3(direction.x, direction.y);

        transform.position += v3Direction * _runSpeed * Time.deltaTime;

        //RotatePlayer(v3Direction); ????

    }

    public void RotatePlayer(Vector3 direction)
    {
        Vector3 targetDirection = direction - transform.position;

        float singleStep = _runSpeed * Time.deltaTime;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
