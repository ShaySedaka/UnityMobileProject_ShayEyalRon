using UnityEngine;

public class Workbench : MonoBehaviour
{
    [SerializeField]
    GameObject _upgradeCnavas;
    [SerializeField]
    UpgradeUIHandler _upgradeUIHandler;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _upgradeCnavas.gameObject.SetActive(true);
            SetCostsForUpgrades();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _upgradeCnavas.gameObject.SetActive(false);
        }
    }
    public void SetCostsForUpgrades()
    {
        //get data from player about the level of his upgrads
        _upgradeUIHandler.UpgradeItemLevels(1, 1);
    }
}
