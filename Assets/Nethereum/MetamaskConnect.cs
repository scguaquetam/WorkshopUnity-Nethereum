using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nethereum.Unity.Metamask;
using UnityEngine.UI;
using TMPro;
public class MetamaskConnect : MonoBehaviour
{
    public Button continueBtn;
    public TMP_Text errorTxt;
    bool _isMetamaskInitialised; 
    public TMP_Text address, chainId;
    public string addressStg, chainIdStg;
    public bool IsWebGl()
    {
#if UNITY_WEBGL
        return true;
#else
        return false;
#endif
    }
    public void MetamaskConnectFn()
    {
#if UNITY_WEBGL
        if(IsWebGl())
        {
            if(MetamaskInterop.IsMetamaskAvailable())
            {
                MetamaskInterop.EnableEthereum(gameObject.name,nameof(EthereumEnabled), nameof(DisplayError));
                continueBtn.interactable = true;
                Debug.Log("Lo hizo bien");
            }
            else 
            {
                DisplayError("Metamask is not available");
            }
        }
#endif
    }
    public void EthereumEnabled(string addressSelected)
    {
#if UNITY_WEBGL
        if(IsWebGl())
        {
            if(!_isMetamaskInitialised)
            {
                MetamaskInterop.EthereumInit(gameObject.name, nameof(NewAccountSelect), nameof(ChainChanged));
            }
        }
#endif
    }
    public void NewAccountSelect(string accountAddress) 
    {
        print("connected");
        addressStg = accountAddress;
        address.text = accountAddress;
    }
    public void ChainChanged(string _chainId) 
    {
        print("connected chain id");
        chainIdStg = _chainId;
        chainId.text = _chainId;
    }
    public void DisplayError(string errorMsg)
    {
        errorTxt.text = errorMsg;
    }
}
