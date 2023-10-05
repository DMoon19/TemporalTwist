using System.Net.Mime;
using System.Threading.Tasks;
using System;
using System.Reflection;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tp : MonoBehaviour
{
     private bool menuActive = false;
     public Text[] menuOptions;
     private int currentOptionIndex;
     [SerializeField] GameObject uiCronoReloj;


    [SerializeField] GameObject player;
    [SerializeField] GameObject tpArriba;
    [SerializeField] GameObject tpAbajo;
   
   private void Update()
    {
        // Activa o desactiva el menú con la tecla "T"
        if (Input.GetKeyDown(KeyCode.Q))
        {
            menuActive = !menuActive;
            uiCronoReloj.SetActive(menuActive);

            // Reinicia el índice de la opción actual cuando se activa el menú
            if (menuActive)
            {
                currentOptionIndex = 0;
                UpdateOptionHighlight();
            }
        }

        // Si el menú está activo, permite la navegación entre las opciones
        if (menuActive)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                // Mover hacia arriba en las opciones
                currentOptionIndex = (currentOptionIndex - 1 + menuOptions.Length) % menuOptions.Length;
                UpdateOptionHighlight();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                // Mover hacia abajo en las opciones
                currentOptionIndex = (currentOptionIndex + 1) % menuOptions.Length;
                UpdateOptionHighlight();
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                // Realizar acción de selección (aquí puedes agregar la lógica para cada opción)
                SelectOption();
            }
        }
    }

    // Actualiza la apariencia de las opciones del menú para resaltar la opción actual
    private void UpdateOptionHighlight()
    {
        for (int i = 0; i < menuOptions.Length; i++)
        {
            if (i == currentOptionIndex)
            {
                menuOptions[i].color = Color.yellow;
            }
            else
            {
                menuOptions[i].color = Color.white;
            }
        }
    }

    // Lógica para ejecutar cuando se selecciona una opción (puedes personalizarla)
    private void SelectOption()
    {
        menuActive = false;
        uiCronoReloj.SetActive(false);  
        
      Vector3 targetPosition = Vector3.zero;

        switch (currentOptionIndex)
        {
            case 0:
            
              if (player.transform.position.y > 30f)
            {
                // No hacer teleportación si la condición no se cumple
                return;
            }
            // Mover al jugador arriba
            targetPosition = tpArriba.transform.position;
            break;

            case 1:
           if (player.transform.position.y < -2f)
            {
                // No hacer teleportación si la condición no se cumple
                return;
            }
            // Mover al jugador abajo
            targetPosition = tpAbajo.transform.position;
                break;
        }

        // Desactivar el menú después de seleccionar una opción
        menuActive = false;
        uiCronoReloj.SetActive(false);
         player.transform.position = targetPosition;
    }
}