// See https://aka.ms/new-console-template for more information


using System.Data;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

string s1 = @"Hello \n" ;

string s2 = new string(new char[] { 'h', 'e', 'l', 'l', 'o' });


char firstChar = s1[1];
Console.WriteLine(firstChar);

s1 += " World";
Console.WriteLine(s1.ToLower());

foreach (var ch in s2)
{
    Console.WriteLine(ch);
}

Console.WriteLine(s1.Equals(s2,StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine($"First sting is {s1} and Second string is{s2}");

string s0 = "from Moldova";

string s3 = string.Join(" ", s1, s2, s0);
Console.WriteLine(s3);

string[] words = s3.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

foreach (string s in words)
{
    Console.WriteLine(s);
}

string text = s0.Substring(2);
Console.WriteLine(text);
text = s0.Substring(0, text.Length - 6);
Console.WriteLine(text);

string me = "i am ";

s0 = s0.Insert(0, me);
Console.WriteLine(s0);


string name = "Mihai";
int age = 22;

Console.WriteLine("My name is {0} I am {1}", name, age);
string output = string.Format("My name is {0} I am {1}", name, age);

double money = 24.8;
Console.WriteLine(money.ToString("C2"));

StringBuilder sb = new StringBuilder("be happy");


DateTime dateTime = new DateTime(2024, 03,18);
Console.WriteLine(dateTime);
Console.WriteLine(dateTime.DayOfWeek);
Console.WriteLine(dateTime.AddHours(3));



Console.WriteLine(DateTime.Now);
Console.WriteLine(DateTime.UtcNow);
Console.WriteLine(DateTime.Today);

DateTime now = DateTime.Now;
Console.WriteLine($"f: {now:f}");
Console.WriteLine($"G: {now:G}");
Console.WriteLine(now.ToString("hh:mm:ss"));


TimeSpan interval = new TimeSpan(5, 6, 22);
Console.WriteLine(interval.ToString());

var result1 = interval - TimeSpan.FromHours(3);
Console.WriteLine(result1);

TimeSpan interval1 = now - dateTime;
Console.WriteLine(interval1);


var moment = DateTimeOffset.Now;
Console.WriteLine(moment);

Console.WriteLine("Year: " + moment.Year);
Console.WriteLine("Month: " + moment.Month);
Console.WriteLine("Day: " + moment.Day);
Console.WriteLine("Hour: " + moment.Hour);
Console.WriteLine("Minute: " + moment.Minute);
Console.WriteLine("Second: " + moment.Second);
Console.WriteLine("Offset: " + moment.Offset);

TimeZoneInfo localTimeZone = TimeZoneInfo.Local;
Console.WriteLine("Local Time Zone: " + localTimeZone.DisplayName);


Console.WriteLine("\nAvailable Time Zones:");
foreach (TimeZoneInfo timeZone in TimeZoneInfo.GetSystemTimeZones())
{
    Console.WriteLine(timeZone.Id + " - " + timeZone.DisplayName);
}

DateTime data1 = DateTime.Now;
Console.WriteLine(data1);

CultureInfo usCulture = new CultureInfo("en-US");
CultureInfo gbCulture = new CultureInfo("en-GB");


Console.WriteLine("Culture Name: " + usCulture.Name);
Console.WriteLine("Display Name: " + usCulture.DisplayName);

Console.WriteLine(data1.ToString(usCulture));
Console.WriteLine(data1.ToString(gbCulture));