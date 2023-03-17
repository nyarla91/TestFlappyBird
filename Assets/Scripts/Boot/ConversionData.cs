using System;
using System.Collections.Generic;
using System.Text;
using AppsFlyerSDK;
using TMPro;
using UnityEngine;

namespace Boot
{
    public class ConversionData : MonoBehaviour, IAppsFlyerConversionData
    {
        [SerializeField] private TMP_Text _conversionTMP;
        [SerializeField] private string _devKey;
        [SerializeField] private string _appID;

        private void Start()
        {
            AppsFlyer.setIsDebug(true);
            AppsFlyer.OnRequestResponse += AppsFlyerOnRequestResponse;
            AppsFlyer.initSDK(_devKey, _appID, this);
            AppsFlyer.startSDK();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
                AppsFlyer.getConversionData(gameObject.name);
        }

        void AppsFlyerOnRequestResponse(object sender, EventArgs e)
        {
            var args = e as AppsFlyerRequestEventArgs;
            AppsFlyer.AFLog("AppsFlyerOnRequestResponse", " status code " + args.statusCode);
        }

        public void onConversionDataSuccess(string conversionData)
        {
            AppsFlyer.AFLog("onConversionDataSuccess", conversionData);
            Dictionary<string, object> conversionDataDictionary = AppsFlyer.CallbackStringToDictionary(conversionData);
            print("Hey");
            _conversionTMP.text = conversionData;
        }

        public void onConversionDataFail(string error)
        {
            AppsFlyer.AFLog("onConversionDataFail", error);
            print("FAILO");
        }

        public void onAppOpenAttribution(string attributionData)
        {
            AppsFlyer.AFLog("onAppOpenAttribution", attributionData);
            Dictionary<string, object> attributionDataDictionary = AppsFlyer.CallbackStringToDictionary(attributionData);
        }

        public void onAppOpenAttributionFailure(string error)
        {
            AppsFlyer.AFLog("onAppOpenAttributionFailure", error);
        }
    }
}