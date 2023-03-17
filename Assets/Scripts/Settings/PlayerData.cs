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
                string folderPath = Application.dataPath + "/PlayerData/";
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);
                return folderPath;
            }
        }
    }
}