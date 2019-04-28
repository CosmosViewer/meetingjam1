using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LightBar : MonoBehaviour
{
    public Image barra;
    public bool abaixando;
    public float tempo = 2;
    bool falhou;
    public Luz luz;
    public bool grande;
    public bool isProtecting;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (!abaixando && !falhou && !grande)
            {
                abaixando = true;
            }
            else
            {
                if(barra.fillAmount < 0.2f && !falhou)
                {
                    luz.Grow();
                    grande = true;
                    barra.fillAmount = 1;
                    abaixando = false;
                    GameObject.FindGameObjectWithTag("shadow").GetComponent<Shadow_Lurk> ().stoped = true;
                }
                else if(!falhou)
                {
                    Falhou();
                }
            }
        }

        if (abaixando)
        {
            isProtecting = true;
            barra.fillAmount -= 1.0f / tempo * Time.deltaTime;
            if(barra.fillAmount == 0)
            {
                Falhou();
            }
        }

        if (falhou)
        {
            barra.fillAmount += 1.0f / 6 * Time.deltaTime;
            if(barra.fillAmount == 1)
            {
                falhou = false;
            }
        }
    }

    void Falhou()
    {
        barra.fillAmount = 0;
        abaixando = false;
        falhou = true;
        luz.Down();
    }
}