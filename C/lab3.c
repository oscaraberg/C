#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <time.h>
#include <string.h>
#define ORDLANGD 40
#define MAX 100

struct varor
{
    int varunumer;
    char namn[ORDLANGD];
    int lagersaldo;
};
typedef struct varor Varor;
int meny(Varor v[],int *antal);
Varor skapaVara(int varunumer, char namn[], int lagersaldo);
void printVaror(Varor v);
void regVaror(Varor v[],int *antal);
void okaLagersaldo(Varor v[],int i,int oka);
void printAll(Varor v[],int antal);
void delVara(Varor v[],int *antal);
void sokVara(Varor v[],int antal);
void andraVara(Varor v[],int antal);
void del(Varor v[],int i,int *antal);
void sparFile(Varor v,FILE *fp);
void sparAllFile(Varor v[],int antal);
void scanFil(Varor v[],int *antal);
void scanVal(Varor v[],int *antal);
void sparVal(Varor v[],int antal);
void sorteraLagersaldo(Varor v[],int antal);
void sorteraVarunumer(Varor v[],int antal);
void sortera(Varor v[],int antal);
void sorteraNamn(Varor v[],int antal);
int unik(Varor v[],int varunumer,char namn[],int antal);




int main()
{
    Varor v[MAX]={0};
    int tal=0,antal=0;
    scanVal(v,&antal);
    while(tal!=7)
    {
        tal = meny(v,&antal);
    }
    if(antal>0)
    {
       sparVal(v,antal);
    }
    return 0;
}

int meny(Varor v[],int* antal)
{
    int tal=0;
    char tmp[ORDLANGD];
    printf("__________________________________\n");
    printf("1 Registrera nya varor \n");
    printf("2 Skriva ut alla varor \n");
    printf("3 Andra lagersaldot for varor \n");
    printf("4 Sortera varor \n");
    printf("5 Soka efter varor \n");
    printf("6 Avregistrera varor \n");
    printf("7 Avsluta programmet \n");
    printf("__________________________________\n");
    printf("skiriv in ditt val: ");
    scanf("%d",&tal);
    gets(tmp);

    if(tal==1)
    {
        regVaror(v,antal);
    }
    else if(tal==2)
    {
        printAll(v,*antal);
    }
    else if(tal==3)
    {
        andraVara(v,*antal);
    }
    else if(tal==4)
    {
        sortera(v,*antal);
    }
    else if(tal==5)
    {
        sokVara(v,*antal);
    }
    else if(tal==6)
    {
        delVara(v,antal);
    }
    return tal;
}

Varor skapaVara(int varunumer, char namn[], int lagersaldo)
{
    Varor v;
    v.varunumer = varunumer;
    strcpy(v.namn,namn);
    v.lagersaldo = lagersaldo;
    return v;
}

void printVaror(Varor v)
{
    printf("%-3d %-15s %-4d\n",v.varunumer,v.namn,v.lagersaldo);
}

void del(Varor v[],int i,int *antal)
{
    strcpy(v[i].namn,"zzzzz");
    sorteraNamn(v,*antal);
    *antal=*antal-1;
}

int unik(Varor v[],int varunumer,char namn[],int antal)
{
    int i=0;
    for(i=0;i<antal;i++)
    {
        if(v[i].varunumer==varunumer||strcmp(v[i].namn,namn)==0)
        {
            return 1;
        }
    }
    return 0;
}

void regVaror(Varor v[],int *antal)
{
    char tmp[ORDLANGD],in[ORDLANGD]="ja",namn[ORDLANGD];
    int varunumer=0,lagersaldo=0;
    while(strcmp(in,"ja")==0&&*antal<MAX)
    {
        printf("Ange varunumer: ");
        scanf("%d",&varunumer);
        gets(tmp);
        printf("Ange namn: ");
        gets(namn);
        printf("Ange lagersaldo: ");
        scanf("%d",&lagersaldo);
        gets(tmp);
        if(unik(v,varunumer,namn,*antal)==0)
        {
            v[*antal]=skapaVara(varunumer,namn,lagersaldo);
            (*antal)++;
        }
        else
        {
            printf("error varunumer eller namn ar inte unukt\n");
        }
        printf("Vill du fortsatta: (ja/nej)");
        gets(in);
    }

}

