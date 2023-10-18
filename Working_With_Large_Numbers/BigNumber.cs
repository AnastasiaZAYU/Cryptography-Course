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

      //Реалізація побітових операцій для власного типу даних

      public List<int> INV(List<int> array)
      {
          string bin;
          for (int i = 0; i < array.Count; i++)
          {
              bin = Convert.ToString(array[i], 2);
              if (bin.Length < 16 & i != array.Count - 1)
                  bin = bin.PadLeft(16, '0');
              bin = bin.Replace("1", "2");
              bin = bin.Replace("0", "1");
              bin = bin.Replace("2", "0");
              array[i] = Convert.ToInt32(bin, 2);
          }
          return array;
      }

      public List<int> XOR(List<int> list1, List<int> list2)
      {
          List<int> a = new List<int>();
          List<int> b = new List<int>();
          List<int> c = new List<int>();
          if (list1.Count < list2.Count)
          {
              b = list1.ToList();
              a = list2.ToList();
          }
          else
          {
              a = list1.ToList();
              b = list2.ToList();
          }
          string bin_a, bin_b, bin_c;
          for (int i = 0; i < b.Count; i++)
          {
              bin_c = "";
              bin_a = Convert.ToString(a[i], 2);
              bin_b = Convert.ToString(b[i], 2);
              if (bin_a.Length < bin_b.Length)
                  bin_a = bin_a.PadLeft(bin_b.Length, '0');
              if (bin_a.Length > bin_b.Length)
                  bin_b = bin_b.PadLeft(bin_a.Length, '0');
              for (int j = 0; j < bin_a.Length; j++)
              {
                  if (bin_a[j] == bin_b[j])
                      bin_c += "0";
                  else bin_c += "1";
              }
              c.Add(Convert.ToInt32(bin_c, 2));
          }
          return c;
      }

      public List<int> OR(List<int> list1, List<int> list2)
      {
          List<int> a = new List<int>();
          List<int> b = new List<int>();
          List<int> c = new List<int>();
          if (list1.Count < list2.Count)
          {
              b = list1.ToList();
              a = list2.ToList();
          }
          else
          {
              a = list1.ToList();
              b = list2.ToList();
          }
          string bin_a, bin_b, bin_c;
          for (int i = 0; i < b.Count; i++)
          {
              bin_c = "";
              bin_a = Convert.ToString(a[i], 2);
              bin_b = Convert.ToString(b[i], 2);
              if (bin_a.Length < bin_b.Length)
                  bin_a = bin_a.PadLeft(bin_b.Length, '0');
              if (bin_a.Length > bin_b.Length)
                  bin_b = bin_b.PadLeft(bin_a.Length, '0');
              for (int j = 0; j < bin_a.Length; j++)
              {
                  if (bin_a[j] == '0' & bin_b[j] == '0')
                      bin_c += "0";
                  else bin_c += "1";
              }
              c.Add(Convert.ToInt32(bin_c, 2));
          }
          return c;
      }

      public List<int> AND(List<int> list1, List<int> list2)
      {
          List<int> a = new List<int>();
          List<int> b = new List<int>();
          List<int> c = new List<int>();
          if (list1.Count < list2.Count)
          {
              b = list1.ToList();
              a = list2.ToList();
          }
          else
          {
              a = list1.ToList();
              b = list2.ToList();
          }
          string bin_a, bin_b, bin_c;
          for (int i = 0; i < b.Count; i++)
          {
              bin_c = "";
              bin_a = Convert.ToString(a[i], 2);
              bin_b = Convert.ToString(b[i], 2);
              if (bin_a.Length < bin_b.Length)
                  bin_a = bin_a.PadLeft(bin_b.Length, '0');
              if (bin_a.Length > bin_b.Length)
                  bin_b = bin_b.PadLeft(bin_a.Length, '0');
              for (int j = 0; j < bin_a.Length; j++)
              {
                  if (bin_a[j] == '1' & bin_b[j] == '1')
                      bin_c += "1";
                  else bin_c += "0";
              }
              c.Add(Convert.ToInt32(bin_c, 2));
          }
          return c;
      }

      public List<int> shiftR(List<int> a, int count)
      {
          List<int> c = new List<int>();
          string s = "";
          for (int i = 0; i < a.Count; i++)
              s = Convert.ToString(a[i], 2) + s;
          s = s.Substring(s.Length - count) + s.Remove(s.Length - count);
          while (s.Length % 16 != 0)
              s = "0" + s;
          for (int i = 0; i < s.Length; i += 16)
          {
              c.Insert(0, Convert.ToInt32(s.Substring(0, 16), 2));
              s.Remove(0, 16);
          }
          return c;
      }

      public List<int> shiftL(List<int> a, int count)
      {
          List<int> c = new List<int>();
          string s = "";
          for (int i = 0; i < a.Count; i++)
              s = Convert.ToString(a[i], 2) + s;
          s = s.Remove(0, count) + s.Substring(0, count);
          while (s.Length % 16 != 0)
              s = "0" + s;
          for (int i = 0; i < s.Length; i += 16)
          {
              c.Insert(0, Convert.ToInt32(s.Substring(0, 16), 2));
              s.Remove(0, 16);
          }
          return c;
      }
    }
}
