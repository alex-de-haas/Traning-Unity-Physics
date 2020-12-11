using Ascetic.Unity.PixelText;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public SceneData Data;
    public PixelTextRenderer Title;
    public PixelTextRenderer Subtitle;

    void Awake()
    {
        LoadScene();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.UnloadSceneAsync(Data.SceneName);
            LoadScene();
        }
    }

    private void LoadScene()
    {
        Title.Text = Data.Title;
        Subtitle.Text = Data.Subtitle;
        SceneManager.LoadScene(Data.SceneName, LoadSceneMode.Additive);
    }
}
