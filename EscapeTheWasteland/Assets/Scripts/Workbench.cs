using UnityEngine;

public class Workbench : MonoBehaviour
{

    [SerializeField]
    GameObject _upgradeCnavas;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _upgradeCnavas.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _upgradeCnavas.gameObject.SetActive(false);
        }
    }
}
