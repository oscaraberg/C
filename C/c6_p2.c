#include <stdio.h>
#include <math.h>

int main()
{
    int a=0, b=0, m=0, n=0, c=0, svar=0;

    printf("enter a fraction: ");
    scanf("%d/%d",&m,&n);
    printf("\nm=%d  n=%d",m,n);
    a = m;
    b = n;
    while(n!=0)
    {
        printf("\nm=%d  n=%d",m,n);
        c=m % n;
        m=n;
        n=c;

    }

    a=a/m;
    b=b/m;
    if(b!=0)
    {
        printf("\nsvar %d/%d",a,b);

    }
    else
    {
        printf("\nerror");
    }
}
