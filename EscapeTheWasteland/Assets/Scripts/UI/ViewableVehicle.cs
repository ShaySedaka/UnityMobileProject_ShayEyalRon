using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewableVehicle : MonoBehaviour
{
    [SerializeField] private GameObject _compass;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            _compass.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            _compass.SetActive(true);
        }
    }
}
