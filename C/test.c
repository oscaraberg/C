#include <stdio.h>

int main(void)
{
    float h, l, b ,v;
    printf("skriv in höjd: ");
    scanf("%f",&h);
    printf("skriv in lengd: ");
    scanf("%f",&l);
    printf("skriv in bred: ");
    scanf("%f",&b);
    v = h*l*b;
    printf("volymen är: %f",v);

    return 0;


}
