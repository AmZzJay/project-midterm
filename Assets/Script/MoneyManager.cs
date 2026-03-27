using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;

    public int money = 10; // เงินเริ่มต้น

    void Awake()
    {
        instance = this;
    }

    public void AddMoney(int amount)
    {
        money += amount;
        Debug.Log("Money: " + money);
    }

    public bool SpendMoney(int amount)
    {
        if (money >= amount)
        {
            money -= amount;
            Debug.Log("Money: " + money);
            return true;
        }

        Debug.Log("Not enough money!");
        return false;
    }
}