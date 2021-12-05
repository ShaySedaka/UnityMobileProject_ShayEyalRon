using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualJoystick : MonoBehaviour
{
    [SerializeField]
    private GameObject _joyButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:

                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    transform.position = touchPosition;
                    //gameObject.SetActive(true);
                    break;

                case TouchPhase.Moved:

                    Vector3 touchPosition2 = Camera.main.ScreenToWorldPoint(touch.position);
                    Vector3 direction = touchPosition2 - transform.position;
                    direction.Normalize();

                    _joyButton.transform.position += direction;

                    break;
            }
           
        }
    }
}
