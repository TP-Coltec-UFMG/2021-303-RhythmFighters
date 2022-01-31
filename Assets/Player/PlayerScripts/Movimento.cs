using UnityEngine;
using System.Collections;

public class Movimento : MonoBehaviour {
   public float moveSpeed = 5f; // VELOCIDADE MOVIMENTO
   public float jumpForceHorizontal = 120f; // FORÇA DO PULO
   public float jumpForceVertical = 300f; // FORÇA DO PULO
   [SerializeField]
   private LayerMask groundLayerMask;
   public bool canMove = true;
   private Rigidbody2D rb; // RIGIDBODY 2D DO PLAYER
   public float lookDirection = 1;

   private Info info;

   public Transform cameraPos;

   // PEGAR REFERENCIAS NA INICIALIZACAO
   void Awake(){
      info = gameObject.GetComponent<Info>();
      // LINKA AUTOMATICAMENTE O RIGIDBODY2D DO PLAYER
      // SE NÃO TIVER DA ERRO
      rb = GetComponent<Rigidbody2D>();
   }

    void OnCollisionEnter2D(Collision2D col)
    {
       if (col.collider == GameObject.Find("Ground").GetComponent<BoxCollider2D>()){
         this.canMove = true;
       }
    }
   // MÉTODO FISICO UTILIZADO PRA MOVIMENTOS, POIS É CONSTANTE
   void FixedUpdate(){
      // SETA PRA FALSE PRA PODER VERIFICAR DEPOIS
      // SE ESTA NO CHAO

      if(IsGrounded() && this.canMove == true){
         // VERIFICA SE O PLAYER ESTA APERTANDO ESQUERDA OU DIREITA
         // PARA PODER RETORNA 1 PRA DIREITA E -1 PRA ESQUERDA
         // PRA PODER MOVER PRA AMBOS OS LADOS
         float xInput = Input.GetAxisRaw("Horizontal" + this.info.playerID);
         // SETA VELOCIDADE DO RGIDBODY2D PRA MOVER COM BASE NA VELOCIDADE moveSpeed
         // E NA DIREÇÃO DESEJADA
         // MANTEM O VALOR DE Y PARA NÃO ALTERAR A ALTURA
         rb.velocity = new Vector2(xInput*moveSpeed,rb.velocity.y);

         this.info.animator.SetFloat("SpeedX", rb.velocity.x * lookDirection);
      }
   }

   // MÉTODO UPDATE É MELHOR PRA VERIFICAR TECLAS
   void Update(){
      // SE APERTA PRA PULAR, E ESTA NO CHÃO
      float xInput = Input.GetAxisRaw("Horizontal" + this.info.playerID);
      if(Input.GetButton("Jump" + this.info.playerID) && IsGrounded() && this.canMove == true && info.playerHealth >= 0){
         rb.velocity = new Vector2(0,0);
         // ADICIONA FORÇA PRA CIMA COM BASE NA VARIAVEL jumpForce
         if (xInput == 0){
            rb.AddForce(Vector2.up*jumpForceVertical,ForceMode2D.Impulse);
         }
         else{
            rb.AddForce(new Vector2(Mathf.Sign(xInput),0)*jumpForceHorizontal+Vector2.up*jumpForceVertical,ForceMode2D.Impulse);
         }
      }

      //definir direcao do jogador
      if(IsGrounded()){
         this.lookDirection = Mathf.Sign(cameraPos.position.x - this.transform.position.x);

         if(info.playerHealth <= 0 && IsGrounded()){
            this.canMove = false;
            this.info.animator.SetBool("Defeated", true);
         }
      }

      this.info.animator.SetFloat("SpeedY", rb.velocity.y);
      this.info.animator.SetBool("Grounded", IsGrounded());
      transform.localScale = new Vector3(this.lookDirection, 1, 1);
   }

   public bool IsGrounded() {
      float extraHeightTest = .02f;
      RaycastHit2D raycastHit = Physics2D.Raycast(transform.GetComponent<BoxCollider2D>().bounds.center, Vector2.down, transform.GetComponent<BoxCollider2D>().bounds.extents.y + extraHeightTest, groundLayerMask);
      Debug.DrawRay(transform.GetComponent<BoxCollider2D>().bounds.center, Vector2.down * (transform.GetComponent<BoxCollider2D>().bounds.extents.y + extraHeightTest),Color.green);
      return raycastHit.collider != null;
   }

   public void Impulse(Vector2 direction, float strength){
      Debug.Log(direction);
      rb.velocity = new Vector2(0,0);
      this.canMove = false;
      rb.AddForce(direction.normalized*strength, ForceMode2D.Impulse);
   }
}