using UnityEngine;

public class Pause : MonoBehaviour
{
    private ActivateEBottons activateEBottons;
    void Start()
    {
        activateEBottons = FindFirstObjectByType<ActivateEBottons>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 1f)
            {
                activateEBottons.Pause();
            }
            else
            {
                activateEBottons.Despause();
            }
        }
    }
}
