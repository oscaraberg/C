#include <stdio.h>
#include <math.h>
#include <time.h>

int main()
{
    int go=1;
    while(go==1)
    {
        rand(time(0));
        int tal=rand()%100+1,gisa=0,antal=0;
        int go2=1;
        printf("gisa pa ett tal mellan 1 och 100: ");
        scanf("%i",&gisa);

        while(go2==1)
        {
            antal=antal++;
            if(tal<gisa)
            {
                printf("gisa lagre: ");
                scanf("%i",&gisa);
            }
            else if(tal>gisa)
            {
                 printf("gisa hogre: ");
                 scanf("%i",&gisa);
            }
            else
            {
                 printf("gratis du har gisat rat. pa %i gisningar",antal);
                 go2=0;
                 printf(" vill gu kora igen 1=ja och 0=nej: ");
                 scanf("%i",&go);

            }
        }
    }
}

