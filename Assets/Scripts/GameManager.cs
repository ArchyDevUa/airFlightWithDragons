using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _tutorial;
    public bool isGameOver = false;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private Button button;
    [SerializeField] public int _killCount = 0;
    [SerializeField] private TextMeshProUGUI _killCountText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(countTime());
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true)
        {
            gameOverText.gameObject.SetActive(true);
            button.gameObject.SetActive(true);
            Cursor.visible = true;
        }
    }

    IEnumerator countTime()
    {
        yield return new WaitForSeconds(5);
        _tutorial.SetActive(false);
    }

   public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

   public void plusOneKilledDragon()
   {
       _killCount++;
       _killCountText.text = "Kill Count :" + _killCount;
   }
}
