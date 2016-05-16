#include <stdio.h>
#include <math.h>

int main()
{
    float max=0, min=0, in=1;

    printf("enter a number: ");
        scanf("%f",&in);
        max =in;
        min = in;
        printf("\nmax is %f and min is %f\n",max, min);

    while(in!=0)
    {
        printf("enter a number: ");
        scanf("%f",&in);
        if(in>max){max = in;}
        if(in<min){min = in;}
        printf("\nmax is %f and min is %f\n\n",max, min);
    }
    return 0;

}
