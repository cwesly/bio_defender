# Bio Defender 🦠

**Bio Defender** é um jogo educativo e de ação desenvolvido na Unity, focado na defesa do organismo humano contra invasões patogênicas. O jogador assume o controle de um **Macrófago** e deve utilizar **Anticorpos** para destruir vírus, enquanto coleta **Antígenos** para fortalecer o sistema imunológico e recuperar a saúde do organismo.

## 🚀 Funcionalidades do Protótipo (MVP)

- **Movimentação Polida:** Controle do jogador nos eixos horizontal e vertical com sistema de travamento (clamping) para impedir a saída da área visível.
- **Sistema de Combate:** Disparo de anticorpos que eliminam patógenos e somam pontuação em tempo real.
- **Geração Dinâmica (Spawner):** Sistema que alterna a criação de inimigos (Vírus) e itens de suporte (Antígenos) em posições aleatórias no topo da tela.
- **Gestão de Saúde e Cura:** Barra de vida dinâmica (UI) que diminui ao sofrer ataques e aumenta ao coletar antígenos.
- **Sistema de Pontuação:** Contador de score integrado à interface (HUD), recompensando o jogador por abates e coletas.
- **Ciclo de Jogo (Game Loop):** Tela de Game Over funcional que permite reiniciar a partida instantaneamente.

## 🛠️ Tecnologias Utilizadas

- **Engine:** Unity 2022.3+
- **Linguagem:** C#
- **Input System:** Unity New Input System (Package)
- **Interface:** TextMeshPro & Unity UI System
- **Versionamento:** Git & GitHub

## 🎮 Como Jogar

1. Clone o repositório em sua máquina local.
2. Abra o projeto através do Unity Hub.
3. Certifique-se de que a cena `Gameplay` está no topo do *Build Settings*.
4. Pressione **Play** para iniciar:
   - **WASD / Teclas de Seta:** Mover o Macrófago.
   - **Barra de Espaço:** Disparar Anticorpos.

---
*Projeto desenvolvido como parte de estudos acadêmicos em Análise e Desenvolvimento de Sistemas (IFPI) na disciplina de Desenvolvimento de Jogos e Realidade Virtual.*