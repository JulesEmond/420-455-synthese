using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void btn_change_scene(int scene_id)
    {
        SceneManager.LoadScene(scene_id);
    }

    public void btn_quit_app()
    {
        Application.Quit();
    }
}
