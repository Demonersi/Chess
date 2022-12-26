using System.Drawing;
namespace Chess
{
    public partial class Form1 : Form
    {
        bool[,] board = new bool[8, 8] {
            { true, false, true, false, true, false, true, false },
            { false, true, false, true, false, true, false, true},
            { true, false, true, false, true, false, true, false },
            { false, true, false, true, false, true, false, true },
            { true, false, true, false, true, false, true, false },
            { false, true, false, true, false, true, false, true },
            { true, false, true, false, true, false, true, false },
            { false, true, false, true, false, true, false, true }
        };
        int cell_size;
        enum Types_Figures {King, Queen, Rook, Bishop, Knight, Pawn, Void };
        Board[,] board_figures = new Board[8, 8] {
            { new Board(Types_Figures.Rook,false), new Board(Types_Figures.Knight,false), new Board(Types_Figures.Bishop,false), new Board(Types_Figures.Queen,false), new Board(Types_Figures.King,false), new Board(Types_Figures.Bishop,false), new Board(Types_Figures.Knight,false), new Board(Types_Figures.Rook,false)},
            { new Board(Types_Figures.Pawn,false),new Board(Types_Figures.Pawn,false),new Board(Types_Figures.Pawn,false),new Board(Types_Figures.Pawn,false),new Board(Types_Figures.Pawn,false),new Board(Types_Figures.Pawn,false),new Board(Types_Figures.Pawn,false),new Board(Types_Figures.Pawn,false)},
            { new Board(),new Board(),new Board(),new Board(),new Board(),new Board(),new Board(),new Board()},
            { new Board(),new Board(),new Board(),new Board(),new Board(),new Board(),new Board(),new Board()},
            { new Board(),new Board(),new Board(),new Board(),new Board(),new Board(),new Board(),new Board()},
            { new Board(),new Board(),new Board(),new Board(),new Board(),new Board (),new Board(),new Board()},
            { new Board(Types_Figures.Pawn,true), new Board(Types_Figures.Pawn,true), new Board(Types_Figures.Pawn,true), new Board(Types_Figures.Pawn,true), new Board(Types_Figures.Pawn,true), new Board(Types_Figures.Pawn,true), new Board(Types_Figures.Pawn,true), new Board(Types_Figures.Pawn,true)},
            { new Board(Types_Figures.Rook,true), new Board(Types_Figures.Knight,true), new Board(Types_Figures.Bishop,true), new Board(Types_Figures.Queen,true), new Board(Types_Figures.King,true), new Board(Types_Figures.Bishop,true), new Board(Types_Figures.Knight,true), new Board(Types_Figures.Rook,true)}
        };
        class Board
        {
            public Types_Figures types;
            public bool white;
            public Board(Types_Figures types, bool white)
            {
                this.types = types;
                this.white = white;
            }
            public Board() { this.types = Types_Figures.Void; }
        }
        public Form1()
        {
            InitializeComponent();
            cell_size = this.ClientSize.Height / 8;
            this.Paint += OnPaint;
        }

        private void OnPaint(object? sender, PaintEventArgs e)
        {
            
            paint_background();
            paint_all();

        }
        private void paint_background()
        {
            Graphics g = this.CreateGraphics();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Rectangle rect = new Rectangle(i * cell_size, j * cell_size, cell_size, cell_size);

                    SolidBrush brush;
                    if (board[i, j] == true)
                        brush = new SolidBrush(Color.Wheat);
                    else
                        brush = new SolidBrush(Color.SaddleBrown);
                    g.FillRectangle(brush, rect);
                }
            }
            g.Dispose();
        }
        private void paint_all()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    paint_figure(i, j);
                }
            }
        }
        private void paint_figure(int i, int j)
        {
            if (board_figures[i, j].types == Types_Figures.Void)
                return;
            else
            {
                Graphics g = this.CreateGraphics();
                Bitmap bitmap = new Bitmap(get_path(i, j));
                g.DrawImage(bitmap, i * cell_size, j * cell_size);
                g.Dispose();
            }
        }
        private string get_path(int i, int j)
        {
            string path;
            if (board_figures[i, j].white == true) path = "L";
            else path = "B";
            path += board_figures[i, j].types.ToString();
            path += ".bmp";
            return path;
        }
    }
}