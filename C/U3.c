#include <stdio.h>
#include <math.h>

int main()
{
    int tal, tal2, tal3, i;
    tal = 1;
    tal2 = 10;
    tal3 = 2;

    for (i=0;i<10;i++)
    {
        printf("\n%d %d %d",tal, tal2,tal3);
        tal = tal++;
        tal2 = tal2--;
        tal3 = tal3+=2;
    }

    return 0;
}
