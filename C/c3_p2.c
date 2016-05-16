#include <stdio.h>

int main()
{
    int antal;
    float pris;
    int d,m,y;

    printf("enter amount: ");
    scanf("%d",&antal);
    printf("enter pris: ");
    scanf("%f",&pris);
    printf("enter date yyyy/mm/dd: ");
    scanf("%d/%d/%d",&y,&m,&d);

    printf("\nitem|   unit|   purchase\n|   prise|   date\n%d|   $ %f|  %4d%2.2d%2.2d",antal, pris,y,m,d);
    return 0;
}
