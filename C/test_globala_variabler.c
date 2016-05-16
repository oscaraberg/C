#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <time.h>
int tal=0;

int main()
{
    int tal2, tal3;
    scanf("%i %i",&tal2,&tal3);
    sumera(tal2,tal3);
    printf("\n%i",tal);
    mi(tal2,tal3);
    printf("\n%i",tal);

}

void sumera(int tal2, int tal3)
{
    tal=tal2+tal3;
}
void mi(int tal2, int tal3)
{
    tal=tal2-tal3;
}
