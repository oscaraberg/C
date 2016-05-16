#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#define MAX 10
#define ORDL 30
struct rat_linje
{
    double k,m;
};
typedef struct rat_linje Rat_linje;
void print_linje(Rat_linje ls);
Rat_linje skapa_linje(double k, double m);
void lag_in_numer(Rat_linje ls[],int *antal);

int main()
{
    Rat_linje ls[MAX];
    int antal=0;
    int i=0;
    lag_in_numer(ls,&antal);
   for(i=0;i<antal;i++)
   {
       print_linje(ls[i]);
   }
    return 0;
}
void lag_in_numer(Rat_linje ls[],int *antal)
{
    double k,m;
    char s[ORDL]="ja";
    while(strcmp(s,"ja")==0&&*antal<MAX)
    {
        printf("enter K: ");
        scanf("%lf",&k);
        printf("enter M: ");
        scanf("%lf",&m);
        char tmp[5];
        gets(tmp);
        ls[*antal]=skapa_linje(k,m);
        (*antal)++;
        printf("%s\n",s);
        printf("vill deu forseta(ja/nej): ");
        gets(s);
    }
}
void print_linje(Rat_linje ls)
{
    printf("Linje K:%f M:%f\n",ls.k,ls.m);
}
Rat_linje skapa_linje(double k, double m)
{
    Rat_linje ls;
    ls.k=k;
    ls.m=m;
    return ls;
}
