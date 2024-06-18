using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    [SerializeField] TextMeshProUGUI displayBalance;

    void Awake()
    {
        currentBalance = startingBalance;
        UpdateBalance();
    }

    public int CurrentBalance { get { return currentBalance; } }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateBalance();
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateBalance();
        if (currentBalance < 0)
        {
            ReloadScene();
        }
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    void UpdateBalance()
    {
        displayBalance.text = "Gold:" + currentBalance;
    }

}