void okaLagersaldo(Varor v[],int i,int oka)
{
    v[i].lagersaldo = v[i].lagersaldo+oka;
    if(v[i].lagersaldo<0)
    {
        v[i].lagersaldo=0;
        printf("lagersaldot kan inte liga under 0\n");
    }
}

void printAll(Varor v[],int antal)
{
    int i;
    printf("__________________________________\n");
    for(i=0;i<antal;i++)
    {
        printVaror(v[i]);
    }
    printf("__________________________________\n");
}

void delVara(Varor v[],int *antal)
{
    char in[ORDLANGD],in2[ORDLANGD]="ja",tmp[ORDLANGD];
    int tal=0,i=0,oka=0;
    sokVara(v,*antal);
    while(strcmp(in2,"ja")==0)
    {
        printf("__________________________________\n");
        printf("1 valj via varonumer\n");
        printf("2 print all\n");
        printf("__________________________________\n");
        printf("skiriv in ditt val: ");
        scanf("%d",&tal);
        gets(tmp);
        if (tal==1)
        {
            printf("ange varunumer: ");
            scanf("%d",&tal);
            gets(tmp);
            for(i=0;i<*antal;i++)
            {
                if(tal==v[i].varunumer)
                {
                   del(v,i,antal);
                }
            }
        }
        else if(tal==2)
        {
            printAll(v,*antal);
        }
        printf("Vill du fortsatta: (ja/nej)");
        gets(in2);
    }
}

void sokVara(Varor v[],int antal)
{
    char in[ORDLANGD],in2[ORDLANGD]="ja",tmp[ORDLANGD],intmp[ORDLANGD];
    int tal=0,i=0;
    while(strcmp(in2,"ja")==0)
    {
        printf("__________________________________\n");
        printf("1 sok via varonumer\n");
        printf("2 sok via namn\n");
        printf("3 sok via lagersaldo\n");
        printf("4 print all\n");
        printf("__________________________________\n");
        printf("skiriv in ditt val: ");
        scanf("%d",&tal);
        gets(tmp);
        if (tal==1)
        {
            printf("ange varunumer: ");
            scanf("%d",&tal);
            gets(tmp);
            printf("__________________________________\n");
            for(i=0;i<antal;i++)
            {
                if(tal==v[i].varunumer)
                {
                   printVaror(v[i]);
                }
            }
        }
        else if(tal==2)
        {
            printf("ange namn: ");
            gets(in);
            printf("__________________________________\n");
            strcpy(intmp,in);
            tal=strlen(intmp);
            intmp[tal]=intmp[tal-1]+1;

            for(i=0;i<antal;i++)
            {
                if(strcmp(in,v[i].namn)==0||strcmp(in,v[i].namn)==-1&&strcmp(intmp,v[i].namn)==1)
                {
                   printVaror(v[i]);
                }
            }
        }
        else if (tal==3)
        {
            printf("ange lagersaldo: ");
            scanf("%d",&tal);
            gets(tmp);
            printf("__________________________________\n");
            for(i=0;i<antal;i++)
            {
                if(tal==v[i].lagersaldo)
                {
                   printVaror(v[i]);
                }
            }
        }
        else if(tal==4)
        {
            printAll(v,antal);
        }
        printf("Vill du fortsatta: (ja/nej)");
        gets(in2);
    }
}

void andraVara(Varor v[],int antal)
{
    char in[ORDLANGD],in2[ORDLANGD]="ja",tmp[ORDLANGD];
    int tal=0,i=0,oka=0;
    sokVara(v,antal);
    while(strcmp(in2,"ja")==0)
    {
        printf("__________________________________\n");
        printf("1 valj via varonumer\n");
        printf("2 print all\n");
        printf("__________________________________\n");
        printf("skiriv in ditt val: ");
        scanf("%d",&tal);
        gets(tmp);
        if (tal==1)
        {
            printf("ange varunumer: ");
            scanf("%d",&tal);
            printf("ange andrings varde: ");
            scanf("%d",&oka);
            gets(tmp);
            for(i=0;i<antal;i++)
            {
                if(tal==v[i].varunumer)
                {
                   okaLagersaldo(v,i,oka);
                }
            }
        }
        else if(tal==2)
        {
            printAll(v,antal);
        }
        printf("Vill du fortsatta: (ja/nej)");
        gets(in2);
    }
}

