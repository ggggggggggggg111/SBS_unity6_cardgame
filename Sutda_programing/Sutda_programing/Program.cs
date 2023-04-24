const int DECNUM = 20;

int[] dec = new int[DECNUM] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
// 1 ~10 = 11~20
int num = 1;
Random rand = new Random();
bool finish = false;
while (finish == false)
{
    int a = rand.Next(20);
    if (dec[a] != 0)
    {
        continue;
    }
    dec[a] = num;

    
    if (num == 20 )
    {
        finish = true;
    }
    ++num;
}
for (int i = 0; i < 20; i++)
{
    Console.Write(dec[i]);
    Console.Write(" ");
}
Console.WriteLine();

List<int> Player0 = new List<int>();
List<int> Computer1 = new List<int>();
Player0.Add(1);
Player0.Add(12);

Computer1.Add(dec[2]);
Computer1.Add(dec[3]);

Console.WriteLine(Player0[0]);
Console.WriteLine(Player0[1]);

Console.WriteLine(Computer1[0]);
Console.WriteLine(Computer1[1]);

if (Player0[0]%10 ==   Player0[1]%10  )  
{
    int b = ((Player0[0] + Player0[0]) % 10) - 1;
    Console.WriteLine($"{b}땡");
}

if (Computer1[0] % 10 == Computer1[1] % 10)
{
    int b = ((Computer1[0] + Computer1[0]) % 10) - 1;
    Console.WriteLine($"{b}땡");
}

if (Player0[0]%10 + Player0[1]%10 == 3 )
{
    Console.WriteLine("알리");
}

// 1 + 2 =3
// 1 + 12 = 13
// 11 + 12 = 






