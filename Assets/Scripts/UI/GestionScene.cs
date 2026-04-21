using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionScene : MonoBehaviour
{
    public string sceneIntro = "";
    public string sceneJeu = "";

    public void DemarrerJeu()
    {
        SceneManager.LoadScene(sceneJeu);
    }
}
