using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargerNomVille : MonoBehaviour
{
    public Text text;
    public NomVille nom;

    public void Start()
    {
        text.text = nom.nomVille;
    }
}
