using UnityEngine;
using System.Collections;

public class Movimento : MonoBehaviour {
   public float moveSpeed = 5f; // VELOCIDADE MOVIMENTO
   public float jumpForceHorizontal = 120f; // FORÇA DO PULO
   public float jumpForceVertical = 300f; // FORÇA DO PULO
   public LayerMask groundLayers; // LAYERS CONSIDERADA CHAO
   public Transform groundCheck; // OBJETO PRA DETECTAR SE TA NO CHAO, "PÉ"
   public float groundRadius = 0.1f; // RAIO PARA DIZER SE O PLAYER ESTA NO CHÃO
   private bool isOnGround = true; // ESTA NO CHÃO?
   private Rigidbody2D rb; // RIGIDBODY 2D DO PLAYER
   private float lookDirection = 1;

   private Animator animator;

   private int playerID;

   // PEGAR REFERENCIAS NA INICIALIZACAO
   void Awake(){
      animator = gameObject.GetComponent<Info>().animator;
      playerID = gameObject.GetComponent<Info>().playerID;
      // LINKA AUTOMATICAMENTE O RIGIDBODY2D DO PLAYER
      // SE NÃO TIVER DA ERRO
      rb = GetComponent<Rigidbody2D>();
   }

    void OnCollisionEnter2D(Collision2D col)
    {
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
         float xInput = Input.GetAxisRaw("Horizontal" + this.playerID);
         // SETA VELOCIDADE DO RGIDBODY2D PRA MOVER COM BASE NA VELOCIDADE moveSpeed
         // E NA DIREÇÃO DESEJADA
         // MANTEM O VALOR DE Y PARA NÃO ALTERAR A ALTURA
         rb.velocity = new Vector2(xInput*moveSpeed,rb.velocity.y);
         if (xInput != 0) {
            this.lookDirection = Mathf.Sign(xInput);
            transform.localScale = new Vector3(this.lookDirection, 1, 1);
         }

         animator.SetFloat("Speed", rb.velocity.x * lookDirection);
      }
   }

   // MÉTODO UPDATE É MELHOR PRA VERIFICAR TECLAS
   void Update(){
      // SE APERTA PRA PULAR, E ESTA NO CHÃO
      float xInput = Input.GetAxisRaw("Horizontal" + this.playerID);
      if(Input.GetButton("Jump" + this.playerID) && isOnGround){
         rb.velocity = new Vector2(0,0);
         // NÃO ESTA MAIS NO CHAO
         isOnGround = false;
         // ADICIONA FORÇA PRA CIMA COM BASE NA VARIAVEL jumpForce
         if (xInput == 0){
            rb.AddForce(Vector2.up*jumpForceVertical,ForceMode2D.Impulse);
         }
         else{
            rb.AddForce(new Vector2(Mathf.Sign(xInput),0)*jumpForceHorizontal+Vector2.up*jumpForceVertical,ForceMode2D.Impulse);
         }

      }
   }

}