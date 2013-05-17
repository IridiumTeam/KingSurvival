#King Survival


Your task is to write an interactive **console-based implementation of the game "King Survival"** in which **the king (K) tries
to escape the four pawns (A, B, C, D)**. The game is played on a **standard chessboard of size 8 x 8 squares**.

![King Survival](https://raw.github.com/IridiumTeam/KingSurvival/master/Documents/KingSurvivalInitialPositions.png)

The king is initially located at **row 7 and column 3** and the pawns are located at **row 0 and columns 0, 2, 4 and 6**. 
A pawn can only move to a neighbor square **down-left** or **down-right**, while the king can go to neighbor squares in 4 
directions: **down-left**, **down-right**, **up-left** and **up-right**. The pawns and the king cannot step outside of the chessboard 
or on a square that is already occupied. The game starts by moving the king. At **odd** turns the player **moves the 
king**, at **even** - **the pawns**. The player in fact plays against himself. In order to make a move the player issues a command 
which contains the name of the figure, i.e. **K**, followed by the direction to move in, e.g. **KUL** means **King-Up-Left**, 
while **ADL** means **Pawn-A-Down-Left**. Thus all possible commands are 12: **KUL**, **KUR**, **KDL**, **KDR**, 
**ADL**, **ADR**, **BDL**, **BDR**, **CDL**, **CDR**, **DDL** and **DDR**.

Write a program that **simulates the "King Survival" game** as shown in the sample game session. The game starts with the 
chesspieces at their initial positions (as shown in the picture) and it's the king's turn. After the king moves, it's 
pawns' turn and so on. Before each turn the board is visualized as shown below. If the king **reaches row 0, he wins**. 
If the **pawns "catch" the king** so that he has no valid moves, **he loses**. If the **pawns have no valid moves, the king wins**. 
The game ends when the king wins or loses. If the king wins, print **King wins** and the number of moves the king has made. 
If the king loses, print **King loses**. Some players might try to cheat by entering invalid moves, so be cautious. 
In case of an invalid command, print **Invalid move** and let the user enter another command.

##Sample Game Session
The empty white squares are shown as "+", the empty black squares are shown as "-".

![King Survival](https://raw.github.com/IridiumTeam/KingSurvival/master/Documents/SampleGame.png)
