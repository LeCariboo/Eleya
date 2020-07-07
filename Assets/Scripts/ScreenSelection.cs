using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Photon.Pun;

public class ScreenSelection : MonoBehaviourPun
{
    #region Singleton 
    //on crée une unique instance accessible de partout
    public static ScreenSelection instance;
    //appelé avant le start
    protected void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("erreur, il y a deja une instance NetworkItemsController");
            return;
        }
        instance = this;
    }
    #endregion

    public Transform warriorPrefabBack;
    public Transform warriorPrefabFace;
    public Transform wizardPrefabBack;
    public Transform wizardPrefabFace;


    [PunRPC]
    public void sendList()
    {
        generateAllyCharacter();
        generateEnnemyCharacter();
        loadScene();
    }


    public void generateEnnemyCharacter()
    {

        int o = 1;
        foreach (int selected in EnnemySelection)
        {
<<<<<<< Updated upstream

            if (selected == 0)
            {
                if (o == 1)
                {
                   PhotonNetwork.Instantiate(Path.Combine("Prefab", "warriorPrefabFace"), new Vector3(-7f, 1.5f, 1), Quaternion.identity);
                   o++;
                }
                else if (o == 2)
                {
                    PhotonNetwork.Instantiate(Path.Combine("Prefab", "warriorPrefabFace"), new Vector3(-6, 2, 1), Quaternion.identity);
                    o++;
                }
                else if (o == 3)
                {
                    PhotonNetwork.Instantiate(Path.Combine("Prefab", "warriorPrefabFace"), new Vector3(-5f, 2.5f, 1), Quaternion.identity);
                    o++;
                }
=======
            Debug.Log("Liste envoyer");
        }
        
        Debug.Log("Liste reçu"); 
    }
>>>>>>> Stashed changes

            }
            else if (selected == 1)
            {
                if (o == 1)
                {
                    PhotonNetwork.Instantiate(Path.Combine("Prefab", "wizardPrefabFace"), new Vector3(-7f, 1.5f, 1), Quaternion.identity);
                    o++;
                }
                else if (o == 2)
                {
                    PhotonNetwork.Instantiate(Path.Combine("Prefab", "wizardPrefabFace"), new Vector3(-6, 2, 1), Quaternion.identity);
                    o++;
                }
                else if (o == 3)
                {
                    PhotonNetwork.Instantiate(Path.Combine("Prefab", "wizardPrefabFace"), new Vector3(-5f, 2.5f, 1), Quaternion.identity);
                    o++;
                }
            }
        }
    }

    public void generateAllyCharacter()
    {
        int o = 1;
        foreach (int selected in AllySelection)
        {

            if (selected == 0)
            {
                if (o == 1)
                {
                    PhotonNetwork.Instantiate(Path.Combine("Prefab", "warriorPrefabBack"), new Vector3(5.5f, 0.25f, 1), Quaternion.identity);
                    o++;
                }
                else if (o == 2)
                {
                    PhotonNetwork.Instantiate(Path.Combine("Prefab", "warriorPrefabBack"), new Vector3(6.5f, 0.75f, 1), Quaternion.identity);
                    o++;
                }
                else if (o == 3)
                {
                    PhotonNetwork.Instantiate(Path.Combine("Prefab", "warriorPrefabBack"), new Vector3(7.5f, 1.25f, 1), Quaternion.identity);
                    o++;
                }

            }
            else if (selected == 1)
            {
                if (o == 1)
                {
                    PhotonNetwork.Instantiate(Path.Combine("Prefab", "wizardPrefabBack"), new Vector3(5.5f, 0.25f, 1), Quaternion.identity);
                    o++;
                }
                else if (o == 2)
                {
                    PhotonNetwork.Instantiate(Path.Combine("Prefab", "wizardPrefabBack"), new Vector3(6.5f, 0.75f, 1), Quaternion.identity);
                    o++;
                }
                else if (o == 3)
                {
                    PhotonNetwork.Instantiate(Path.Combine("Prefab", "wizardPrefabBack"), new Vector3(7.5f, 1.25f, 1), Quaternion.identity);
                    o++;
                }
            }
        }
    }


    public List<int> AllySelection = new List<int>();
    public List<int> EnnemySelection = new List<int>();
    public void selectCharacter(int id)
    {
        AllySelection.Add(id);
        EnnemySelection.Add(id);
    }

    public void loadScene()
    {
        SceneManager.LoadScene("Game");
    }
}

