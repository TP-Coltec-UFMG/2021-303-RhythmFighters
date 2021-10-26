# 2021-303-RhythmFighters 
## Grupo: Gabriel Henrique, João Victor, Iago Diniz.
## Estrutura do Menu

  O menu de Rhythm Fighters conta com 2 telas interativas. A primeira, o menu principal, contém uma secção nomeada "jogar" com opções organizadas horizontalmente para jogar casualmente, competitivamente, ou para treinamento. A primeira e a última contendo duas outras opções cada (Jogar offline e jogar com amigos na categoria "casual", Campo de treinamento e guias na categoria "Treinamento"). A missão é que um jogador consiga perceber as três opções como parte de uma mesma categoria e que a divisão entre jogo casual e competitivo agilize a escolha de um jogador dependendo de seu objetivo.
  
  ![PlayButton](https://user-images.githubusercontent.com/43860020/135894758-1bc6c99b-1091-4981-8b40-8408226a4356.gif) *Faixa "jogar"*
  
  Ainda no menu principal, abaixo da faixa "jogar", há 3 opções, a primeira opção, "configurações" abre a segunda tela interativa, a segunda opção "créditos" (futuramente) direcionará para outra tela com o nome dos desenvolvedores e outras menções especiais, e a última opção "sair do jogo", fecha o jogo.
  
  ![MainMenu](https://user-images.githubusercontent.com/43860020/135894432-1c564a3d-186b-4fdf-8991-0e2f33b5b5b0.jpg) *Menu principal*
  
  A segunda tela implementada é o menu de configurações, com múltiplas opções de personalização separadas em diferentes categorias.
  1. Gráficos
   - Qualidade: Modifica a qualidade gráfica do jogo
   - Limite de framerate: Força o jogo a rodar em uma taxa de quadros específica (ou ilimitado para não limitar)
   - Anti-aliasing: Modifica o anti-aliasing do jogo (0x, 2x, 4x)
   - Tela cheia
   - Tremor de tela: Modifica a intensidade do tremor na tela que aconteceria quando um personagem recebe dano ou realiza certas ações (Sem tremor, Reduzido, Completo)
   - Modo contraste: Ativa ou desativa o modo contraste (filtro que destaca os jogadores e o cenário)
   - Tamanho do metrônomo
  2. Áudio
   - Sincronizar áudio: Abre uma nova tela onde você pode reconfigurar a sincronização do áudio com o metrônomo manualmente ou automaticamente.
   - Volume mestre: Volume de todos os elementos do jogo
   - Volume da música
   - Volume das vozes: Volume das linhas faladas dos personagens
   - Volume do SFX: Volume dos efeitos sonoros de ataques
   - Volume do metrônomo
   - Volume do HUD: Volume de elementos do HUD que não são o metrônomo
   - Audio descrição
  3. Gameplay
   - Controles: Abre uma nova tela para o jogador se informar sobre os inputs de controle diferentes
  4. Acessibilidade
   - Modo contraste
   - Tamanho do metrônomo
   - Volume do metrônomo
   - Volume do HUD
   - Audio descrição
  5. Conta
   - *Nenhuma opção no escopo atual do jogo.*

  Algumas opções são visíveis em múltiplas categorias, mais especificamente todas as opções de acessibilidade também existem distribuídas nas categorias de áudio e gráficos, estas opções têm ou podem ter funcionalidades para jogadores sem problemas visuais ou auditivos, portanto as opções se encontram em ambas por convêniencia.

  Pelo volume de opções e devido a inexistência de algumas da funcionalidades referenciadas em algumas das opções, estas ainda não estão em funcionalidade (no momento em que este README está sendo escrito)
  
  ![SettingsMenu](https://user-images.githubusercontent.com/43860020/135895445-cd0aebe9-8748-4467-a6ff-e131b889b007.jpg) *Secção "Gráficos" no menu de configurações*

## Acessibilidade

  Algumas funções de acessibilidade já implementadas incluem efeitos sonoros associados ao clique do botão, com um áudio específico ao abrir o menu de configurações e a secção de acessibilidade.

### Atualizações futuras
  - [ ] Funcionalidade dos botões e sliders
  - [ ] Reavaliação das opções disponíveis e da organização das mesmas
  - [ ] Implementar audio descrição mais precisa e funcional
  - [ ] Implementar a tela de créditos
  - [ ] Tooltip descritiva de opções
  - [ ] Tooltip de input no menu (qual botão apertar para confirmar, voltar etc.)
  - [ ] Navegação de botões personalizada
  - [ ] Atualizar gráficos e SFX do menu para encaixar com o estilo artístico
