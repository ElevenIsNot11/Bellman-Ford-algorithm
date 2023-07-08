using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace BellmanFord
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string minLengthIndex;

        public int temp;  //Временная переменная
        public int timer; //Переменная, позволяющая обнаружить случайное зацикливание
        public string startdot; //Стартовая точка
        private void button1_Click(object sender, EventArgs e)
        {
            #region Задание стартовых переменных

            if (DotsLB.Items.Count == 0 || DirectionsLB.Items.Count == 0)
            {
                return;
            }
            if (checkBox1.Checked)
            {
                startdot = Dot3CB.Text;
                if (startdot == "")
                {
                    startdot = DotsLB.Items[0].ToString();
                }
            }
            else
            {
                if (DotsLB.Items.Contains("A"))
                {
                    startdot = "A";
                }
                else
                {
                    startdot = DotsLB.Items[0].ToString();
                }
            }
            temp = -100;
            timer = 0;
            int DotsAmount = DotsLB.Items.Count;
            string[,] Dots = new string[3, DotsAmount];
            bool[] DotsConstant = new bool[DotsAmount];
            bool[] DotsChanged = new bool[DotsAmount];

            listBox1.Items.Clear();
            bool Answer = false;

            string[] Directions; // кол-во направлений
            if (checkBox1.Checked)
            {
                Directions = new string[DirectionsLB.Items.Count*2];
            }
            else
            {
               Directions = new string[DirectionsLB.Items.Count];
            }
            SetDirections(Directions);
            SetStart(Dots);
            DotsConstant[GetDot(Dots,startdot)] = true;
            string CurrentPoint = startdot;
            string TempLine;
            string MoveTo = "";
            int test;
            int MoveLength = 0;
            #endregion


            #region Поиск недоступных точек
            int DotsDirectionsCounter;
            bool stable = false;
            while (stable != true)
            {
                stable = true;
                for (int i = 0; i < DotsLB.Items.Count; i++)
                {
                    DotsDirectionsCounter = 0;
                    for (int j = 0; j < DirectionsLB.Items.Count; j++)
                    {

                            if (checkBox1.Checked)
                            {
                                if (DotsLB.Items[i].ToString() == Directions[j].Substring(0, 1) ||
                                    DotsLB.Items[i].ToString() == Directions[j].Substring(1, 1))
                                {
                                    DotsDirectionsCounter++;
                                }
                            }
                            else
                            {
                                if (DotsLB.Items[i].ToString() == Directions[j].Substring(1, 1))
                                {
                                    DotsDirectionsCounter++;
                                }
                            }
                        
                    }
                    if (DotsDirectionsCounter == 0 && Dots[0, i] != startdot && DotsConstant[i] == false)
                    {
                        stable = false;
                        DotsConstant[i] = true;
                        Dots[2, i] = startdot;
                        Dots[1, i] = Double.PositiveInfinity.ToString();
                        ClearDirections(Directions, Dots[0, i]);
                    }
                }
            }
#endregion

            while (Answer == false) // Пока все точки не станут постоянными Answer = false
            {

                #region Цикл 
                timer++;

                for (int i = 0; i < Directions.Length; i++)
                {
                    TempLine = Directions[i];
                    if (TempLine[0].ToString() == CurrentPoint)
                    {
                        MoveTo = TempLine[1].ToString(); // Буква A-E
                        DotsChanged[GetDot(Dots, MoveTo)] = true;
                        TempLine = TempLine.Substring(3); // Длина пути
                        if (int.TryParse(TempLine, out test)) // Проверка на число
                        {
                            MoveLength = int.Parse(TempLine) +  int.Parse(Dots[1,GetDot(Dots,CurrentPoint)]); // Координаты точки + длина пути
                        }
                        if (MoveLength < int.Parse(Dots[1, GetDot(Dots, MoveTo)]) || (Dots[2, GetDot(Dots, MoveTo)] == "0" && Dots[0, GetDot(Dots, MoveTo)] != startdot))
                        {
                            if (DotsConstant[GetDot(Dots, MoveTo)] == true)
                            {
                                DotsConstant[GetDot(Dots, MoveTo)] = false;
                            }

                            Dots[1, GetDot(Dots, MoveTo)] = MoveLength.ToString();
                            Dots[2, GetDot(Dots, MoveTo)] = CurrentPoint;
                        }


                    }
                }
                minLengthIndex = MinFind(MoveLength, CurrentPoint, MoveTo, DotsConstant, DotsChanged, Dots);
                CurrentPoint = Calculate(minLengthIndex, DotsConstant, DotsChanged, Dots, Directions, CurrentPoint);
                for (int k = 0; k < DotsConstant.Length; k++)
                {
                    if (DotsConstant[k] == false)
                    {
                        break;
                    }
                    else
                        if (DotsConstant[DotsConstant.Length - 1] == true && k == DotsConstant.Length - 1)
                        {
                            Answer = true;
                        }
                }
                #endregion

                #region Вывод точек
                for (int k = 0; k < DotsChanged.Length; k++)
                {
                    DotsChanged[k] = false;
                }
                minLengthIndex = null;
                temp = -100;
                print(Dots);
                #endregion

                #region Оптимизация
                /*
                 * Если программа обнаруживает, что все точки постоянные, то считается, что ответ найден.
                 * При этом она продолжает решение с текущей точки, чтобы попытаться уменьшить расстояние до одной из соседних точек
                 * Если в результате этого решения программе удалось уменьшить расстояние, то она снова продолжает решение пока все точки не станут постоянными
                */
                if (Answer == true)
                {
                    for (int i = 0; i < Directions.Length; i++)
                    {
                        TempLine = Directions[i];
                        if (TempLine[0].ToString() == CurrentPoint)
                        {
                            MoveTo = TempLine[1].ToString(); // Буква A-E
                            DotsChanged[GetDot(Dots, MoveTo)] = true;
                            TempLine = TempLine.Substring(3); // Длина пути
                            if (int.TryParse(TempLine, out test)) // Проверка на число
                            {
                                MoveLength = int.Parse(TempLine) + int.Parse(Dots[1, GetDot(Dots, CurrentPoint)]); // Координаты точки + длина пути
                            }
                            if (MoveLength < int.Parse(Dots[1, GetDot(Dots, MoveTo)]) || (Dots[2, GetDot(Dots, MoveTo)] == "0" && Dots[0, GetDot(Dots, MoveTo)] != startdot))
                            {
                                Answer = false;
                                if (DotsConstant[GetDot(Dots, MoveTo)] == true)
                                {
                                    DotsConstant[GetDot(Dots, MoveTo)] = false;
                                }

                                Dots[1, GetDot(Dots, MoveTo)] = MoveLength.ToString();
                                Dots[2, GetDot(Dots, MoveTo)] = CurrentPoint;
                            }

                        }
                    }
                }
                #endregion
            }
            PrintAnswer(DotsConstant,Dots);
        }

        #region Методы цикла
        private int GetDot(string[,] Dots, string DotName) //Получение индекса определенной точки по её названию
        {
            for (int i = 0; i < Dots.GetLength(1); i++)
            {
                if (Dots[0, i] == DotName)
                {
                    return i;
                }
            }

            return 1;
        }

        private void ClearDirections(string[] Directions, string DotName) //Метод для очистки направлений
        {
            for (int i = 0; i < Directions.Length; i++)
            {
                if (Directions[i][0].ToString() == DotName ||
                    Directions[i][1].ToString() == DotName)
                {
                    Directions[i] = "ТК=5";
                }
            }
        }

        private string MinFind(int MoveLength, string CurrentPoint, string MoveTo, bool[] DotsConstant, bool[] DotsChanged, string[,] Dots) //Метод для нахождения минимального числа
        {
            int index = 0;
            for (int i = 0; i < Dots.GetLength(1); i++)
            {
                if (DotsConstant[i] == false && DotsChanged[i] == true)
                {
                    if (temp == -100)
                    {
                        index = i;
                        temp = int.Parse(Dots[1, i]);
                    }
                    else
                    {
                        if (int.Parse(Dots[1, i]) < temp)
                        {
                            index = i;
                            temp = int.Parse(Dots[1, i]);
                        }

                    }
                }
            }
            if (index == GetDot(Dots,startdot))
            {
                index = GetDot(Dots,MoveTo);
            }
            return index.ToString();

        }


         private void SetDirections(string[] Directions) //Перевод направлений в массив
        {
            string line;
            if (checkBox1.Checked) //Неориентированный граф
            {
                for (int i = 0; i < DirectionsLB.Items.Count; i++)
                {
                    Directions[i] = DirectionsLB.Items[i].ToString();
                    line = "";
                    line += DirectionsLB.Items[i].ToString().Substring(1, 1) + DirectionsLB.Items[i].ToString().Substring(0, 1) + DirectionsLB.Items[i].ToString().Substring(2);
                    Directions[i+DirectionsLB.Items.Count] = line;
                }
            }
            else //Ориентированный граф
            {
                for (int i = 0; i < DirectionsLB.Items.Count; i++)
                {
                    Directions[i] = DirectionsLB.Items[i].ToString();
                }
            }

        }


        private void print(string [,] Dots) //Вывод всех точек
        {
            for (int i = 0; i < Dots.GetLength(1); i++)
            {
                listBox1.Items.Add(Dots[0, i] + "(" + Dots[1, i]+", "+ Dots[2, i]+")" + "\n");

            }
            listBox1.Items.Add("\n");
        }



        private void SetStart(string [,] Dots) //Добавление стартовых значений в массив точек
        {
            for (int i = 0; i < DotsLB.Items.Count; i++)
            {
                Dots[0, i] = DotsLB.Items[i].ToString();
                Dots[1, i] = "0";
                Dots[2, i] = "0";
            }
            
        }

        private string Calculate(string index, bool [] DotsConstant, bool [] DotsChanged, string [,] Dots, string [] Directions, string CurrentPoint) //Выбор следующей точки
        {
            int count = 0;
            for (int i = 0; i < Directions.Length; i++)
            {
                if (Directions[i].Substring(0,1) == CurrentPoint)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                return startdot;
            }

            if (timer > DotsConstant.Length * 3)
            {
                for (int i = 0; i < DotsConstant.Length; i++)
                {
                    DotsConstant[i] = true;
                }
                return startdot;
            }else
            if (timer > Dots.Length * 2)
            {
                Random rand = new Random();
                int random1 = rand.Next(0, DotsConstant.Length-1);
                return Dots[0, random1]; 
            }

            DotsConstant[int.Parse(index)] = true;
            if (Dots[0, int.Parse(index)] == Dots[2, int.Parse(index)])
            {
                Dots[2, int.Parse(index)] = "0";
            }

                return Dots[0, int.Parse(index)];
            
            
        }

        private void PrintAnswer(bool [] DotsConstant, string [,] Dots)
        {
            listBox1.Items.Add("\n");
            string line;
            string line2;
            string CurrentDot;

            for (int i = 0; i < DotsConstant.Length; i++) //Цикл проходит по каждой точке
            {
                if (Dots[0, i] != startdot)
                {
                    line = "";
                    CurrentDot = Dots[0, i];

                    while (CurrentDot != startdot) //В переменную line записывается путь
                    {
                        line += CurrentDot;
                        timer++;
                        CurrentDot = Dots[2, GetDot(Dots, CurrentDot)];
                        if (timer > 100) //Предотвращение случайного зацикливания
                        {
                            CurrentDot = startdot;

                        }
                    }
                    line += startdot;

                    line2 = "|";
                    for (int k = line.Length - 1; k >= 0; k--)  //Путь переворачивается
                    {
                        line2 += line[k];
                    }
                    line2 += "| = ";
                    line2 += Dots[1, i]; //К пути добавляется расстояние
                    listBox1.Items.Add(line2); // Вывод ответа для одной точки
                }
                
            }
        }
        #endregion

        #region Интерфейс программы
        private void Form1_Shown(object sender, EventArgs e)
        {
            CBUpdate();
        }

        private void CBUpdate()
        {
            Dot1CB.Items.Clear();
            Dot2CB.Items.Clear();
            Dot3CB.Items.Clear();
            for (int i = 0; i < DotsLB.Items.Count; i++)
            {
                Dot1CB.Items.Add(DotsLB.Items[i]);
                Dot2CB.Items.Add(DotsLB.Items[i]);
                Dot3CB.Items.Add(DotsLB.Items[i]);
            }
        }

        private void ClearDirections(string Dot)
        {
            int Checker;
            bool TryFor = true;
            while (TryFor == true)
            {
                Checker = DirectionsLB.Items.Count;
                for (int i = 0; i < DirectionsLB.Items.Count; i++)
                {
                    if (DirectionsLB.Items[i].ToString().Substring(0, 1) == Dot || DirectionsLB.Items[i].ToString().Substring(1, 1) == Dot)
                    {
                        DirectionsLB.Items.Remove(DirectionsLB.Items[i]);
                    }
                }
                TryFor = false;
                if (Checker > DirectionsLB.Items.Count)
                {
                    TryFor = true;
                }

                
            }
        }

        private void DotsLB_DoubleClick(object sender, EventArgs e)
        {
            string temp = "0";
            if (DotsLB.SelectedIndex != -1)
            {
                temp = DotsLB.Items[DotsLB.SelectedIndex].ToString();
                DotsLB.Items.RemoveAt(DotsLB.SelectedIndex);
            }

            CBUpdate();
            ClearDirections(temp);
            pictureBox1.Refresh();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int test;
            string line = "";
            string temp, temp2;

            for (int i = 0; i < DirectionsLB.Items.Count; i++)
            {
                temp = DirectionsLB.Items[i].ToString().Substring(0,1);
                temp2 = DirectionsLB.Items[i].ToString().Substring(1,1);
                if (checkBox1.Checked)
                {
                    if ((Dot1CB.SelectedItem.ToString() == temp && Dot2CB.SelectedItem.ToString() == temp2) ||
                        (Dot2CB.SelectedItem.ToString() == temp && Dot1CB.SelectedItem.ToString() == temp2))
                    {
                        line = "-1";
                        DirectionsLB.SelectedIndex = i;
                    }
                }
                else
                {
                    if ((Dot1CB.SelectedItem.ToString() == temp && Dot2CB.SelectedItem.ToString() == temp2))
                    {
                        line = "-1";
                        DirectionsLB.SelectedIndex = i;
                    }
                }
            }

            if (line != "-1")
            {
                if (Dot1CB.SelectedItem != null & Dot2CB.SelectedItem != null)
                {
                    if (Dot1CB.SelectedItem != Dot2CB.SelectedItem)
                    {
                        line += Dot1CB.SelectedItem.ToString() + Dot2CB.SelectedItem.ToString() + "=";
                        if (int.TryParse(DirectionLengthTB.Text, out test))
                        {
                            line += DirectionLengthTB.Text;
                        }
                        else
                        {
                            MessageBox.Show("Введенное направление невозможно преобразовать в число");
                            return;
                        }

                        DirectionsLB.Items.Add(line);
                        pictureBox1.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Выбраны одинаковые точки");
                    }
                }
                else
                {
                    MessageBox.Show("Вы не выбрали точки");
                }
            }
            else
            {
                MessageBox.Show("Направление уже существует");
            }

        }

        private void DirectionsLB_DoubleClick(object sender, EventArgs e)
        {
            if (DirectionsLB.SelectedIndex != -1)
            {
                DirectionsLB.Items.RemoveAt(DirectionsLB.SelectedIndex);
            }
            pictureBox1.Refresh();
        }

        private void DotNameTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            char Char1 = e.KeyChar;
            if ((Char1 >= 'A' && Char1 <= 'Z') || (Char1 >= 'a' && Char1 <= 'z') || Char1 == (char)Keys.Back)
            {

            }
            else
            {
                e.Handled = true;
            }
        }

        private void DotAdd_Click(object sender, EventArgs e)
        {
            string x = DotNameTB.Text;
            if (x.Length == 1)
            {
            for (int i = 0; i < DotsLB.Items.Count; i++)
            {
                if (DotsLB.Items[i].ToString() == x)
                {
                    x = "-1";
                }
            }
            if (x != "-1")
            {
                DotsLB.Items.Add(x);
            }
            else
            {
                MessageBox.Show("Точка уже существует");
            }
            }
            CBUpdate();
            DotNameTB.Clear();
            pictureBox1.Refresh();
        }

        private void DotNameTB_TextChanged(object sender, EventArgs e)
        {
            DotNameTB.Text = DotNameTB.Text.ToUpper();
        }
        #endregion

        #region Рисунок
        public int[,] mass1;
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            int P = 360;
            int counter = 0;
            int DotsAmount = DotsLB.Items.Count;

            if (DotsAmount > 0)
            {

                mass1 = new int[DotsAmount + 1, 2];
                string[,] Dots = new string[3, DotsAmount];
                string[] Directions;
                if (checkBox1.Checked)
                {
                    Directions = new string[DirectionsLB.Items.Count * 2];
                }
                else
                {
                    Directions = new string[DirectionsLB.Items.Count];
                }
                SetDirections(Directions);
                SetStart(Dots);



                Graphics g = e.Graphics;
                Pen pen = new Pen(Brushes.Black, 1);
                Brush brush1 = new SolidBrush(Color.Black);


                Font font1 = new Font("Arial", 14);
                Font font2 = new Font("Arial", 8);


                for (int i = 0; i < P; i += P / DotsAmount)
                {
                    if (counter == DotsAmount)
                    {

                    }
                    else
                    {
                        int x = (int)(100 * Math.Cos(Math.PI / 180 * (i - 90)) + 130);
                        mass1[counter, 0] = x;
                        int y = (int)(100 * Math.Sin(Math.PI / 180 * (i - 90)) + 130);
                        mass1[counter, 1] = y;
                        g.FillEllipse(brush1, x - 5, y - 5, 10, 10);
                        int x1 = (int)(115 * Math.Cos(Math.PI / 180 * (i - 90)));
                        int y1 = (int)(115 * Math.Sin(Math.PI / 180 * (i - 90)));
                        g.DrawString(DotsLB.Items[counter].ToString(), font1, brush1, x1 + 130 - 10, y1 + 130 - 10);
                        counter++;
                    }
                }
                string abc, abc2, line;
                Point p1, p2;
                int index1, index2;

                for (int i = 0; i < DotsLB.Items.Count; i++)
                {
                    for (int j = 0; j < DirectionsLB.Items.Count; j++)
                    {
                        abc = DotsLB.Items[i].ToString();
                        abc2 = DirectionsLB.Items[j].ToString().Substring(1, 1);
                        line = DirectionsLB.Items[j].ToString().Substring(3);
                        if (DotsLB.Items[i].ToString() == DirectionsLB.Items[j].ToString().Substring(0, 1))
                        {
                            index1 = GetDot(Dots, abc);
                            index2 = GetDot(Dots, abc2);
                            p1 = new Point(mass1[index1, 0], mass1[index1, 1]);
                            p2 = new Point(mass1[index2, 0], mass1[index2, 1]);
                            g.DrawString(line, font2, brush1, ((p1.X + p2.X) / 2), ((p1.Y + p2.Y) / 2) - 10);
                            pen.Color = Color.OrangeRed;
                            if (!checkBox1.Checked)
                            {
                                pen.CustomEndCap = new AdjustableArrowCap(4, 5);
                            }
                            g.DrawLine(pen, p1, p2);


                        }
                    }
                }
            }
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                panel2.Enabled = true;
            }
            else
            {
                panel2.Enabled = false;
            }
            pictureBox1.Refresh();
        }
        #endregion




    }
}
