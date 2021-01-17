using System;
using System.Collections.Generic;

namespace Level1Space
{
  public static string BigMinus(string s1, string s2)
        {
           int[] MassiveAnsver (string se1, string se2)
            {
                int count3;
                if (se1.Length < se2.Length)
                {
                   // Console.WriteLine("1первое число меньше второго");
                    count3 = s2.Length-1;
                    string middle = se1;
                    se1 = se2;
                    se2 = middle;
                }
                else count3 = s1.Length-1;
                
                char[] massChar1 = se1.ToCharArray();
                int[] massInt1 = new int[massChar1.Length];
                char[] massChar2 = se2.ToCharArray();
                int[] massInt2 = new int[massChar2.Length];

                int[] massAnswer = new int[count3+1];
                for (int i = 0; i < massChar1.Length; i++)
                {
                    massInt1[i] = massChar1[i] - '0';
                }
                for (int i = 0; i < massChar2.Length; i++)
                {
                    massInt2[i] = massChar2[i] - '0';
                }
               
                int count2 = massInt2.Length - 1;
              
                for (int count = massInt1.Length - 1; count >= 0; count--)
                {
                    if (count2<0)
                    {
                        massAnswer[count3] = massInt1[count];
                        count3--;
                        continue;
                    }
                    if (count>=0 && count2>=0 && massInt1[count] - massInt2[count2] >= 0) //проверяем что разность первого и второго числа больше или равно 0
                    {
                     //   Console.WriteLine($"massint1<{massInt1[count]}>");
                     //   Console.WriteLine($"massint2<{massInt2[count2]}>");
                        massAnswer[count3] = massInt1[count] - massInt2[count2];
                  
                        count2--;
                    //    Console.WriteLine($"count3=<{count3}>");
                     //   Console.WriteLine($"next1<{massAnswer[count3]}>");
                        count3--;
                    }
                    else
                    {
                        if (count - 1 >= 0) //проверяем что есть следующее число
                        {
                            if (massInt1[count-1]==0) //если оно равно нулю
                            {
                                while (massInt1[count - 1] == 0)
                                {
                                    if (count - 2 >= 0) //проверяем, что следующее за нулем существует
                                    {
                                        massInt1[count - 1] = 9;
                                        if ( count2 >= 0)
                                        {
                                           
                                            if (massInt1[count] - massInt2[count2] >= 0) //проверяем что разность первого и второго числа больше или равно 0
                                            {
                                                massAnswer[count3] = massInt1[count] - massInt2[count2];
                                             //   Console.WriteLine($"count3=<{count3}>");
                                             //   Console.WriteLine($"next2<{massAnswer[count3]}>");
                                                
                                            }
                                            else
                                            {
                                                massAnswer[count3] = massInt1[count] + 10 - massInt2[count2];
                                              //  Console.WriteLine($"count3=<{count3}>");
                                               // Console.WriteLine($"next3<{massAnswer[count3]}>");
                                                
                                            }
                                            count3--;
                                            count2--;
                                        }
                                    }
                                    else //если за нулем нет больше числа
                                    {
                                        //3первое число меньше второго
                                        for (int i = 0; i < massAnswer.Length; i++)
                                        {
                                            massAnswer[i] = 0;
                                        }
                                        return MassiveAnsver(se2, se1);
                                    }
                                    count--;
                                }
                                massInt1[count-1] -= 1;
                                count++;
                                
                                
                            }
                            else //если оно не равно нулю
                            {
                                massAnswer[count3] = massInt1[count] + 10 - massInt2[count2];
                                massInt1[count - 1] -= 1;
                                count2--;
                                count3--;
                            }
                           
                        }
                        else
                        {
                            //"2первое число меньше второго"
                          for (int i = 0; i<massAnswer.Length;i++)
                            {
                                massAnswer[i] = 0;
                            }
                          return  MassiveAnsver(se2, se1);      
                        }
                    }
                }
                return massAnswer;
            }

            int[] ans = MassiveAnsver(s1,s2);
            string answer=""; 
            int counter = 0;
            if (ans[counter] == 0)
            {
                while (ans[counter] == 0)
                {
                    counter++;
                }
            }
                for (int i = counter;i < ans.Length;i++ )
            {
                answer += ans[i].ToString();
            }
            //Console.WriteLine(answer);
            return answer;
        }
  }
}
