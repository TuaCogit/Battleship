using System;
using System.Collections.Generic;
using System.Text;

namespace seabatleform
{
    class ArrangeShips
    {
        private int Number;
        const int four = 1, three = 2, two = 3, one = 4;
        public int[,] UserBot(int[,] field)
        {
            
                Number = 0;
                Four(field);
                while (Number < three)
                {
                    Three(field);
                }
                Number = 0;
                while (Number < two)
                {
                    Two(field);
                }
                Number = 0;
                while (Number < one)
                {
                    One(field);
                }

                return field;
            }
            
        private void Four(int[,] field)
            {
            try
            {
                var random = new Random();
                int x = random.Next(10);
                int y = random.Next(10);
                if (x > 5)
                {
                    y = random.Next(5);
                    for (int i = y; i < y + 4; i++)
                    {
                        field[i, x] = 1;
                    }
                    return;
                }
                if (y > 5)
                {
                    x = random.Next(5);
                    for (int j = x; j < x + 4; j++)
                    {
                        field[y, j] = 1;
                    }
                    return;
                }
                int k = random.Next(1);
                if (k == 0)
                {
                    for (int i = y; i < y + 4; i++)
                    {
                        field[i, x] = 1;
                    }
                }
                else
                {
                    for (int j = x; j < x + 4; j++)
                    {
                        field[y, j] = 1;
                    }
                }
            }

            catch (StackOverflowException) { }
        }
            //двухпалуб
            private void Three(int[,] field)
            {
            try
            {
                var random = new Random();
                var x = random.Next(10);
                var y = random.Next(10);
                if (y > 6)
                {
                    x = random.Next(7);
                    for (int i = y - 1; i < y + 2; i++)
                    {
                        if (i < 0)
                        {
                            i++;
                        }
                        if (i > 9)
                        {
                            break;
                        }
                        for (int j = x - 1; j < x + 4; j++)
                        {
                            if (j < 0)
                            {
                                j++;
                            }
                            if (j > 9)
                            {
                                break;
                            }
                            if (field[i, j] != 0)
                            {
                                return;
                            }
                        }
                    }
                    for (int j = x; j < x + 3; j++)
                    {
                        field[y, j] = 1;
                    }
                    Number++;
                    return;
                }
                if (x > 6)
                {
                    y = random.Next(7);
                    for (int i = y - 1; i < y + 4; i++)
                    {
                        if (i < 0)
                        {
                            i++;
                        }
                        if (i > 9)
                        {
                            break;
                        }
                        for (int j = x - 1; j < x + 2; j++)
                        {
                            if (j < 0)
                            {
                                j++;
                            }
                            if (j > 9)
                            {
                                break;
                            }
                            {
                                if (field[i, j] != 0)
                                {
                                    return;
                                }
                            }
                        }
                    }
                    for (int i = y; i < y + 3; i++)
                    {
                        field[i, x] = 1;
                    }
                    Number++;
                    return;
                }
                int k = random.Next(1);
                if (k == 0)
                {
                    for (int i = y - 1; i < y + 4; i++)
                    {
                        if (i < 0)
                        {
                            i++;
                        }
                        if (i > 9)
                        {
                            break;
                        }
                        for (int j = x - 1; j < x + 2; j++)
                        {
                            if (j < 0)
                            {
                                j++;
                            }
                            if (j > 9)
                            {
                                break;
                            }
                            if (field[i, j] != 0)
                            {
                                return;
                            }
                        }
                    }
                    for (int i = y; i < y + 3; i++)
                    {
                        field[i, x] = 1;
                    }
                    Number++;
                }
                else
                {
                    for (int i = y - 1; i < y + 2; i++)
                    {
                        if (i < 0)
                        {
                            i++;
                        }
                        if (i > 9)
                        {
                            break;
                        }
                        for (int j = x - 1; j < x + 4; j++)
                        {
                            if (j < 0)
                            {
                                j = 0;
                            }
                            if (j > 9)
                            {
                                break;
                            }
                            if (field[i, j] != 0)
                            {
                                return;
                            }
                        }
                    }
                    for (int j = x; j < x + 3; j++)
                    {
                        field[y, j] = 1;
                    }
                    Number++;
                }
            }

            catch (StackOverflowException) { }
        }
            //трехпалуб
            private void Two(int[,] field)
            {
            try
            {
                var random = new Random();
                var x = random.Next(10);
                var y = random.Next(10);
                if (y > 7)
                {
                    x = random.Next(8);
                    for (int i = y - 1; i < y + 2; i++)
                    {
                        if (i < 0)
                        {
                            i++;
                        }
                        if (i > 9)
                        {
                            break;
                        }
                        for (int j = x - 1; j < x + 3; j++)
                        {
                            if (j < 0)
                            {
                                j++;
                            }
                            if (j > 9)
                            {
                                break;
                            }
                            if (field[i, j] != 0)
                            {
                                return;
                            }
                        }
                    }
                    for (int j = x; j < x + 2; j++)
                    {
                        field[y, j] = 1;
                    }
                    Number++;
                    return;
                }
                if (x > 7)
                {
                    y = random.Next(8);
                    for (int i = y - 1; i < y + 3; i++)
                    {
                        if (i < 0)
                        {
                            i++;
                        }
                        if (i > 9)
                        {
                            break;
                        }
                        for (int j = x - 1; j < x + 2; j++)
                        {
                            if (j < 0)
                            {
                                j++;
                            }
                            if (j > 9)
                            {
                                break;
                            }
                            if (field[i, j] != 0)
                            {
                                return;
                            }
                        }
                    }
                    for (int i = y; i < y + 2; i++)
                    {
                        field[i, x] = 1;
                    }
                    Number++;
                    return;
                }
                int k = random.Next(1);
                if (k == 0)
                {
                    for (int i = y - 1; i < y + 3; i++)
                    {
                        if (i < 0)
                        {
                            i++;
                        }
                        if (i > 9)
                        {
                            break;
                        }
                        for (int j = x - 1; j < x + 2; j++)
                        {
                            if (j < 0)
                            {
                                j++;
                            }
                            if (j > 9)
                            {
                                break;
                            }
                            if (field[i, j] != 0)
                            {
                                return;
                            }
                        }
                    }
                    for (int i = y; i < y + 2; i++)
                    {
                        field[i, x] = 1;
                    }
                    Number++;
                }
                else
                {
                    for (int i = y - 1; i < y + 2; i++)
                    {
                        if (i < 0)
                        {
                            i++;
                        }
                        if (i > 9)
                        {
                            break;
                        }
                        for (int j = x - 1; j < x + 3; j++)
                        {
                            if (j < 0)
                            {
                                j++;
                            }
                            if (j > 9)
                            {
                                break;
                            }
                            if (field[i, j] != 0)
                            {
                                return;
                            }
                        }
                    }
                    for (int j = x; j < x + 2; j++)
                    {
                        field[y, j] = 1;
                    }
                    Number++;
                }
            }

            catch (StackOverflowException) { }
        }
            private void One(int[,] field)
            {
            try { 
                var random = new Random();
                var x = random.Next(10);
                var y = random.Next(10);
                for (int i = y - 1; i < y + 2; i++)
                {
                    if (i < 0)
                    {
                        i++;
                    }
                    if (i > 9)
                    {
                        break;
                    }
                    for (int j = x - 1; j < x + 2; j++)
                    {
                        if (j < 0)
                        {
                            j++;
                        }
                        if (j > 9)
                        {
                            break;
                        }
                        if (field[i, j] != 0)
                        {
                            return;
                        }
                    }
                }
                field[y, x] = 1;
                Number++;
            }

            catch (StackOverflowException) { }
        }
        
             

    }
}
