using System;
using System.Windows.Forms;

namespace GameUi
{

    public partial class Form1 : Form
    {
        private int n = 0, players = 3, random_number;
        private int[] random_numbers = new int[201];
        private Player Start = new Player(0), Current;
        private bool gameOver = false;

        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < random_numbers.Length; i++)
                 random_numbers[i] = 0;
            Random_N_Generator();
            add_Player();
            Current = Start.Next;
            show(Current.getint_board());
            Highlight_Blocks();
        }
        
        public bool add_Player()
        {
            Player p = new Player(n);
            if (p == null)
                return false;

            Random_Cart_Generator(p);

            Player t = Start.Next, s = Start;
            while (t != null)
            {
                s = t;
                t = t.Next;
            }

            p.Next = t;
            s.Next = p;
            n++;
            return true;
        }

        public void Random_Cart_Generator(Player p)
        {
            bool[,] bool_board = new bool[6, 8];
            int[,] int_board = new int[6, 8];
            Random rnd = new Random();

            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 8; j++)
                {
                    int_board[i, j] = 0;
                    bool_board[i, j] = true;
                }

            for (int i = 0; i < 20; i++)
            {
                int x, y;
                do
                {
                    y = rnd.Next(0, 8);
                    x = rnd.Next(0, 6);
                } while (bool_board[x, y] == false);

                int_board[x, y] = rnd.Next(1, 200);
                bool_board[x, y] = false;
            }
            
            p.SetBool_board(bool_board);
            p.SetInt_board(int_board);
        }

        public void Random_N_Generator()
        {
            Random rnd = new Random();
            do
            {
                random_number = rnd.Next(1, 200);
            } while (eq());

            int i;
            for (i = 0; i < random_numbers.Length && random_numbers[i] != 0; i++) ;
            random_numbers[i] = random_number;

            RandomNumber.Text = "Random Number: " + random_number;
        }

        private bool eq()
        {
            int i;
            for (i = 0; i < random_numbers.Length; i++)
                if (random_number == random_numbers[i])
                    return true;
            
            return false;
        }

        private void Next_turn_Click(object sender, EventArgs e)
        {
            if (gameOver)
                Application.Exit();

            if (check_play())
            {
                if (n < players)
                    add_Player();

                if (Current.Next == null)
                {
                    Current = Start.Next;
                    turn.Text = "Turn: Your trun";
                    Random_N_Generator();
                }
                else
                {
                    Current = Current.Next;
                    turn.Text = "Turn: Player CPU" + Current.getName() + " turn";
                    CPU_play();
                }
                Highlight_Blocks();
                show(Current.getint_board());
            }
            else
                status.Text = "Status: you have the number ! find and select that";

            if (check_winner())
            {
                status.Text = turn.Text = ((Current.getName() == Start.getName()) ? "You " : "Player CPU" + Current.getName()) + " win";
                gameOver = true;
                next_turn.Text = "Exit";
            }
        }

        private void CPU_play()
        {
            int[,] int_board = Current.getint_board();
            bool[,] bool_board = Current.getbool_board();
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 8; j++)
                    if (int_board[i, j] == random_number) 
                        bool_board[i, j] = true;
        }

        private bool check_play()
        {
            if(Current.getName() != Start.Next.getName())
                return true;
            int[,] int_board = Current.getint_board();
            bool[,] bool_board = Current.getbool_board();
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 8; j++)
                    if (int_board[i, j] == random_number && bool_board[i, j] == false)
                        return false;
            return true;
        }

        public void show(int[,] show)
        {
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 8; j++)
                    buttons[i, j].Text = (show[i, j] == 0) ? "" : show[i, j] + "";
        }

        public bool check_winner()
        {
            int[,] int_board = Current.getint_board();
            bool[,] bool_board = Current.getbool_board();
            int Counter = 0;
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 8; j++)
                    if (bool_board[i, j] == true)
                        Counter++;
            if (Counter == 48)
                return true;
            return false;
        }

        public void Highlight_Blocks()
        {
            int[,] int_board = Current.getint_board();
            bool[,] bool_board = Current.getbool_board();

            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 8; j++)
                    buttons[i, j].BackColor = (bool_board[i, j]) ? System.Drawing.Color.LightGreen : System.Drawing.Color.LightGray;
        }

        private void buttons_Click(object sender, EventArgs e)
        {
            status.Text = "Status: Play";
            int[,] int_board = Current.getint_board();
            if (Current.getName() == Start.Next.getName())
            {
                for (int i = 0; i < 6; i++)
                    for (int j = 0; j < 8; j++)
                        if (buttons[i, j].Capture)
                            if (int_board[i, j] == random_number)
                            {
                                buttons[i, j].BackColor = System.Drawing.Color.LightGreen;
                                Current.getbool_board()[i, j] = true;
                            }
                            else
                                status.Text = "Wrong!";
            }else status.Text = "Status: Not your turn!";
        }
    }

    public class Player
    {
        public Player Next;
        private int name;
        private bool[,] board_bool;
        private int[,] board_int;
        internal Player(int Name)
        {
            board_bool = new bool[6, 8];
            board_int = new int[6, 8];
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 8; j++)
                {
                    board_int[i, j] = 0;
                    board_bool[i, j] = true;
                }
            name = Name;
        }
        internal int getName()
        {
            return name;
        }

        internal int[,] getint_board()
        {
            return board_int;
        }

        internal bool[,] getbool_board()
        {
            return board_bool;
        }
        internal void SetBool_board(bool[,] value)
        {
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 8; j++)
                    board_bool[i, j] = value[i, j];
        }
        internal void SetInt_board(int[,] value)
        {
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 8; j++)
                    board_int[i, j] = value[i, j];
        }

    }

}


