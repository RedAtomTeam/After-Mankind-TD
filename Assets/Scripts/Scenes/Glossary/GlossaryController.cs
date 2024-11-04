using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlossaryController : MonoBehaviour
{
    [SerializeField] private GlossaryCameraSystem glossaryCamera;
    [SerializeField] private GlossaryInterfaceSystem glossaryInterface;
    [SerializeField] private LoadingScreenSystem_MainScript loadingScreen;


    public void LoadScene(string sceneName)
    {
        loadingScreen.LoadScene(sceneName);
    }
}
