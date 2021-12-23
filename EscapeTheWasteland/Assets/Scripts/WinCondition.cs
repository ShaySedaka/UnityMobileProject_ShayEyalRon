using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
   [SerializeField] int _rarestResourceAmount = 3;

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
        if(player.ResourceInventory[ResourceType.Oil] == _rarestResourceAmount)
        {
            return true;
        }
        return false;
    }

    private void EndGame()
    {
        // TODO: actually show stuff

        // For now: restart scene
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
