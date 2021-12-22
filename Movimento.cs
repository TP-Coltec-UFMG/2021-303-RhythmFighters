using UnityEngine;
using System.Collections;

public class Movimento : MonoBehaviour {
   public float speedMove = 5f; // VELOCIDADE MOVIMENTO
   public float jumpForce = 350f; // FORÇA DO PULO
   public LayerMask groundLayers; // LAYERS CONSIDERADA CHAO
   public Transform groundCheck; // OBJETO PRA DETECTAR SE TA NO CHAO, "PÉ"
   public float groundRadius = 0.1f; // RAIO PARA DIZER SE O PLAYER ESTA NO CHÃO
   private bool isOnGround = true; // ESTA NO CHÃO?
   private Rigidbody2D rb; // RIGIDBODY 2D DO PLAYER
   private bool isLookRight = true; // ESTA OLHANDO PRA DIREITA?

   // PEGAR REFERENCIAS NA INICIALIZACAO
   void Awake(){
      // LINKA AUTOMATICAMENTE O RIGIDBODY2D DO PLAYER
      // SE NÃO TIVER DA ERRO
      rb = GetComponent<Rigidbody2D>();
   }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D");
          isOnGround = true;
    }
   // MÉTODO FISICO UTILIZADO PRA MOVIMENTOS, POIS É CONSTANTE
   void FixedUpdate(){
      // SETA PRA FALSE PRA PODER VERIFICAR DEPOIS



      // SE ESTA NO CHAO
      if(isOnGround){
         // VERIFICA SE O PLAYER ESTA APERTANDO ESQUERDA OU DIREITA
         // PARA PODER RETORNA 1 PRA DIREITA E -1 PRA ESQUERDA
         // PRA PODER MOVER PRA AMBOS OS LADOS
         float direction = Input.GetAxisRaw("Horizontal");
         // SETA VELOCIDADE DO RGIDBODY2D PRA MOVER COM BASE NA VELOCIDADE speedMove
         // E NA DIREÇÃO DESEJADA
         // MANTEM O VALOR DE Y PARA NÃO ALTERAR A ALTURA
         rb.velocity = new Vector2(direction*speedMove,rb.velocity.y);

         // SE ELE ESTIVER OLHANDO PRA ESQUERDA E A DIREÇÃO FOR PRA DIREITA
         if(direction>0 && !isLookRight){
            // INVERTE SUA DIREÇÃO PRA OLHAR PRA DIREÇÃO CERTA
            // EXECUTA O MÉTODO Turn
            Turn();
         }
         // SE ELE ESTIVER OLHANDO PRA DIREITA E A DIREÇÃO FOR PRA ESQUERDA
         else if(direction<0 && isLookRight)
         {
            // INVERTE SUA DIREÇÃO PRA OLHAR PRA DIREÇÃO CERTA
            // EXECUTA O MÉTODO Turn
            Turn();
         }
      }
   }

   // MÉTODO PRA VIRAR O PLAYER PARA O LADO CERTO DAS TECLAS
   void Turn(){
      // INVERTER A DIREÇÃO, ESQUERDA --> DIREITA E VICE VERSA
      // NO CASO VAI INVERTER DE TRUE --> FALSE E VICE VERSA
      isLookRight = !isLookRight;
      // PEGAR A ESCALA DO PLAYER
      Vector3 scale = transform.localScale;
      // MULTIPLICA O VALOR DE X PARA INVERTER ESQUERDA --> DIREITA ...
      scale.x *= -1; 
      // SETA O VALOR DA ESCALA PARA O VALOR MODIFICADO
      transform.localScale = scale;

   }

   // MÉTODO UPDATE É MELHOR PRA VERIFICAR TECLAS
   void Update(){
      // SE APERTA PRA PULAR, E ESTA NO CHÃO
      if(Input.GetButtonDown("Jump") && isOnGround){
         // NÃO ESTA MAIS NO CHAO
         isOnGround = false;
         // ADICIONA FORÇA PRA CIMA COM BASE NA VARIAVEL jumpForce
         rb.AddForce(Vector2.up*jumpForce);

      }
   }

}