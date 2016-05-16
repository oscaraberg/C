#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <time.h>
#define maxs 13
int readLine(char s[], int n);

int main()
{
    int i=maxs-1,j=0;
    char s[maxs]="hej pa dej";
    j=readLine(s[maxs],i);
    for(i=0;i<j:i++)
    {
        printf("%c",s[i]);
    }

}
int readLine(char s[], int n)
{
int ch, i=0;
while((ch=getchar())!='\n')
if(i<n) s[i++]=ch;
s[i]='\0';
return i;
}
