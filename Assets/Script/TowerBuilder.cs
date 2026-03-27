using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    public GameObject towerPrefab;
    public int towerCost = 5;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // คลิกซ้าย
        {
            PlaceTower();
        }
    }

    void PlaceTower()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // เช็คเงินก่อน
            if (MoneyManager.instance.SpendMoney(towerCost))
            {
                Instantiate(towerPrefab, hit.point, Quaternion.identity);
            }
            else
            {
                Debug.Log("เงินไม่พอ!");
            }
        }
    }
}