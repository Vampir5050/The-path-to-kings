using UnityEngine;

public class InstantiateDialog : MonoBehaviour
{
    [SerializeField] TextAsset text;
    [SerializeField] Dialogue dialogue;
    [SerializeField] int currentNode;
    [SerializeField] GameObject e;
    [SerializeField] GUISkin skin;
    bool ShowDialog;
    

    private void Start()
    {
        dialogue = Dialogue.Load(text);
        skin = Resources.Load("Skin") as GUISkin;
       
    }

    private void OnTriggerStay(Collider other)
    {
        e.SetActive(true);
        if (Input.GetKeyDown(KeyCode.E))
        {
            ShowDialog = true;
            e.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        e.SetActive(false);
    }

    private void OnGUI()
    {
        GUI.skin = skin;
        if (ShowDialog)
        {
            Cursor.visible = true;
            GUI.Box(new Rect(Screen.width / 2 - 300, Screen.height - 300, 600, 250), "");
            GUI.Label(new Rect(Screen.width / 2 - 250, Screen.height - 280, 500, 90), dialogue.nodes[currentNode].npcText);
            for (int i = 0; i < dialogue.nodes[currentNode].answers.Length; i++)
            {
                if (GUI.Button(new Rect(Screen.width / 2 - 250, Screen.height - 200 + 25 * i, 500, 25), dialogue.nodes[currentNode].answers[i].text))
                {
                    if (dialogue.nodes[currentNode].answers[i].end == "true")
                    {
                        ShowDialog = false;
                        Cursor.visible = false;
                    }
                    currentNode = dialogue.nodes[currentNode].answers[i].nextNode;
                }
            }
        }
       
    }
}
