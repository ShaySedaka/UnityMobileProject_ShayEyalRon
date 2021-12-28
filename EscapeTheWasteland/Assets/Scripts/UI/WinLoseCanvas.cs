using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinLoseCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bigText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetWinData()
    {
        _bigText.color = Color.yellow;
        _bigText.text = "You Win!";
    }

    public void SetLoseData()
    {
        _bigText.color = Color.red;
        _bigText.text = "You Lose!";
    }

    public void Restart()
    {
        // restart the scene
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
