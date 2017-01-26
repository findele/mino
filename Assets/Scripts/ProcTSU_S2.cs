using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcTSU_S2 : MonoBehaviour
{

    /***************************
     * Projectile lance tir en haut salle 1*
     * *************************/

    // declaration variables
    int[,] GrilleMap = new int[30, 5]; // Tableau pour gestion salle1
    int xPiege = 0;
    int yPiege = 0;
    int HautBas = 0;
    int PiegePoseOk = 0;
    [SerializeField]
    GameObject throwSpearsUp;


    // Use this for initialization
    void Start()
    {
        // Gestion emplacement alélatoire des lances
        for (int i = 0; i <= 2; i++)
        {

            // Attribution des coordonnées           
            xPiege = Random.Range(23, 29);
            yPiege = Random.Range(2, 2);


            // Creation du piege sur les coordonnées définis
            // Si la place est déjà occupé, rien n'est placé
            if (PiegePoseOk != 30)
            {
                if (GrilleMap[xPiege, yPiege] == 0)
                {
                    PiegePoseOk++;
                    Vector3 pos0 = new Vector3(xPiege, yPiege, 0);
                    Quaternion rot0 = Quaternion.identity;
                    GameObject Lance0 = (GameObject)Instantiate(throwSpearsUp, pos0, rot0);
                    GrilleMap[xPiege, yPiege] = PiegePoseOk;

                }

            }

        }
    }

    // Update is called once per frame
    void Update()
    {


    }
}
