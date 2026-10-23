using System.IO;
using UnityEngine;

public class OpenFolder : MonoBehaviour
{
    
    public void BTN_OpenFolder()
    {
        System.Diagnostics.Process.Start("explorer.exe", "/select," + Path.Combine(Application.persistentDataPath , "SaveSimple.txt"));
    }
}
