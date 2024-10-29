using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject menuPanel; // Panel del men� principal
    public GameObject buttonPanel; // Panel que contiene los botones del men�
    public Text controlsText; // Texto que muestra los controles
    public Text creditsText; // Texto que muestra los cr�ditos
    public Text returnText; // Texto para "Pulsa L para volver"
    public Text closeText; // Texto para "Pulsa K para cerrar"

    private bool isMenuOpen = false;
    private bool isInSubMenu = false; // Nuevo estado para controlar si estamos en Controles o Cr�ditos

    void Start()
    {
        // Inicializar los elementos de la UI y esconder textos secundarios
        controlsText.gameObject.SetActive(false);
        creditsText.gameObject.SetActive(false);

        menuPanel.SetActive(false);

        // Asegurar que el cursor est� oculto inicialmente
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        // Abre o cierra el men� con la tecla M
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMenu();
        }

        // Al pulsar L para volver al men� principal si est� en un submen�
        if (isMenuOpen && isInSubMenu && Input.GetKeyDown(KeyCode.L))
        {
            ShowMenuButtons();
        }

        // Al pulsar K para cerrar el men� completamente
        if (isMenuOpen && Input.GetKeyDown(KeyCode.K))
        {
            ToggleMenu();
        }
    }

    
    private void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        menuPanel.SetActive(isMenuOpen);
        Time.timeScale = isMenuOpen ? 0 : 1;

        if (isMenuOpen)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            ShowMenuButtons(); 
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            CloseCredits(); 
            CloseControls();
        }
    }

    
    public void ContinueGame()
    {
        ToggleMenu();
    }

    
    public void ShowControls()
    {
        buttonPanel.SetActive(false); 
        controlsText.gameObject.SetActive(true);
        creditsText.gameObject.SetActive(false);
        returnText.gameObject.SetActive(true);
        closeText.gameObject.SetActive(true);
        controlsText.text = "CONTROLES:\nZOOM [E]\nPRIMERA PERSONA [C]\nBOT�N DE ACCI�N [F]\nMOVIMIENTO [WASD]\nSALTAR [SPACE]\nRALENTIZAR [SHIFT]";
        isInSubMenu = true; 

    
    private void CloseControls()
    {
        controlsText.gameObject.SetActive(false);
        returnText.gameObject.SetActive(false);
        closeText.gameObject.SetActive(false);
        isInSubMenu = false;


    
    public void ShowCredits()
    {
        buttonPanel.SetActive(false); 
        creditsText.gameObject.SetActive(true);
        controlsText.gameObject.SetActive(false);
        returnText.gameObject.SetActive(true);
        closeText.gameObject.SetActive(true);
        creditsText.text = "CR�DITOS:\nJorge Cabrera\nPablo Garc�a\nUnai Fern�ndez";
        isInSubMenu = true; 

    
    private void CloseCredits()
    {
        creditsText.gameObject.SetActive(false);
        returnText.gameObject.SetActive(false);
        closeText.gameObject.SetActive(false);
        isInSubMenu = false; 

   
    private void ShowMenuButtons()
    {
        buttonPanel.SetActive(true);
        controlsText.gameObject.SetActive(false);
        creditsText.gameObject.SetActive(false);
        returnText.gameObject.SetActive(false);
        closeText.gameObject.SetActive(false);
        isInSubMenu = false; 
    }
}