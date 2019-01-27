using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitreManager : MonoBehaviour
{
    public InputField text;
    public NomVille nomVille;


    public void buttonStart()
    {
        nomVille.nomVille = text.text;
        SceneManager.LoadScene(1);
    }
}
