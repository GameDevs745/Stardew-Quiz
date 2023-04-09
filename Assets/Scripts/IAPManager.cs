using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour
{
    private string removeAds = "com.breechewproductions.stardewvalleyquiz.removeads";

    public void OnPurchaseComplete(Product product)
{
    if(product.definition.id == removeAds)
    {
        PlayerPrefs.SetInt("bannerAd", 1);
        PlayerPrefs.SetInt("interstitialAd", 1);
        PlayerPrefs.SetInt("rewardedAd", 1);
        PlayerPrefs.SetInt("infiniteEnergy", 1);


        }
}
    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
{
    Debug.Log(product.definition.id + "failed because" + failureReason);
}
}