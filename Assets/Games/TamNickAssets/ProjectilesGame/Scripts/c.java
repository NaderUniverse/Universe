import java.util.*;

public class c
{
    public static void main(String[] args)
    {
        c c = new c();
    }
    public c()
    {
        Scanner scan = new Scanner(System.in);
        int cases = scan.nextInt();
        for (int loop = 0; loop < cases; loop++)
        {
            int volMax = scan.nextInt();
            int startVol = scan.nextInt();
            int upIncrease = scan.nextInt();
            int downIncrease = scan.nextInt();
            int n = scan.nextInt();

            int cur = startVol;

            for (int i = 0; i < n; i++)
            {
                String command = scan.next();
                if (command.equals("UP"))
                {
                    cur += upIncrease;
                    if ( cur > volMax)
                        cur = volMax;
                }
                else if (command.equals("DOWN"))
                {
                    cur -= downIncrease;
                    if ( cur < 0)
                        cur = 0;
                }
            }
            System.out.println(cur);
        }
    }

}