using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerInfoWindow : MonoBehaviour {
    public Tower tower;
    public Text txtInfo;
    public Text txtUpgradeCost;
    private int upgradePrice;
    private GameObject btnUpgrade;

    void Awake()
    {
        btnUpgrade = txtUpgradeCost.transform.parent.gameObject;
    }
    void OnEnable()
    {
        UpdateInfo();
    }
    private void UpdateInfo()
    {
        // Calculate new price for upgrade
        upgradePrice = Mathf.CeilToInt(TowerManager.Instance.GetTowerPrice(tower.type) * 1.5f * tower.towerLevel);
        txtInfo.text = tower.type + " Tower Lv " + tower.towerLevel;

        if (tower.towerLevel < 3)
        {
            btnUpgrade.SetActive(true);
            // Update is called once per frame
            txtUpgradeCost.text = "Upgrade\n" + upgradePrice + " Gold";
        }
        else
        {
            btnUpgrade.SetActive(false);
        }
    }
    public void UpgradeTower()
    {
        if (GameManager.Instance.gold >= upgradePrice)
        {
            GameManager.Instance.gold -= upgradePrice;
            tower.LevelUp();
            gameObject.SetActive(false);
        }
    }
    void Update () {
		
	}
}
