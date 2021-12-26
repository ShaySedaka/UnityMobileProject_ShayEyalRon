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
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            SetCostsForUpgrades(inventory);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _upgradeCnavas.gameObject.SetActive(false);
        }
    }
    public void SetCostsForUpgrades(PlayerInventory player)
    {
        //get data from player about the level of his upgrads
        _upgradeUIHandler.UpgradeItemLevels(player.Pickaxe.Level, player.Gun.Level);
    }
}
