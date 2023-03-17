using System;
using System.IO;
using UnityEngine;

namespace Settings
{
    public class PlayerData : MonoBehaviour
    {
        public static string Path
        {
            get
            {
                string folder = "/PlayerData/";
                string folderPath = Application.platform switch
                {
                    RuntimePlatform.Android => Application.temporaryCachePath + folder,
                    _ => Application.dataPath + folder
                };
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);
                return folderPath;
            }
        }
    }
}