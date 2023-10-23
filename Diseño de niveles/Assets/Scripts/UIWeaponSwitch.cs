using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWeaponSwitch : MonoBehaviour
{
    public GameObject freezeGun;
    public GameObject duplicateGun;

    public Image freezeGunImage;
    public Image duplicateGunImage;

    public Transform mainFrame;
    public Transform secondaryFrame;

    private void Update()
    {
        // Verificar qué arma está activa
        bool isFreezeGunActive = freezeGun.activeSelf;
        bool isDuplicateGunActive = duplicateGun.activeSelf;

        // Establecer las propiedades de la imagen de Freeze Gun
        freezeGunImage.color = isFreezeGunActive ? Color.white : Color.gray;
        freezeGunImage.rectTransform.position = isFreezeGunActive ? mainFrame.position : secondaryFrame.position;

        // Establecer las propiedades de la imagen de Duplicate Gun
        duplicateGunImage.color = isDuplicateGunActive ? Color.white : Color.gray;
        duplicateGunImage.rectTransform.position = isDuplicateGunActive ? mainFrame.position : secondaryFrame.position;
    }
}
