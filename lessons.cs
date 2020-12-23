using System;
using System.Collections.Generic;

namespace Level1Space
{
  public static class Level1
  {
      public static string TheRabbitsFoot(string s, bool encode)
        {
            int whiteSpaseCounter = 0;
            int lengthHight = 0;
            int n = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsWhiteSpace(s, i))
                {
                    lengthHight = i;
                    break;
                }
            }
            for (int i =0;i< s.Length ;i++)
            { if (char.IsWhiteSpace(s, i))
                    whiteSpaseCounter++;
            }
            char[] charsWithoutWS = new char[s.Length - whiteSpaseCounter];
            string resultus ="s";
            char[] charSummary = new char[charsWithoutWS.Length];
            int count = 0;
                int j = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    if (!char.IsWhiteSpace(s, i))
                    {
                        charsWithoutWS[j] = s[i];
                        j++;
                    }
                }
                string  withoutWhiteSpase = new String(charsWithoutWS);
                if (encode == true)
                {
                int len = (int)Math.Truncate(Math.Sqrt(withoutWhiteSpase.Length));
                int width = len + 1;
                int hight;
                if (withoutWhiteSpase.Length >len*width)
                {
                    hight = len + 1;
                }
                else hight = len;  
                char[,] matrix = new char[hight, width];  
                int k = 0;
                for (int l = 0; l < hight; l++)
                {
                    for (k = 0; k < width; k++)
                    {
                        if (n < charsWithoutWS.Length)
                        {
                            matrix[l, k] = charsWithoutWS[n];
                            n++;
                        }
                    }
                }
                char[] charSumm = new char[s.Length +width-1-whiteSpaseCounter];
                for (int l = 0; l < width; l++)
                {
                    for (k = 0; k < hight; k++)
                    {
                        if (matrix[k, l] != '\0')
                        {
                            if (count<charSumm.Length)
                            charSumm[count] = matrix[k, l];
                            count++;
                        }
                    }
                    if (l < width - 1)
                    {
                        count++;
                    }
                }
                resultus = new String(charSumm);
            }
            else
            {
                char[,] matrixDecoder = new char[lengthHight,whiteSpaseCounter+1];
                int num = 0;
                for (int i = 0; i < whiteSpaseCounter+1;i++)
                {   
                    for (int m = 0; m <lengthHight ; m ++)
                    {
                        if (s.Length>num && num > 0 && char.IsWhiteSpace(s, num - 1))
                            {
                                m = 0;
                            }
                            if (num < s.Length && char.IsWhiteSpace(s, num))
                            {
                                num++;
                            }
                            else
                            {
                            if (num < s.Length)
                                matrixDecoder[m, i] = s[num];
                                num++;        
                            } 
                    }
                } 
                for (int i = 0; i < lengthHight; i++)
                {
                    for (int m = 0; m < whiteSpaseCounter + 1; m++)
                    {
                        if (count < charSummary.Length)
                        {
                             charSummary[count]=matrixDecoder[i, m];
                            count++;
                        }
                    }    
                }
                resultus = new String(charSummary);
            }
            return resultus;
        }
  }
}
