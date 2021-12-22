using UnityEngine;
using TMPro;

public class ResourceCostUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _resourceText;

    public void ActivateCost(int cost)
    {
        gameObject.SetActive(true);
        _resourceText.text = cost.ToString();
    }
}
