using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualJoystick : MonoBehaviour
{
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

                    Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    transform.position = touchPosition;
                    gameObject.SetActive(true);
                    break;

                case TouchPhase.Moved:


                    break;
            }
           
        }
    }
}
