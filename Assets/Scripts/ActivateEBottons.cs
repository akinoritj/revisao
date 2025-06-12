using UnityEngine.SceneManagement;
using UnityEngine;

public class ActivateEBottons : MonoBehaviour
{
    [SerializeField] private GameObject creditosPainel;
    [SerializeField] private GameObject playPainel;
    [SerializeField] private GameObject pausePainel;
    void Start()
    {
        if (playPainel != null)
        {
            playPainel.SetActive(true);
        }

        if (creditosPainel != null)
        {
            creditosPainel.SetActive(false);
        }

        if (pausePainel != null)
        {
            pausePainel.SetActive(false);
        }
    }

    public void AtivarCreditos()
    {
        if (creditosPainel != null)
        {
            creditosPainel.SetActive(true);
        }
        if (playPainel != null)
        {
            playPainel.SetActive(false);
        }
    }

    public void DesativarCreditos()
    {
        if (creditosPainel != null)
        {
            creditosPainel.SetActive(false);
        }
        if (playPainel != null)
        {
            playPainel.SetActive(true);
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
        pausePainel.SetActive(true);
    }

    public void Despause()
    {
        Time.timeScale = 1f;
        pausePainel.SetActive(false);
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
