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

        public event Action Loaded;

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
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

            StringBuilder conversionLog = new StringBuilder();
            foreach (KeyValuePair<string,object> pair in conversionDataDictionary)
            {
                conversionLog.Append($"{pair.Key} : {pair.Value}\n");
            }
            _conversionTMP.text = conversionLog.ToString();
            Loaded?.Invoke();
        }

        public void onConversionDataFail(string error)
        {
            AppsFlyer.AFLog("onConversionDataFail", error);
            _conversionTMP.text = "Ошибка в загрузкеы";
        }

        public void onAppOpenAttribution(string attributionData)
        {
            AppsFlyer.AFLog("onAppOpenAttribution", attributionData);
        }

        public void onAppOpenAttributionFailure(string error)
        {
            AppsFlyer.AFLog("onAppOpenAttributionFailure", error);
        }
    }
}