void sparFile(Varor v,FILE *fp)
{
    fprintf(fp,"%d %s %d\n",v.varunumer,v.namn,v.lagersaldo);

}

void sparAllFile(Varor v[],int antal)
{
    int i;
    char namn[ORDLANGD]={0};
    printf("skriv fill namn: ");
    gets(namn);
    FILE *fp;
    fp=fopen(namn,"w");
    if(fp!=NULL)
    {
        for(i=0;i<antal;i++)
        {
            sparFile(v[i],fp);
        }

        fclose(fp);
    }
    else
    {
        printf("Kunde inte spara filen\n");
    }

}

void scanFil(Varor v[],int *antal)
{
    int i;
    char namn2[ORDLANGD]={0};
    printf("skriv fill namn med fil typ: ");
    gets(namn2);
    FILE *fp;
    fp=fopen(namn2,"r");
    if(fp!=NULL)
    {
        char namn[ORDLANGD];
        int varunumer=0,lagersaldo=0;
        while(fscanf(fp,"%d %s %d",&varunumer,namn,&lagersaldo)==3)
        {
            v[*antal]=skapaVara(varunumer,namn,lagersaldo);
            (*antal)++;
        }
        fclose(fp);
    }
    else
    {
        printf("Kunde inte oppna filen\n");
    }

}

void scanVal(Varor v[],int *antal)
{
    int tal=0;
    char tmp[ORDLANGD]={0};
    printf("tryck 1 om du vill lada in en fil anars tryck 2: ");
    scanf("%d",&tal);
    gets(tmp);
    if(tal==1)
    {
        scanFil(v,antal);
    }
}
void sparVal(Varor v[],int antal)
{
    int tal=0;
    char tmp[ORDLANGD]={0};
    printf("tryck 1 om du vill spara din fil anars tryck 2: ");
    scanf("%d",&tal);
    gets(tmp);
    if(tal==1)
    {
        sparAllFile(v,antal);
    }
}

void sortera(Varor v[],int antal)
{
    int tal=0;
    char tmp[ORDLANGD];

    printf("__________________________________\n");
    printf("sortera efter:\n");
    printf("1 varunumer\n");
    printf("2 namn\n");
    printf("3 lagersaldo\n");
    printf("__________________________________\n");
    printf("skiriv in ditt val: ");
    scanf("%d",&tal);
    gets(tmp);

    if(tal==1)
    {
       sorteraVarunumer(v,antal);
    }
    else if(tal==2)
    {
        sorteraNamn(v,antal);
    }
    else if(tal==3)
    {
        sorteraLagersaldo(v,antal);
    }
}

void sorteraLagersaldo(Varor v[],int antal)
{
    int i,j;
    Varor tmp;

    for(j=0;j<antal-1;j++)
    {
        for(i=0;i<antal-1-j;i++)
        {
            if(v[i].lagersaldo>v[i+1].lagersaldo)
            {
                 tmp=v[i];
                v[i]=v[i+1];
                v[i+1]=tmp;
            }
        }
    }
}

void sorteraVarunumer(Varor v[],int antal)
{
    int i,j;
    Varor tmp;

    for(j=0;j<antal-1;j++)
    {
        for(i=0;i<antal-1-j;i++)
        {
            if(v[i].varunumer>v[i+1].varunumer)
            {
                tmp=v[i];
                v[i]=v[i+1];
                v[i+1]=tmp;
            }
        }
    }
}

void sorteraNamn(Varor v[],int antal)
{
    int i,j;
    Varor tmp;

    for(j=0;j<antal-1;j++)
    {
        for(i=0;i<antal-1-j;i++)
        {
            if(strcmp(v[i].namn,v[i+1].namn)==1)
            {
                tmp=v[i];
                v[i]=v[i+1];
                v[i+1]=tmp;
            }
        }
    }
}



