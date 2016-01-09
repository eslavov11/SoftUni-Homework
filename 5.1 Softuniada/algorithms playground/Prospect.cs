using System; 
using static System.Console;

class Prospect {
  static void Main() {
	ulong b = ulong.Parse(ReadLine());
	ulong r = ulong.Parse(ReadLine());
	ulong c = ulong.Parse(ReadLine());
	ulong t = ulong.Parse(ReadLine());
	ulong o = ulong.Parse(ReadLine());
    decimal n = decimal.Parse(ReadLine());
    decimal u = decimal.Parse(ReadLine());
    decimal s = decimal.Parse(ReadLine());
    decimal m = decimal.Parse(ReadLine());
    decimal total = b * 1500.04m + r*2102.10m + c*1465.46m + t*2053.33m + o*3010.98m
      + n * u + s;
    WriteLine("The amount is: {0:F2} lv.", total);
    if(m >= total) { 
      WriteLine("YES \\ Left: {0:F2} lv.", (m-total));
    } else WriteLine("NO \\ Need more: {0:F2} lv.", total - m);
  }
}