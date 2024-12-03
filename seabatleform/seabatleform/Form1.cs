using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace seabatleform
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
 
        }
      
        List<Button> listButUser;
        List<Button> listButBot;

        public int[,] Field1, BotField, UserField;
        public string[] letters = { "А", "Б", "В", "Г", "Д", "Е", "Ж", "З", "И", "К" };
        public int Step, quanUserStep, quanBotStep, Indent, Number;
        int[] IndexX, IndexY;
        ArrangeShips arship;
        // обработка нажатия на кнопку начала игры
        //присвоение значений
        private void butStart_Click(object sender, EventArgs e)
        {
            try
            {
                Field1 = new int[10, 10]; //0 - пустая клетка, 1 - корабль, 2 - попадание по кораблю, 3 - промах
                Step = new int();
                IndexX = new int[101]; //x
                IndexY = new int[101]; //y
                quanUserStep = 0; quanBotStep = 0; Indent = 2; Number = 0;
                BotField = new int[10, 10]; //поле бота
                UserField = new int[10, 10]; //поле человека
                listButUser = new List<Button>(); // поле кнопок для бота (корабли человека)
                listButBot = new List<Button>(); //поле кнопок для человека (корабли бота)
                arship = new ArrangeShips();
                for (int i = 0; i < 100; i++)
                {
                    listButUser.Add(panelUser.Controls["button" + (i + 1).ToString()] as Button);
                }
                for (int i = 0; i < 100; i++)
                {
                    listButBot.Add(panelBot.Controls["button" + (i + 101).ToString()] as Button);
                }
                //расстановка кораблей бота
                arship.UserBot(BotField);
                DrawField(Field1);//отрисовка поля
                manually.Enabled = true;
                avto.Enabled = true;
                panelUser.Enabled = true;
                butStart.Enabled = false;

            }
            catch (StackOverflowException)
            {
                MessageBox.Show("aaaa", "aaaa");
            }
        }

        public void DrawField(int[,] Field)
        {
            //расстановка цифр для чела
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        int butinx; //индекс кнопки в массиве кнопок
                        if (i == 0) butinx = j;
                        else butinx = Convert.ToInt32(string.Format("{0}{1}", i, j));
                        FillingCells(UserField[i, j], butinx, listButUser); //отрисовка поля человека
                        FillingCells(Field[i, j], butinx, listButBot); //отрисовка рабочего поля
                    }
                }
            }
            catch (StackOverflowException)
            {
                MessageBox.Show("aaaa", "aaaa2");
            }

        }
        //отрисовка поля
        public void FillingCells(int a, int butind, List<Button> listBut)
        {
            try
            {
                switch (a)
                {
                    case 0: //не пройденная ячейка
                        listBut[butind].BackColor = Color.Azure;
                        listBut[butind].Enabled = true;
                        break;
                    case 1: // поставлен корабль пользователя
                        listBut[butind].BackColor = Color.DarkBlue;
                        listBut[butind].Enabled = false;
                        break;
                    case 2: //попадение
                        listBut[butind].BackColor = Color.Brown;
                        listBut[butind].Enabled = false;
                        break;
                    case 3: //мимо
                        listBut[butind].BackColor = Color.SkyBlue;
                        listBut[butind].Enabled = false;
                        break;
                        //  case 4: //нельзя ходить
                        //    listBut[butind].BackColor = Color.Blue;
                        //  listBut[butind].Enabled = false;
                        // break;
                }

            }
            catch (StackOverflowException)
            {
                MessageBox.Show("aaaa", "aaaa3");
            }
        }
        //проверка ячейки и расчет хода бота
        protected void CheckShip(int[,] Field, int i, int j, bool isUser, bool enab)
        {
            try
            {
                int lengthShip = 1;
                int x = j; int y = i;
                for (int k = 1; k < 4; k++)
                {
                    try
                    {
                        if (Field[i - k, j] == 2)
                        {
                            lengthShip++;
                            y--;
                        }
                        if (Field[i - k, j] == 1)
                        {
                            xx = j;
                            yy = i - k;
                            if (!isUser) popal = true;
                            return;
                        }
                        if (Field[i - k, j] == 0 || Field[i - k, j] == 3) break;
                    }
                    catch (IndexOutOfRangeException) { break; }
                }
                for (int k = 1; k < 4; k++)
                {
                    try
                    {
                        if (Field[i + k, j] == 2) lengthShip++;
                        if (Field[i + k, j] == 1)
                        {
                            xx = j;
                            yy = i + k;
                            if (!isUser) popal = true;
                            return;
                        }
                        if (Field[i + k, j] == 0 || Field[i + k, j] == 3) break;
                    }
                    catch (IndexOutOfRangeException) { break; }
                }
                if (lengthShip > 1)
                {
                    for (int k = y - 1; k < y + lengthShip + 1 && k < 10; k++)
                    {
                        if (k < 0) k++;
                        for (int l = x - 1; l < x + 2 && l < 10; l++)
                        {
                            if (l < 0) l++;
                            if (Field[k, l] != 2)
                            {
                                Field[k, l] = 3;
                                if (isUser) Field1[k, l] = 3;
                            }
                        }
                    }
                    if (!isUser) popal = false;
                    return;
                }

                for (int k = 1; k < 4; k++)
                {
                    try
                    {
                        if (Field[i, j - k] == 2)
                        {
                            lengthShip++;
                            x--;
                        }
                        if (Field[i, j - k] == 1)
                        {
                            xx = j - k;
                            yy = i;
                            if (!isUser) popal = true;
                            return;
                        }
                        if (Field[i, j - k] == 0 || Field[i, j - k] == 3) break;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        break;
                    }
                }
                for (int k = 1; k < 4; k++)
                {
                    try
                    {
                        if (Field[i, j + k] == 2) lengthShip++;
                        if (Field[i, j + k] == 1)
                        {
                            xx = j + k;
                            yy = i;
                            if (!isUser) popal = true;
                            return;
                        }
                        if (Field[i, j + k] == 0 || Field[i, j + k] == 3) break;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        break;
                    }
                }
                if (lengthShip > 1)
                {
                    for (int l = y - 1; l < y + 2 && l < 10; l++)
                    {
                        for (int k = x - 1; k < x + lengthShip + 1 && k < 10; k++)
                        {
                            if (k < 0) k++;
                            if (l < 0) l++;
                            if (Field[l, k] != 2)
                            {
                                Field[l, k] = 3;
                                if (isUser) Field1[l, k] = 3;
                            }
                        }
                    }
                    if (!isUser) popal = false;
                    return;
                }

                if (lengthShip == 1)
                {
                    for (int k = y - 1; k < y + 2 && k < 10; k++)
                    {
                        if (k < 0) k = 0;
                        for (int l = x - 1; l < x + 2 && l < 10; l++)
                        {
                            if (l < 0) l = 0;
                            if (Field[k, l] != 2)
                            {
                                Field[k, l] = 3;
                                if (isUser) Field1[k, l] = 3;
                            }
                        }
                    }
                    if (!isUser) popal = false;
                }
            }
            catch (StackOverflowException)
            {
                MessageBox.Show("aaaa", "aaaa4");
            }
        }

        //ход человека
        public void Strike()
        {
            try
            {
                if (Win(true))
                {
                    return;
                }
                richTextBox1.AppendText("Ваш Ход №" + ((++Step).ToString()) + ": " + letters[tagLett] + (tagIndx + 1) + "\n");
                stepBot = false;
                IndexX[Step] = tagLett;
                IndexY[Step] = tagIndx;
                if (Hit(IndexY[Step], IndexX[Step], BotField, true)) quanUserStep++;
            }
            catch (StackOverflowException)
            {
                MessageBox.Show("aaaa", "aaaa5");
            }

        }
        //победа
        public bool Win(bool isUser)
        {
            try
            {
                if (quanUserStep == 20)
                {
                    richTextBox1.AppendText("Победа Ваша!");
                    richTextBox1.AppendText("поинт " + quanUserStep);
                    panelBot.Enabled = false;
                    return true;
                }
                if (quanBotStep == 20)
                {
                    richTextBox1.AppendText("Вы проиграли!");
                    panelBot.Enabled = false;
                    return true;
                }
                
            }
            catch (StackOverflowException)
            {
                MessageBox.Show("aaaa", "aaaa6");
            }
            return false;
        }

        //постановка кораблей
        private void putShip(int[,] field, int x, int y)
        {
            try
            {
                if (shiplength == 1)
                {
                    field[y, x] = 1;
                    return;
                }
                if (!horiz)  //корабль вертикальный
                {
                    for (int i = y; i < y + shiplength; i++) field[i, x] = 1;
                    DrawField(Field1);
                    return;
                }
                if (horiz)//корабль горизонтальный
                {
                    for (int j = x; j < x + shiplength; j++) field[y, j] = 1;
                    DrawField(Field1);
                    return;
                }
            }
            catch (StackOverflowException)
            {
                MessageBox.Show("aaaa", "aaaa7");
            }

        }
        int ship = 41;
        int shiplength = 4;
        //обработчик переключения корабля
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            proverka();
        }
        //ограничение клеток для постановки корабля в зависимости от длины
        void proverka()
        {
            try
            {
                DrawField(Field1);
                switch (ship)
                {
                    case 41: //4хпалуб гориз
                        horiz = true;
                        shiplength = 4;
                        for (int i = 7; i < 99; i += 10)
                        {
                            listButUser[i].Enabled = false;
                            listButUser[i + 1].Enabled = false;
                            listButUser[i + 2].Enabled = false;
                        }
                        break;
                    case 42: //4хпалуб вертик
                        horiz = false;
                        shiplength = 4;
                        for (int i = 70; i < 99; i += 10)
                        {
                            for (int j = i; j < i + 10; j++)
                            {
                                listButUser[j].Enabled = false;
                            }
                        }
                        break;
                    case 31: //3хпалуб гориз
                        horiz = true;
                        shiplength = 3;
                        for (int i = 8; i < 99; i += 10)
                        {
                            listButUser[i].Enabled = false;
                            listButUser[i + 1].Enabled = false;
                        }
                        break;
                    case 32: //3хпалуб вертик
                        horiz = false;
                        shiplength = 3;
                        for (int i = 80; i < 99; i += 10)
                        {
                            for (int j = i; j < i + 10; j++)
                            {
                                listButUser[j].Enabled = false;
                            }
                        }
                        break;
                    case 21: //2хпалуб гориз
                        horiz = true;
                        shiplength = 2;
                        for (int i = 9; i < 100; i += 10)
                        {
                            listButUser[i].Enabled = false;
                        }
                        break;
                    case 22: //2хпалуб вертик
                        horiz = false;
                        shiplength = 2;
                        for (int j = 90; j < 100; j++)
                        {
                            listButUser[j].Enabled = false;
                        }
                        break;
                    case 1: //1палуб 
                        shiplength = 1;
                        break;
                }
            }
            catch (StackOverflowException)
            {
                MessageBox.Show("aaaa", "aaaa8");
            }
        }
        int butclick;
        int cooon = 0;
        int butx, buty;
        private void userFieldBut_Click(object sender, EventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                string st = Convert.ToString(button.Tag);
                butclick = int.Parse(st);
                butx = int.Parse(st.Substring(0, 1)); //получение Х
                buty = int.Parse(st.Substring(1)); //получение У
                putShip(UserField, butx, buty);  //постановка корабля
                DrawField(Field1);//отрисовка поля
                proverka();
                cooon++; //переключение корабля
                switch (cooon)
                {
                    case 1:
                        ship = 31;
                        lincorHoriz.Enabled = false;
                        lincorVertic.Enabled = false;
                        cruiserHoriz.Enabled = true;
                        cruiserVertic.Enabled = true;
                        esminetsHoriz.Enabled = false;
                        esminetsVrtic.Enabled = false;
                        boat.Enabled = false;
                        cruiserHoriz.Checked = true;
                        break;
                    case 3:
                        ship = 21;
                        esminetsHoriz.Enabled = true;
                        esminetsVrtic.Enabled = true;
                        cruiserHoriz.Enabled = false;
                        cruiserVertic.Enabled = false;
                        boat.Enabled = false;
                        esminetsHoriz.Checked = true;
                        break;
                    case 6:
                        ship = 1;
                        esminetsHoriz.Enabled = false;
                        esminetsVrtic.Enabled = false;
                        boat.Enabled = true;
                        boat.Checked = true;
                        break;
                    case 10:
                        boat.Enabled = false;
                        for (int i = 0; i < 10; i++)
                        {
                            for (int j = 0; j < 10; j++)
                            {
                                if (UserField[i, j] == 4)
                                {
                                    UserField[j, i] = 3;
                                }
                            }
                        }
                        panelUser.Enabled = false;
                        panelBot.Enabled = true;
                        break;
                }
            }
            catch (StackOverflowException)
            {
                MessageBox.Show("aaaa", "aaaa9");
            }
        }
        bool horiz = true;
        //обработчик кнопки "Вручную"
        private void manually_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            avto.Enabled = false;
            manually.Enabled = false;
            panelUser.Enabled = true;
            panelBot.Enabled = false;
            butStart.Enabled = false;
            proverka();
            butStart.Enabled = true;
        }
 //Обработчик кнопки "Авто"
        private void avto_Click(object sender, EventArgs e)
        {
            arship.UserBot(UserField);
            DrawField(Field1);//отрисовка поля
            avto.Enabled = false;
            manually.Enabled = false;
            panelBot.Enabled = true;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.TextLength;
            richTextBox1.ScrollToCaret();
        }


        ////////////////////////////////////////////////////////////////

        //выстрел бота
        public void StrikeB()
        {
            try
            {
                if (Win(false))
                {
                    return;
                }
                if (popal)
                {
                    IndexY[Step] = yy;
                    IndexX[Step] = xx;
                    richTextBox1.AppendText("Ход противника: " + letters[IndexX[Step]].ToString() + (IndexY[Step] + 1).ToString() + "\n");
                    if (Hit(IndexY[Step], IndexX[Step], UserField, false))
                    {
                        Step++;
                        quanBotStep++;
                        StrikeB();

                    }

                }
                else
                {
                    lala();
                    richTextBox1.AppendText("Ход противника: " + letters[IndexX[Step]].ToString() + (IndexY[Step] + 1).ToString() + "\n");
                    if (Hit(IndexY[Step], IndexX[Step], UserField, false))
                    {
                        Step++;
                        quanBotStep++;
                        StrikeB();

                    }
                }
            }
            catch (StackOverflowException)
            {
                MessageBox.Show("aaaa", "aaaa10");
            }
        }
        int[] oimax = { 3, 7, 9, 9 };
        int[] iomin = { 0, 0, 2, 6 };

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        int io = 0, oi = 3;
        int stepi = 0;
        //случайность для выстрела бота
        void lala()
        {
            if (stepi != 3)
            {
                calcShot();


                } else rand();
        }
        private void calcShot()
            {

                if (io == oimax[stepi]+1)
                {
                    stepi++;
                    io = iomin[stepi];
                    oi = oimax[stepi];
                    lala();

                }
                else
                {

                    IndexX[Step] = io; //0
                    IndexY[Step] = oi;  //3
                    xx = IndexX[Step];
                    yy = IndexY[Step];
                    if (UserField[IndexY[Step], IndexX[Step]] > 1)
                    {
                        io++; oi--;
                        lala();
                    }

                }
            }
               void rand() { 
                    var random = new Random(DateTime.Now.Millisecond);
                    IndexX[Step] = random.Next(9);
                    IndexY[Step] = random.Next(9);
                    xx = IndexX[Step];
                    yy = IndexY[Step];
                    if (UserField[IndexY[Step], IndexX[Step]] > 1 )
                    {
                        rand();
                    }
                }
            
        int xx, yy;
        bool popal = false;
        //сделан ход, определение результата хода
        public bool Hit(int i, int j, int[,] field, bool isUser) //если бот то isUser=false
        {
            try
            {
                if (field[i, j] == 0)
                {
                    field[i, j] = 3;
                    if (isUser) Field1[i, j] = 3;
                    stepBot = isUser; //isUser=false - стрелял бот и промахнулся, остается stepBot=false
                                      //isUser=true - стрелял чел и промах, значит stepBot=true - шаг бота
                    DrawField(Field1);
                    richTextBox1.AppendText("Промах!   \n");
                    if (!isUser) richTextBox1.AppendText("Ходите вы. \n");
                    return false;
                }
                if (field[i, j] == 1)
                {
                    field[i, j] = 2;

                    richTextBox1.AppendText("Попал! \n");

                    if (isUser) { richTextBox1.AppendText("Ходите ещё. \n"); Field1[i, j] = 2; }
                    stepBot = !isUser; //isUser=true - стрелял чел и попал, значит шаг бота = false;
                                       //isUser=false - стрелял бот и попал, значит шаг бота = true;
                    CheckShip(field, i, j, isUser, false);
                    DrawField(Field1);

                    return true;
                }


                if (field[i, j] > 1)
                {
                    if (isUser)
                    {
                        richTextBox1.AppendText("В эту клетку ход невозможен \n");
                        Step--;
                    }
                    return false;
                }
            }
            catch (StackOverflowException)
            {
                MessageBox.Show("aaaa", "aaaa6");
            }

            return false;
        }



        ////////////////////////////////////////////////////////////////
        public void zapusk()
        {
            try
            {
                Strike();
                if (Win(true))
                {
                    return;
                }
                if (stepBot)
                {
                    StrikeB();
                    if (Win(false))
                    {
                        return;
                    }
                }
                DrawField(Field1);//отрисовка поля
            }
            catch (StackOverflowException)
            {
                MessageBox.Show("ошибка");
            }
        }
        bool stepBot = false;
        int tagLett;
        int tagIndx;
        private void butLettIndx_Click(object sender, EventArgs e)
        {
                Button button = (Button)sender;
                string st = Convert.ToString(button.Tag);
                int indx = Convert.ToInt32(st);
                tagLett = int.Parse(st.Substring(0, 1));
                tagIndx = int.Parse(st.Substring(1));
                stepBot = true;
                zapusk(); 
        }


    }
}

