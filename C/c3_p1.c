#include <stdio.h>

int main()
{
    int d,m,y;
    printf("enter date mm/dd/yyyy: ");
    scanf("%d/%d/%d",&m,&d,&y);

    printf("\n\ndate:%4d%2.2d%2.2d",y,m,d);
    return 0;

}
