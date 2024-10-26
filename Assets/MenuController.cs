using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject menuPanel; // Panel del men�
    public Text controlsText; // Texto de controles
    public Text creditsText; // Texto de cr�ditos

    private bool isMenuOpen = false;

    void Start()
    {
        // Inicializar los objetos de texto
        controlsText = GameObject.Find("ControlsText").GetComponent<Text>();
        creditsText = GameObject.Find("CreditsText").GetComponent<Text>();

        // Desactivar los textos de controles y cr�ditos al inicio
        controlsText.gameObject.SetActive(false);
        creditsText.gameObject.SetActive(false);
    }

    void Update()
    {
        // Abrir el men� al pulsar M
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMenu();
        }

        // Volver al men� reci�n abierto al pulsar L
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (!isMenuOpen) // Solo si el men� est� cerrado
            {
                ToggleMenu(); // Abrir el men�
                CloseControls(); // Aseg�rate de cerrar controles
                CloseCredits(); // Aseg�rate de cerrar cr�ditos
            }
        }

        // Cerrar el men� completamente al pulsar K
        if (Input.GetKeyDown(KeyCode.K))
        {
            CloseMenu(); // Cerrar el men�
        }

        // Ejecutar CONTINUAR al pulsar B
        if (Input.GetKeyDown(KeyCode.B) && isMenuOpen)
        {
            ContinueGame();
        }

        // Ejecutar CONTROLES al pulsar N
        if (Input.GetKeyDown(KeyCode.N) && isMenuOpen)
        {
            if (controlsText.gameObject.activeSelf)
            {
                CloseControls();
            }
            else
            {
                ShowControls();
            }
        }

        // Ejecutar CR�DITOS al pulsar V
        if (Input.GetKeyDown(KeyCode.V) && isMenuOpen)
        {
            if (creditsText.gameObject.activeSelf)
            {
                CloseCredits();
            }
            else
            {
                ShowCredits();
            }
        }
    }

    // Funci�n para mostrar/ocultar el men�
    private void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        menuPanel.SetActive(isMenuOpen);
        Time.timeScale = isMenuOpen ? 0 : 1; // Pausar el juego
    }

    // Funci�n para cerrar el men� completamente
    public void CloseMenu()
    {
        isMenuOpen = false; // Cambia el estado del men� a cerrado
        menuPanel.SetActive(false); // Desactiva el men�
        CloseControls(); // Aseg�rate de cerrar el texto de controles
        CloseCredits(); // Aseg�rate de cerrar el texto de cr�ditos
        Time.timeScale = 1; // Reanuda el juego
    }

    // Funci�n para continuar el juego
    public void ContinueGame()
    {
        ToggleMenu(); // Cerrar el men�
    }

    // Funci�n para mostrar controles
    public void ShowControls()
    {
        controlsText.gameObject.SetActive(true);
        creditsText.gameObject.SetActive(false);
        ToggleMenu(); // Cerrar el men�
        // Muestra los controles en el texto
        controlsText.text = "CONTROLES:\nZOOM [E]\nPRIMERA PERSONA [C]\nBOT�N DE ACCI�N [F]\nMOVIMIENTO [WASD]\nSALTAR [SPACE]\nRALENTIZAR [SHIFT]";
    }

    // Funci�n para cerrar controles
    public void CloseControls()
    {
        controlsText.gameObject.SetActive(false);
    }

    // Funci�n para mostrar cr�ditos
    public void ShowCredits()
    {
        creditsText.gameObject.SetActive(true);
        controlsText.gameObject.SetActive(false);
        ToggleMenu(); // Cerrar el men�
        // Muestra los cr�ditos en el texto
        creditsText.text = "CR�DITOS:\nJorge Cabrera\nPablo Garc�a\nUnai Fern�ndez";
    }

    // Funci�n para cerrar cr�ditos
    public void CloseCredits()
    {
        creditsText.gameObject.SetActive(false);
    }
}
