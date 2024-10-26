using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject menuPanel; // Panel del menú
    public Text controlsText; // Texto de controles
    public Text creditsText; // Texto de créditos

    private bool isMenuOpen = false;

    void Start()
    {
        // Inicializar los objetos de texto
        controlsText = GameObject.Find("ControlsText").GetComponent<Text>();
        creditsText = GameObject.Find("CreditsText").GetComponent<Text>();

        // Desactivar los textos de controles y créditos al inicio
        controlsText.gameObject.SetActive(false);
        creditsText.gameObject.SetActive(false);
    }

    void Update()
    {
        // Abrir el menú al pulsar M
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMenu();
        }

        // Volver al menú recién abierto al pulsar L
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (!isMenuOpen) // Solo si el menú está cerrado
            {
                ToggleMenu(); // Abrir el menú
                CloseControls(); // Asegúrate de cerrar controles
                CloseCredits(); // Asegúrate de cerrar créditos
            }
        }

        // Cerrar el menú completamente al pulsar K
        if (Input.GetKeyDown(KeyCode.K))
        {
            CloseMenu(); // Cerrar el menú
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

        // Ejecutar CRÉDITOS al pulsar V
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

    // Función para mostrar/ocultar el menú
    private void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        menuPanel.SetActive(isMenuOpen);
        Time.timeScale = isMenuOpen ? 0 : 1; // Pausar el juego
    }

    // Función para cerrar el menú completamente
    public void CloseMenu()
    {
        isMenuOpen = false; // Cambia el estado del menú a cerrado
        menuPanel.SetActive(false); // Desactiva el menú
        CloseControls(); // Asegúrate de cerrar el texto de controles
        CloseCredits(); // Asegúrate de cerrar el texto de créditos
        Time.timeScale = 1; // Reanuda el juego
    }

    // Función para continuar el juego
    public void ContinueGame()
    {
        ToggleMenu(); // Cerrar el menú
    }

    // Función para mostrar controles
    public void ShowControls()
    {
        controlsText.gameObject.SetActive(true);
        creditsText.gameObject.SetActive(false);
        ToggleMenu(); // Cerrar el menú
        // Muestra los controles en el texto
        controlsText.text = "CONTROLES:\nZOOM [E]\nPRIMERA PERSONA [C]\nBOTÓN DE ACCIÓN [F]\nMOVIMIENTO [WASD]\nSALTAR [SPACE]\nRALENTIZAR [SHIFT]";
    }

    // Función para cerrar controles
    public void CloseControls()
    {
        controlsText.gameObject.SetActive(false);
    }

    // Función para mostrar créditos
    public void ShowCredits()
    {
        creditsText.gameObject.SetActive(true);
        controlsText.gameObject.SetActive(false);
        ToggleMenu(); // Cerrar el menú
        // Muestra los créditos en el texto
        creditsText.text = "CRÉDITOS:\nJorge Cabrera\nPablo García\nUnai Fernández";
    }

    // Función para cerrar créditos
    public void CloseCredits()
    {
        creditsText.gameObject.SetActive(false);
    }
}
