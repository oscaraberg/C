#include <stdio.h>

int main()
{
    float pris, total;
    int antal;

    printf ("hur många vill du köpa ");
    scanf("%d",&antal);
    pris = 9.90;
    total = pris*antal;
    if(antal<50&&antal>=10)
    {
        total=total*0.90;
        printf("totala priset är %f",total);
    }
    else if(antal>50)
    {
         total=total*0.50;
        printf("totala priset är %f",total);
    }
    else
    {
        printf("totala priset är %f",total);
    }
    return 0;
}
