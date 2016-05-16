#include <stdio.h>
#include <math.h>
#include <time.h>
#include <ctype.h>

int main()
{
    int i=0,kor=0;
    while(kor==0||kor==1)
    {
        int tal[100];
        char note[25]={'c','C','d','D','e','f','F','g','G','a','A','h','c','C','d','D','e','f','F','g','G','a','A','h','c'};
        char list_note[100];
         for(i=0;i<100;i++)
        {
            list_note[i]='0';
            tal[i]=0;
            //printf("%c",list_note[i]);
        }
        if(kor==0)
        {
            printf("skriv noter(c,C,d,D,e,f,F,g,G,a,A,h) slute ned 0\n");
        }
        else if(kor==1)
        {
            printf("avsluta truk 0 anars skriv noter(c,C,d,D,e,f,F,g,G,a,A,h) slute ned 0\n");
        }
        //kor=0;
        kor = note_in(list_note,kor);
        //printf("%d",kor);
        if(kor==2){break;}
        to_tal(note,list_note,tal);
        adering(tal);
        ny_note(tal,note);
        kor=1;
    }
}
int note_in(char list_note[],int kor)
{
    int i=0;
       //printf("test");
       list_note[0]='0';
     //for(i=0;i<100;i++)
    {
        scanf("%s",list_note);
        //printf("%c",list_note[0]);
        if(list_note[i]=='0'&&i>0)
        {
             list_note[i]=0;
             //printf("%c",list_note[0]);
            //break;
        }
        else if(list_note[0]=='0'&&i==0)
        {
            kor=2;
            //printf("%d",kor);
            //break;
        }
    }
   return(kor);
}
void to_tal(char note[],char list_note[],int tal[])
{
    int j=0, i=0;
     for(i=0;i<100;i++)
    {
        tal[i]=0;
    }
    for(i=0;i<100;i++)
    {
        if(list_note[i]==0)
        {
         break;
        }
        for(j=0;j<12;j++)
        {
            if(list_note[i]==note[j])
            {
                tal[i]=j+1;
            }
        }

    }
    for(i=0;i<100;i++)
    {
       if(tal[i]!=0)
       {
          printf(" %d",tal[i]);
       }
    }
    printf("\n");
}
void adering(int tal[])
{
    int konstant=0, i=0 ;
    printf("ange konstant melan 1 och 10: \n");
    scanf("%d",&konstant);
    for(i=0;i<100;i++)
    {
        if(tal[i]!=0)
        {
            tal[i]+=konstant;
        }
        else
        {
            break;
        }
    }
}
void ny_note(int tal[], char note[])
{
    int i=0;
    for(i=0;i<100;i++)
        {
            if(tal[i]==0)
            {
                break;
            }
            else
            {
                printf("%c",note[tal[i]-1]);

            }
        }
        printf("\n");
}
