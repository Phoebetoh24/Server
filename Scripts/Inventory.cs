using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using System;

public class Inventory : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Msg, Msg1, Msg2, Msg3;

    [SerializeField]
    private TMP_Text text;

    void Awake()
    { 
        GetCatalog();
        GetPlayerInventory();
        GetVirtualCurrencies(); 
    }
    void UpdateMsg(string msg) //to display in console and messagebox
    {
        Debug.Log(msg);
        Msg.text += msg + '\n';
    }

    void UpdateMsg1(string msg1) //to display in console and messagebox
    {
        Debug.Log(msg1);
        Msg1.text += msg1 + '\n';
    }
    void UpdateMsg2(string msg2) //to display in console and messagebox
    {
        Debug.Log(msg2);
        Msg2.text += msg2 + '\n';
    }
    void UpdateMsg3(string msg3) //to display in console and messagebox
    {
        Debug.Log(msg3);
        Msg3.text += msg3 + '\n';
    }

    void OnError(PlayFabError e)
    {
        UpdateMsg(e.GenerateErrorReport());
    }
    public void LoadScene(string scn)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scn);
    }

    public void GetVirtualCurrencies()
    {
        PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), r =>
        {
            int coins = r.VirtualCurrency["GD"]; //replace CN with your currrency
            UpdateMsg("" + coins);

        }, OnError);
    }
    public void GetPlayerInventory()
    {
        var UserInv = new GetUserInventoryRequest();
        PlayFabClientAPI.GetUserInventory(UserInv, result =>
        {
            List<ItemInstance> ii = result.Inventory;
            foreach (ItemInstance i in ii)
            {
                UpdateMsg2(i.DisplayName + "," + i.ItemId + "," + i.ItemInstanceId + "\n");
            }
        }, OnError);
    }
    public void BuyItem()
    {

        var buyreq = new PurchaseItemRequest
        {

            //current sample is hardcoded, should make it more dynamic
            CatalogVersion = "main",
            ItemId = "Axe", //replace with your item id
            VirtualCurrency = "GD",
            Price = 7

        };
        PlayFabClientAPI.PurchaseItem(buyreq, result =>
      {
       UpdateMsg3("Bought!");
      }, OnError);
    }
    public void BuyItem1()
    {
        var buyreq1 = new PurchaseItemRequest
        {

            //current sample is hardcoded, should make it more dynamic
            CatalogVersion = "main",
            ItemId = "Gun", //replace with your item id
            VirtualCurrency = "GD",
            Price = 10

        };
        PlayFabClientAPI.PurchaseItem(buyreq1, result =>
        {
            UpdateMsg3("Bought!");
        }, OnError);
    }

    public void BuyItem2()
    {
        var buyreq2 = new PurchaseItemRequest
        {

            //current sample is hardcoded, should make it more dynamic
            CatalogVersion = "main",
            ItemId = "Shield", //replace with your item id
            VirtualCurrency = "GD",
            Price = 5

        };
        PlayFabClientAPI.PurchaseItem(buyreq2, result =>
        {
            UpdateMsg3("Bought!");
        }, OnError);
    }
    public void BuyItem3()
    {
        var buyreq3 = new PurchaseItemRequest
        {

            //current sample is hardcoded, should make it more dynamic
            CatalogVersion = "main",
            ItemId = "Sword", //replace with your item id
            VirtualCurrency = "GD",
            Price = 5

        };
        PlayFabClientAPI.PurchaseItem(buyreq3, result =>
        {
            UpdateMsg3("Bought!");
        }, OnError);
    }
    public void GetCatalog()
    {
        var catreq = new GetCatalogItemsRequest 
        {
            CatalogVersion = "main", //update catalog name
            
        };

        PlayFabClientAPI.GetCatalogItems(catreq, result =>
        {
            List<CatalogItem> items = result.Catalog;
            foreach (CatalogItem i in items)
            {
                 UpdateMsg1(i.DisplayName + "," + i.VirtualCurrencyPrices["GD"] + "\n");
                
            }
        }, OnError);
    }
}
