using System;


namespace polynomial_calculator
{
    class Program
    {
        public static void inputarray1(int term, int[] poly_degree, int[] poly_coffecient)
        {
            try
            {

                Console.WriteLine("================Enter First Polynomial Degree===========");

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(">>>>        PLEASE ENTER NUMBER ONLY     <<<<<\n");
                Console.WriteLine("Please Enter Degree In Decending Order\nExample :  3 , 2 , 1\n");
                Console.ForegroundColor = ConsoleColor.White;

                //             FIRST POLYNOMIAL DEGREE INPUT
                for (int i = 0; i < poly_degree.Length; i++)
                {
                    Console.Write("Enter Degree " + (i + 1) + " : ");
                    poly_degree[i] = int.Parse(Console.ReadLine());
                }
                //             FIRST POLYNOMIAL COEFFIEIENT INPUT
                Console.WriteLine("================Enter First Polynomial Coefficent===========");
                for (int i = 0; i < poly_degree.Length; i++)
                {
                    Console.Write("Enter Coefficient  of X^" + poly_degree[i] + " : ");
                    poly_coffecient[i] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("--------------------------------------------------------");
            }
            catch (FormatException e)
            {
                Console.Clear();
                inputarray1(term, poly_degree, poly_coffecient);
            }

        }
        public static void inputarray2(int term, int[] poly_degree, int[] poly_coffecient)
        {
            try
            {
                Console.WriteLine("================Enter Second Polynomial Degree===========");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(">>>>        PLEASE ENTER NUMBER ONLY     <<<<<\n");
                Console.WriteLine("Please Enter Degree In Decending Order\nExample :  3 , 2 , 1\n");

                Console.ForegroundColor = ConsoleColor.White;
                //             SECOND POLYNOMIAL DEGREE INPUT
                for (int i = 0; i < poly_degree.Length; i++)
                {
                    Console.Write("Enter Degree " + (i + 1) + " : ");
                    poly_degree[i] = int.Parse(Console.ReadLine());
                }
                //             SECOND POLYNOMIAL COEFFICIENT INPUT
                Console.WriteLine("================Enter Second Polynomial Coefficent===========");
                for (int i = 0; i < poly_degree.Length; i++)
                {
                    Console.Write("Enter Value Of X^" + poly_degree[i] + " : ");
                    poly_coffecient[i] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("--------------------------------------------------------");
            }
            catch (FormatException e)
            {
                Console.Clear();
                inputarray2(term, poly_degree, poly_coffecient);
            }
        }

        public static void print(int terms, int[] degree, int[] coefficient)
        {
            for (int i = 0; i < terms; i++)
            {
                if (i == 0 && coefficient[i] < 0)
                {
                    Console.Write("-" + (coefficient[i] * -1));
                }
                else if (coefficient[i] < 0)
                {
                    Console.Write(" - " + (coefficient[i] * -1));
                }
                else if (i == 0 && coefficient[i] > 0)
                {
                    Console.Write(coefficient[i]);
                }
                else if (coefficient[i] == 0)
                {
                    continue;
                }
                else
                {
                    Console.Write(" + " + coefficient[i]);
                }
                if (degree[i] == 1)
                {
                    Console.Write("X");
                }
                else if (degree[i] != 0)
                {
                    Console.Write("X^" + degree[i]);
                }
            }

        }
        public static void array(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 0;
            }
        }


        public static void ADDPOLYNOMIAL(int item1, int[] firstpoly_degree, int[] firstpoly_coffecient,
            int item2, int[] secondpoly_degree, int[] secondpoly_coffecient,
           ref int item3, int[] result_degree, int[] result_coefficent)
        {
            //int max_deg = (firstpoly_degree[0]+ secondpoly_degree[0]) + 1;
            int max_deg = 100;
            int[] polyA = new int[max_deg];
            array(polyA);
            for (int i = 0; i < item1; i++)
            {
                polyA[firstpoly_degree[i]] = firstpoly_coffecient[i];
            }
            int[] polyB = new int[max_deg];
            array(polyB);
            for (int i = 0; i < item2; i++)
            {
                polyB[secondpoly_degree[i]] = secondpoly_coffecient[i];
            }
            for (int i = max_deg - 1; i >= 0; i--)
            {
                if (polyA[i] == 0 && polyB[i] == 0)
                    continue;
                result_degree[item3] = i; //store deg
                result_coefficent[item3] = polyA[i] + polyB[i];
                item3++; //increment term
            }

        }


        public static void SUBTRACTPOLYNOMIAL(int item1, int[] firstpoly_degree, int[] firstpoly_coffecient,
           int item2, int[] secondpoly_degree, int[] secondpoly_coffecient,
          ref int item3, int[] result_degree, int[] result_coefficent)
        {
            //int max_deg = (firstpoly_degree[0]+ secondpoly_degree[0]) + 1;
            int max_deg = 100;
            int[] polyA = new int[max_deg];
            array(polyA);
            for (int i = 0; i < item1; i++)
            {
                polyA[firstpoly_degree[i]] = firstpoly_coffecient[i];
            }
            int[] polyB = new int[max_deg];
            array(polyB);
            for (int i = 0; i < item2; i++)
            {
                polyB[secondpoly_degree[i]] = secondpoly_coffecient[i];
            }
            for (int i = max_deg - 1; i >= 0; i--)
            {
                if (polyA[i] == 0 && polyB[i] == 0)
                    continue;
                result_degree[item3] = i;    //store deg
                result_coefficent[item3] = polyA[i] - polyB[i];
                item3++;                    //increment term
            }

        }



        public static void MULTIPLYPOLYNOMIAL(int item1, int[] firstpoly_degree, int[] firstpoly_coffecient,
         int item2, int[] secondpoly_degree, int[] secondpoly_coffecient,
        ref int item3, int[] result_degree, int[] result_coefficent)
        {
            //int max_deg = (firstpoly_degree[0]+ secondpoly_degree[0]) + 1;
            int max_deg = (firstpoly_degree[0] + secondpoly_degree[0]) + 1;

            int[] Result = new int[max_deg];
            array(Result);
            for (int i = 0; i < item1; i++)
            {
                for (int j = 0; j < item2; j++)
                {
                    Result[firstpoly_degree[i] + secondpoly_degree[j]] += firstpoly_coffecient[i] * secondpoly_coffecient[j];
                }
            }

            for (int i = max_deg - 1; i >= 0; i--)
            {
                if (Result[i] == 0)
                    continue;
                result_degree[item3] = i; //store deg
                result_coefficent[item3] = (Result[i]);
                item3++; //increment term
            }

        }

        public static double SOLVEPOLYNOMIAL(int terms, int[] degree, int[] coeffieent, double variable)
        {
            double result = 0;
            for (int i = 0; i < terms; i++)
            {
                result += coeffieent[i] * Math.Pow(variable, degree[i]);

            }
            return result;
        }


        public static void EQUALPOLYNOMIAL(int item1, int[] firstpoly_degree, int[] firstpoly_coffecient,
            int item2, int[] secondpoly_degree, int[] secondpoly_coffecient)
        {

            int max_deg = 100;
            int[] polyA = new int[max_deg];
            array(polyA);

            for (int i = 0; i < item1; i++)
            {
                polyA[firstpoly_degree[i]] = firstpoly_coffecient[i];
            }
            int[] polyB = new int[max_deg];
            array(polyB);
            for (int i = 0; i < item2; i++)
            {
                polyB[secondpoly_degree[i]] = secondpoly_coffecient[i];
            }
            bool flag1 = true;
            bool flag2 = true;

            flag1 = (item1 == item2) ? true : false;


            for (int i = max_deg - 1; i >= 0; i--)
            {
                if (polyA[i] != polyB[i])
                {
                    flag2 = false;
                    break;
                }
            }


            if (flag1 && flag2)
            {

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("BOTH POLYNOMIAL ARE EQUAL");
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("BOTH POLYNOMIAL ARE NOT EQUAL");
                Console.ForegroundColor = ConsoleColor.Black;

            }
        }






        public static void Main(string[] args)
        {
            //--------------------------------------------------------------------
            //-----------------------MAIN METHOD STARTED-------------------------- 
            //--------------------------------------------------------------------

            int item1 = 0, item2;
            int item3 = 0;
            char res1;
            int[] result_degree = new int[50];
            int[] result_coefficent = new int[50];
        start:


            Console.WriteLine("\t\t``````````````````````````````````````````````````");
            Console.WriteLine("\t\t***************POLYNOMIAL CALCULATOR**************");
            Console.WriteLine("\t\t``````````````````````````````````````````````````");
            //             FIRST POLYNOMIAL VALUE INPUT




            try
            {

                Console.Write("Enter The Value Of First Polynomial : ");
                item1 = int.Parse(Console.ReadLine());

                int[] firstpoly_coffecient = new int[item1];
                int[] firstpoly_degree = new int[item1];

                inputarray1(item1, firstpoly_degree, firstpoly_coffecient);

                #region first_polynomial_input
                //Console.WriteLine("================Enter First Polynomial Degree===========");

                //Console.ForegroundColor = ConsoleColor.DarkRed;
                //Console.WriteLine("Please Enter Degree In Decending Order\nExample :  3 , 2 , 1\n");
                //Console.ForegroundColor = ConsoleColor.Black;

                ////             FIRST POLYNOMIAL DEGREE INPUT
                //for (int i = 0; i < firstpoly_degree.Length; i++)
                //{
                //    Console.Write("Enter Degree " + (i + 1) + " : ");
                //    firstpoly_degree[i] = int.Parse(Console.ReadLine());
                //}
                ////             FIRST POLYNOMIAL COEFFIEIENT INPUT
                //Console.WriteLine("================Enter First Polynomial Coefficent===========");
                //for (int i = 0; i < firstpoly_degree.Length; i++)
                //{
                //    Console.Write("Enter Coefficient  of X^" + firstpoly_degree[i] + " : ");
                //    firstpoly_coffecient[i] = int.Parse(Console.ReadLine());
                //}
                //Console.WriteLine("--------------------------------------------------------");

                #endregion



                //             SECOND POLYNOMIAL VALUE INPUT
                Console.Write("Enter The Value Of Second Polynomial : ");
                item2 = int.Parse(Console.ReadLine());



                int[] secondpoly_coffecient = new int[item2];
                int[] secondpoly_degree = new int[item2];


                inputarray2(item2, secondpoly_degree, secondpoly_coffecient);

                #region second_polynomial_input
                //Console.WriteLine("================Enter Second Polynomial Degree===========");
                //Console.ForegroundColor = ConsoleColor.DarkRed;
                //Console.WriteLine("Please Enter Degree In Decending Order\nExample :  3 , 2 , 1\n");

                //Console.ForegroundColor = ConsoleColor.Black;
                ////             SECOND POLYNOMIAL DEGREE INPUT
                //for (int i = 0; i < secondpoly_degree.Length; i++)
                //{
                //    Console.Write("Enter Degree " + (i + 1) + " : ");
                //    secondpoly_degree[i] = int.Parse(Console.ReadLine());
                //}
                ////             SECOND POLYNOMIAL COEFFICIENT INPUT
                //Console.WriteLine("================Enter Second Polynomial Coefficent===========");
                //for (int i = 0; i < secondpoly_degree.Length; i++)
                //{
                //    Console.Write("Enter Value Of X^" + secondpoly_degree[i] + " : ");
                //    secondpoly_coffecient[i] = int.Parse(Console.ReadLine());
                //}

                #endregion
                Console.Clear();
                //             FIRST POLYNOMIAL PRINTING
                Console.Write("| First Polynomial IS >>        ");
                print(item1, firstpoly_degree, firstpoly_coffecient);
                Console.Write("     << |\n");
                //             SECOND POLYNOMIAL PRINTING
                Console.Write("| Second Polynomial IS >>       ");
                print(item2, secondpoly_degree, secondpoly_coffecient);
                Console.Write("     << |\n");

                //             MAIN MENU 

                Console.WriteLine("=======================================================");
                Console.WriteLine("=======================================================");
                Console.WriteLine("PLease Choose From Below");
                Console.WriteLine(" 1 ) Add Polynomial");
                Console.WriteLine(" 2 ) Subtract Polynomial");
                Console.WriteLine(" 3 ) Multiply Polynomial");
                Console.WriteLine(" 4 ) SOLVE Polynomial");
                Console.WriteLine(" 5 ) EQUAL Polynomial");
                Console.Write("Enter : ");
                int res = int.Parse(Console.ReadLine());
                switch (res)
                {
                    case 1:
                        ADDPOLYNOMIAL(item1, firstpoly_degree, firstpoly_coffecient, item2, secondpoly_degree,
                      secondpoly_coffecient, ref item3, result_degree, result_coefficent);

                        //             ADD POLYNOMIAL PRINTING
                        Console.WriteLine("\n\n");
                        Console.Write("| Answer Polynomial IS >>       ");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        print(item3, result_degree, result_coefficent);

                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("     << |\n\n");

                        break;
                    case 2:
                        SUBTRACTPOLYNOMIAL(item1, firstpoly_degree, firstpoly_coffecient, item2, secondpoly_degree,
                   secondpoly_coffecient, ref item3, result_degree, result_coefficent);

                        //             SUBTRACT POLYNOMIAL PRINTING
                        Console.WriteLine("\n\n");
                        Console.Write("| Answer Polynomial IS >>       ");
                        Console.ForegroundColor = ConsoleColor.DarkRed;

                        print(item3, result_degree, result_coefficent);

                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("     << |\n\n");


                        break;
                    case 3:
                        MULTIPLYPOLYNOMIAL(item1, firstpoly_degree, firstpoly_coffecient, item2, secondpoly_degree,
                    secondpoly_coffecient, ref item3, result_degree, result_coefficent);

                        //             MULTIPLY POLYNOMIAL PRINTING
                        Console.WriteLine("\n\n");
                        Console.Write("| Answer Polynomial IS >>       ");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        print(item3, result_degree, result_coefficent);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("     << |\n\n");

                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("Enter Value Of \"X\" In Polynomial 1 : ");
                        double variable1 = double.Parse(Console.ReadLine());
                        //Console.ForegroundColor = ConsoleColor.Black;

                        //Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("Enter Value Of \"X\" In Polynomial 2 : ");
                        double variable2 = double.Parse(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.White;


                        //             SOLVE POLYNOMIAL 1 ANSWER

                        Console.WriteLine("\n");
                        Console.Write("| Answer Polynomial  1 IS >>       " + SOLVEPOLYNOMIAL(item1, firstpoly_degree, firstpoly_coffecient, variable1));
                        Console.Write("     << |\n");
                        Console.WriteLine("------------------------------------------------");
                        //             SOLVE POLYNOMIAL 2 ANSWER

                        Console.Write("| Answer Polynomial  2 IS >>       " + SOLVEPOLYNOMIAL(item2, secondpoly_degree, secondpoly_coffecient, variable2));
                        Console.Write("     << |\n\n");
                        break;
                    case 5:
                        Console.Write("\n|    >>     ");
                        EQUALPOLYNOMIAL(item1, firstpoly_degree, firstpoly_coffecient, item2, secondpoly_degree, secondpoly_coffecient);
                        Console.Write("     << |\n\n");


                        break;
                    default:
                        Console.WriteLine("----------------------------------------------------------------------");
                        Console.WriteLine("----------------PLEASE ENTER FROM ABOVE OPTIONS-----------------------");
                        Console.WriteLine("----------------------------------------------------------------------");
                        break;

                }
                do
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("DO You Want To Run Again ( y \\  n )  : ");
                    res1 = char.Parse(Console.ReadLine().ToLower());
                    switch (res1)
                    {
                        case 'y':
                            item3 = 0;
                            array(result_degree);
                            array(result_coefficent);
                            Console.Clear();
                            goto start;
                        case 'n':
                            Console.WriteLine("\n------------------------------------------------------------------------");
                            Console.WriteLine("-----------------------THANK YOU ---------------------------------------");
                            Console.WriteLine("------------------------------------------------------------------------");
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("-------------------------------------------------------------------------");
                            Console.WriteLine("-------------PLEASE ENTER CORRECT OPTION ( Y \\ N )-------------------------");
                            Console.WriteLine("-------------------------------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;


                    }
                } while (res1 != 'n');
            }
            catch (FormatException e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.WriteLine("-------------------PLEASE ENTER NUMBER ONLY------------------------------");
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Black;
            }
            catch (SystemException E)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.WriteLine("---------------NUMBER MUST BE GREATER OR EQUAL THAN ZERO-----------------");
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Black;
            }





            Console.ReadLine();

        }
    }
}

