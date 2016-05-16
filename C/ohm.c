#include <stdio.h>
int main(void)
{
    float r1, r2,r3;
    printf("resistans hos R1 (ohm) : ");
    scanf("%f",&r1);
    printf("resistans hos R2 (ohm) : ");
    scanf("%f",&r2);
    r3 = r1*r2/(r1+r2);
    printf("R3 beräknas till %6.3f ohm \n",r3);
    return 0;
}
