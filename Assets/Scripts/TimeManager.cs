using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public int temps = 3;
    public Text tempsText;
    public GameObject cameraPhoto;
    public GameObject cameraJeu;
    public WindController wind;

    public List<GameObject> trucsAMasquer;
    public GameObject titre;

    private bool end = false;
    // Start is called before the first frame update
    void Start()
    {
        tempsText.text = temps.ToString();
        StartCoroutine(TempsDefile());
    }
    
    public IEnumerator TempsDefile()
    {
        while (temps > 0)
        {
            yield return new WaitForSeconds(1);
            temps--;
            tempsText.text = temps.ToString();
            if(temps%30 == 0)
            {
                WindController.instance.maxDownSpeed+=0.5f;
                WindController.instance.speedThreshold+=0.5f;
                Physics.gravity = Physics.gravity+Vector3.down*0.5f;

            }
        }

        //Comportement de fin de partie
        GetComponent<HouseFactory>().enabled = false;
        cameraPhoto.SetActive(true);
        cameraJeu.SetActive(false);
        titre.SetActive(true);
        wind.enabled = false;
        foreach(GameObject go in trucsAMasquer)
        {
            go.SetActive(false);
        }
        end = true;
    }

    private void Update()
    {
        if(end == true && Input.GetMouseButton(0))
        {
            SceneManager.LoadScene(0);
        }
    }

}
