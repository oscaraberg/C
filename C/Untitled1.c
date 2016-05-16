#include <stdio.h>

int main()
{
    int tal, tal1, tal2, tal3;

    printf("skriv ett tal med tre sifror: ");
    scanf("%d",&tal);
    tal3 = tal/100;
    tal2 = (tal/10)%10;;
    tal1 =  tal%10;

    printf("%d%d%d",tal1,tal2,tal3);
    return 0;
}
