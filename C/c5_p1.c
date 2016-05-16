#include <stdio.h>
#include <math.h>

int main()
{
    int tal;
    printf("enter a number whid a maximun of tre didgets: ");
    scanf("%d",&tal);

    if(tal<10){
    printf("one didget");
    }
    else if((tal>=10)&&(tal<100)){
    printf("two didgets");
    }
    else{
    printf("tre didgets");
    }

    return 0;
}
