using System;
using System.Text;

namespace Sharpen
{
	public static class Runtime
	{
		public static string substring(string s, int from, int to)
		{
			return s.Substring(from, to - from);
		}
		
		public static string GetSimpleName(this Type t)
		{
			string name = t.Name;
			int index = name.IndexOf('`');
			return index == -1? name : name.Substring(0, index);
		}
		
		public static byte[] GetBytesForString(string str, string encoding)
		{
			return Encoding.GetEncoding(encoding).GetBytes(str);
		}
		
		public static string GetStringForBytes(byte[] chars, string encoding)
		{
			return GetEncoding(encoding).GetString(chars);
		}
		
		public static Encoding GetEncoding(string name)
		{
			Encoding e = Encoding.GetEncoding(name.Replace('_', '-'));
			if(e is UTF8Encoding)
				return new UTF8Encoding(false, true);
			return e;
		}
		
		public static float intBitsToFloat(int x)
		{
			byte[] bytes = BitConverter.GetBytes(x);
			return BitConverter.ToSingle(bytes, 0);
		}
		
		public static int floatToIntBits(float x)
		{
			byte[] bytes = BitConverter.GetBytes(x);
			return BitConverter.ToInt32(bytes, 0);
		}
		
		public static double longBitsToDouble(long x)
		{
			byte[] bytes = BitConverter.GetBytes(x);
			return BitConverter.ToDouble(bytes, 0);
		}
		
		public static long doubleToLongBits(double x)
		{
			byte[] bytes = BitConverter.GetBytes(x);
			return BitConverter.ToInt64(bytes, 0);
		}
	}
}
