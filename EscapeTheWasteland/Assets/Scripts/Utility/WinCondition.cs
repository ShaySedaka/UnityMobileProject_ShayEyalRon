using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    [SerializeField] int _rarestResourceAmount = 3;
    [SerializeField] PlayableDirector _endClipDirector;
    [SerializeField] Cinemachine.CinemachineVirtualCamera _virtualCamera;
    [SerializeField] GameObject _car;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (CheckWinCondition(player))
            {
                EndGame();
            }
        }
    }

    private bool CheckWinCondition(PlayerController player)
    {
        if(player.Inventory.ResourceInventory[ResourceType.Coal] >= _rarestResourceAmount)
        {
            return true;
        }
        return false;
    }

    private void EndGame()
    {
        UIManager.Instance.TurnOnWinCanvas();
        ActivateCinematic();

    }
    private void ActivateCinematic()
    {
        _virtualCamera.Follow = _car.transform;
        _virtualCamera.LookAt = _car.transform;
        _endClipDirector.Play();
    }
}
