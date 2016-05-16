#include <stdio.h>
#include <math.h>
#include <time.h>
#include <stdlib.h>
int i,j;

int main()
{
    srand(time(0));
    int tal=0;
    int val=0;
    printf("antal tal: ");
    scanf("%d",&tal);
    int a[tal],b[tal];
    for(i=0;i<tal;i++)
    {
        //scanf("%d",&a[i]);
        a[i]=rand()%100;
    }
   printf("\nvaj stigande = 1 eller sjunkande = 0: ");
   scanf("%i",&val);
    printf("\n\n");
    if(val == 0)
    {
        tal_orning_sjunkande(a,tal);
    }
    if(val == 1)
    {
        tal_orning_stigande(a,tal);
    }


}
void tal_orning_sjunkande(int a[],int tal)
{
    int temp;

    for(j=0;j<tal-1;j++)
    {
        for(i=0;i<tal-1-j;i++)
        {
            if(a[i]<a[i+1])
            {
                temp=a[i];
                a[i]=a[i+1];
                a[i+1]=temp;
            }
        }
    }
    for(i=0;i<tal;i++)
    {
        printf("%d\n",a[i]);
    }
}
void tal_orning_stigande(int a[],int tal)
{
    int temp;

    for(j=0;j<tal-1;j++)
    {
        for(i=0;i<tal-1-j;i++)
        {
            if(a[i]>a[i+1])
            {
                temp=a[i];
                a[i]=a[i+1];
                a[i+1]=temp;
            }
        }
    }
    for(i=0;i<tal;i++)
    {
        printf("%d\n",a[i]);
    }
}
