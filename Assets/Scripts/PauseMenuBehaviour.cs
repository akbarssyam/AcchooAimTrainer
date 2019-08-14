using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenuBehaviour : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public FirstPersonController fpsController;
    public Slider slider;
    public TMP_InputField inputField;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        // Enable fps controller
        fpsController.enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        // Enable mouse movement by disabling fps controller
        fpsController.enabled = false;
        // Had to manually enable cursor otherwise it'll get overwritten by fps controller
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        // Show the current mouse sensitivity
        float sens = fpsController.GetMouseSensitivity();
        slider.value = sens;
        inputField.text = sens.ToString();
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void Sensitivity_SliderChanged()
    {
        float sens = slider.value;
        inputField.text = sens.ToString();
        fpsController.ChangeMouseSensitivity(sens, sens);
    }

    public void Sensitivity_InputFieldChanged()
    {
        float sens = 0f;
        if (!float.TryParse(inputField.text, out sens))
        {
            sens = fpsController.GetMouseSensitivity();
        }

        slider.value = sens;
        fpsController.ChangeMouseSensitivity(sens, sens);
    }
}
