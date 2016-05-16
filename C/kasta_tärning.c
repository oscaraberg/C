#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <time.h>
int i=0,j=0;

int main()
{
    int kast=0;
    printf("antal kast: ");
    scanf("%i",&kast);
    int kast_lista[kast];
    kast_tarning(kast,kast_lista);
    lista(kast_lista,kast);
}

void kast_tarning(int kast,int kast_lista[kast])
{
    srand(time(0));
    for(i=0;i<kast;i++)
    {
       kast_lista[i]=rand()%6+1;
    }
}

void lista(int kast_lista[],int kast)
{
    int tarning[6]={1,2,3,4,5,6};
    int frekvens[6]={0,0,0,0,0};
    for(i=0;i<6;i++)
    {
        for(j=0;j<kast;j++)
        {
            if(tarning[i]==kast_lista[j])
            {
                frekvens[i]+=1;

            }
              //printf("%i %i\n",i ,j);
        }
    }
    for (i=0;i<6;i++)
    {
        printf("antal %i: %i\n",tarning[i], frekvens[i]);
    }
}
