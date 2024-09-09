using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    /// <Justificação>
    /// No tutorial dizem para meter a câmara a seguir o jogador e colocar uma variável offset, na minha opinião, fica melhor ter um empty dentro do jogador que tem a 
    /// localização que pretendo para a câmara e meter apenas a posição igual a esse empty object. Acaba por ter o mesmo efeito mas com um código mais simples e melhor.
    /// </Justificação>
    
    [SerializeField] GameObject cameraSpot;

    [SerializeField] GameObject player;

    void LateUpdate()
    {
        this.transform.position = cameraSpot.transform.position;

        transform.LookAt(player.transform);
    }
}
