#include <stdio.h>
#include <math.h>

int main(void)
{
   float r=0, a=0;

   printf("skriv radie: ");
   scanf("%f",&r);

   a = M_PI*r*r;
   printf("arian är: %f", a);
   return 0;
}
