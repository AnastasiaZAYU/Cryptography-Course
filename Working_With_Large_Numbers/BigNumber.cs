using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigNumbers
{
    public class BigNumber
    {
      int w = 16;
      int bt = Convert.ToInt32(Math.Pow(2, 16));

      public BigNumber()
      {}

      //Реалізація власного типу даних великого числа з методами setHex і getHex

      public string getHex(List<int> array)
      {
          string s = "";
          string temp;
          for (int i = 0; i < array.Count; i++)
          {
              temp = Convert.ToString(array[i], 16);
              while (temp.Length < 4) temp = "0" + temp;
              s = temp + s;
          }
          if (s[0] == '0') s = s.TrimStart('0');
          if (String.IsNullOrEmpty(s)) s = "0";
          return s;
      }

      public List<int> setHex(string s)
      {
          string temp;
          while (s.Length % 4 != 0) s = "0" + s;
          List<int> array = new List<int>();
          for (int i = 0; i < s.Length / 4; i++)
          {
              temp = "";
              for (int j = 0; j < 4; j++)
                  temp = temp + s[i * 4 + j];
              temp = Convert.ToString(Convert.ToInt32(temp, 16), 10);
              array.Add(Convert.ToInt32(temp));
          }
          array.Reverse();
          return array;
      }
    }
}
