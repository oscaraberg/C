#include <stdio.h>
#include <math.h>




int main()
 {
    int tal= berakning(5,4,3);
    printf("%i",tal);
 }

void sktiv_tal(int a[])
 {
    int i;
    for(i=0;i<3;i++)
     {
         printf("%i\n",a[i]);
         a[i]+=5;
     }
 }
int berakning(int a, int b, int c)
{
    int svar;
    svar = a+b-c;
    return svar;
}
