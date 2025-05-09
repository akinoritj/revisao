using UnityEngine.SceneManagement;
using UnityEngine;

public class ActivateEBottons : MonoBehaviour
{
    [SerializeField] private GameObject canvaCreditos;
    [SerializeField] private GameObject CanvasPlay;
    [SerializeField] private GameObject CanvasPause;
    void Start()
    {
        if (CanvasPlay != null)
        {
            CanvasPlay.SetActive(true);
        }

        if (canvaCreditos != null)
        {
            canvaCreditos.SetActive(false);
        }

        if (CanvasPause != null)
        {
            CanvasPause.SetActive(false);
        }
    }

    public void AtivarCreditos()
    {
        if (canvaCreditos != null)
        {
            canvaCreditos.SetActive(true);
        }
        if (CanvasPlay != null)
        {
            CanvasPlay.SetActive(false);
        }
    }

    public void DesativarCreditos()
    {
        if (canvaCreditos != null)
        {
            canvaCreditos.SetActive(false);
        }
        if (CanvasPlay != null)
        {
            CanvasPlay.SetActive(true);
        }
    }

    public void SairDoJogo()
    {
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene("Fase1");
        Time.timeScale = 1f;
    }
    public void Pause()
    {   
        Time.timeScale = 0f;
        CanvasPause.SetActive(true);
    }

    public void Despause()
    {
        Time.timeScale = 1f;
        CanvasPause.SetActive(false);
    }
    public void TentarNovamente()
    {
        SceneManager.LoadScene("Fase1");
        Time.timeScale = 1f;
    }
    public void SairMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
