#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <time.h>

int i,j;

int main()
{
    int a=5,b=1;
    int *p,*q;

    p=&a;
    q=p;

    //printf("%d",*p);

    *p=8;

    printf("%d",b);
}
