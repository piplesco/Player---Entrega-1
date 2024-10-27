using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject menuPanel; // Panel del menú principal
    public GameObject buttonPanel; // Panel que contiene los botones del menú
    public Text controlsText; // Texto que muestra los controles
    public Text creditsText; // Texto que muestra los créditos
    public Text returnText; // Texto para "Pulsa L para volver"
    public Text closeText; // Texto para "Pulsa K para cerrar"

    private bool isMenuOpen = false;
    private bool isInSubMenu = false; // Nuevo estado para controlar si estamos en Controles o Créditos

    void Start()
    {
        // Inicializar los elementos de la UI y esconder textos secundarios
        controlsText.gameObject.SetActive(false);
        creditsText.gameObject.SetActive(false);

        menuPanel.SetActive(false);

        // Asegurar que el cursor esté oculto inicialmente
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Abre o cierra el menú con la tecla M
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMenu();
        }

        // Al pulsar L para volver al menú principal si está en un submenú
        if (isMenuOpen && isInSubMenu && Input.GetKeyDown(KeyCode.L))
        {
            ShowMenuButtons();
        }

        // Al pulsar K para cerrar el menú completamente
        if (isMenuOpen && Input.GetKeyDown(KeyCode.K))
        {
            ToggleMenu();
        }
    }

    // Función que abre o cierra el menú principal
    private void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        menuPanel.SetActive(isMenuOpen);
        Time.timeScale = isMenuOpen ? 0 : 0;

        if (isMenuOpen)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            ShowMenuButtons(); // Siempre mostrar el menú principal al abrir
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            CloseCredits(); // Asegura que controles y créditos se cierren al cerrar el menú
            CloseControls();
        }
    }

    // Función para cerrar el menú y continuar el juego
    public void ContinueGame()
    {
        ToggleMenu(); // Cierra el menú y reanuda el juego
    }

    // Muestra el panel de controles
    public void ShowControls()
    {
        buttonPanel.SetActive(false); // Oculta los botones del menú
        controlsText.gameObject.SetActive(true);
        creditsText.gameObject.SetActive(false);
        returnText.gameObject.SetActive(true);
        closeText.gameObject.SetActive(true);
        controlsText.text = "CONTROLES:\nZOOM [E]\nPRIMERA PERSONA [C]\nBOTÓN DE ACCIÓN [F]\nMOVIMIENTO [WASD]\nSALTAR [SPACE]\nRALENTIZAR [SHIFT]";
        isInSubMenu = true; // Activa el estado de submenú
    }

    // Cierra el panel de controles
    private void CloseControls()
    {
        controlsText.gameObject.SetActive(false);
        returnText.gameObject.SetActive(false);
        closeText.gameObject.SetActive(false);
        isInSubMenu = false; // Salimos del submenú
    }

    // Muestra el panel de créditos
    public void ShowCredits()
    {
        buttonPanel.SetActive(false); // Oculta los botones del menú
        creditsText.gameObject.SetActive(true);
        controlsText.gameObject.SetActive(false);
        returnText.gameObject.SetActive(true);
        closeText.gameObject.SetActive(true);
        creditsText.text = "CRÉDITOS:\nJorge Cabrera\nPablo García\nUnai Fernández";
        isInSubMenu = true; // Activa el estado de submenú
    }

    // Cierra el panel de créditos
    private void CloseCredits()
    {
        creditsText.gameObject.SetActive(false);
        returnText.gameObject.SetActive(false);
        closeText.gameObject.SetActive(false);
        isInSubMenu = false; // Salimos del submenú
    }

    // Muestra los botones del menú principal
    private void ShowMenuButtons()
    {
        buttonPanel.SetActive(true);
        controlsText.gameObject.SetActive(false);
        creditsText.gameObject.SetActive(false);
        returnText.gameObject.SetActive(false);
        closeText.gameObject.SetActive(false);
        isInSubMenu = false; // Resetea el estado de submenú
    }
}