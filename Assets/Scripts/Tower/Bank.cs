using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int curBalance;
    [SerializeField] Text displayBalance;

    public int CurBalance { get { return curBalance; } }

    private void Awake()
    {
        curBalance = startingBalance;
    }

    public void Deposit(int amount)
    {
        curBalance += Mathf.Abs(amount);
    }

    public void Withdraw(int amount)
    {
        curBalance -= Mathf.Abs(amount);

        if(curBalance < 0)
        {
            // lose the game
            ReloadScene();
        }
    }

    private void Update()
    {
        displayBalance.text = "Gold " + CurBalance;
    }

    void ReloadScene()
    {
        Scene curScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(curScene.buildIndex);
    }
}
