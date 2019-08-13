using System;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenuBehaviour.GameIsPaused)
        {
            return;
        }

        int prevWeapon = selectedWeapon;

        // If Scroll Down, change to next weapon
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon == transform.childCount - 1)
            {
                selectedWeapon = 0;
            } else
            {
                selectedWeapon++;
            }
        }

        // If Scroll Up, change to previous weapon
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon == 0)
            {
                selectedWeapon = transform.childCount - 1;
            }
            else
            {
                selectedWeapon--;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectedWeapon = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedWeapon = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            selectedWeapon = 3;
        }

        if (selectedWeapon != prevWeapon)
        {
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            weapon.gameObject.SetActive(i == selectedWeapon);
            i++;
        }
    }
}
