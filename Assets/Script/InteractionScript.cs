using UnityEngine;

public class InteractionScript : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        // E�er E tu�una bas�ld�ysa ve di�er obje NPC etiketine sahipse
        if (Input.GetKeyDown(KeyCode.E) && other.gameObject.CompareTag("NPC"))
        {
            // Ebeveyn objeyi bul
            Transform parent = other.transform.parent;
           
            other.gameObject.SetActive(false);

            // Ebeveyn objedeki t�m �ocuklar� dola�
            foreach (Transform child in parent)
            {
                // E�er �ocuk obje NPC etiketine sahip de�ilse
                if (!child.CompareTag("NPC"))
                {

                    child.gameObject.SetActive(true);
                    
                    Destroy(gameObject);
                    break; // �lk bulunan� aktif hale getirdikten sonra d�ng�den ��k
                }
            }
        }
    }
}

