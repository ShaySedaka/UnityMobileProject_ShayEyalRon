using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualJoystick : MonoBehaviour
{
    public Vector2 Vector2Position { get => new Vector2(transform.position.x, transform.position.y); }

    [SerializeField] Camera _mainCamera;
    [SerializeField] private float _radius;
    [SerializeField] private PlayerController _player;
    [SerializeField] private GameObject _joystickBackground;
    [SerializeField] private GameObject _joyButton;

    // Start is called before the first frame update
    void Start()
    {
        _radius = _joystickBackground.transform.localScale.x / 2;
        ToggleVisibility(false);
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
                    ToggleVisibility(true);
                    Vector2 touchPosition = _mainCamera.ScreenToWorldPoint(touch.position);
                    transform.position = touchPosition;
                    
                    break;

                case TouchPhase.Ended:

                    _joyButton.transform.position = transform.position;
                    ToggleVisibility(false);

                    break;

                default:
                    Vector2 touchPosition2 = _mainCamera.ScreenToWorldPoint(touch.position);
                    Vector2 delta = touchPosition2 - Vector2Position;

                    if (delta.magnitude <= _radius)
                    {
                        _joyButton.transform.position = touchPosition2;
                    }
                    else
                    {
                        _joyButton.transform.position = transform.position + (new Vector3(delta.normalized.x, delta.normalized.y) * _radius);
                    }

                    _player.MovePlayer(delta.normalized);

                    break;
            }
           
        }
    }

    private void ToggleVisibility(bool state)
    {
        _joystickBackground.SetActive(state);
        _joyButton.SetActive(state);
    }
}
