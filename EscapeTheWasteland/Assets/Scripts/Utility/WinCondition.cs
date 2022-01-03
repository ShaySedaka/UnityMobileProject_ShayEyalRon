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
    [SerializeField] GameObject _player;

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
        _player.transform.SetParent(_car.transform);
        _player.transform.localPosition = new Vector3(0,0,0);
        _player.transform.rotation = new Quaternion(0,0,142,0);
        _endClipDirector.Play();
    }
    public void StopTime()
    {
        Time.timeScale = 0;
    }
}
