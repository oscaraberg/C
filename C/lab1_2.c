#include <stdio.h>
#include <math.h>

int main()
{
    int tal1 =0, tal2 =0, tal3 =0, tal4 =0, temp1 =0, temp2 =0, temp3 =0, temp4 =0, svar =0, varv =1;

    while(varv==1)
    {
        printf("Ange ena 2-siffriga talet (blanka mellan): ");
        scanf("%d %d",&tal1,&tal2);

        printf("Ange anat 2-siffriga talet (blanka mellan): ");
        scanf("%d %d",&tal3,&tal4);

        printf("\n   %d%d",tal1,tal2);
        printf("\n   %d%d",tal3,tal4);
        printf("\n___________________");

    //beeräkning ett
        temp1 = tal4*tal2;
        temp2 = tal4*tal1;
        temp2 = temp2+(temp1/10);
        temp1 = temp1%10;
        temp1 = (temp2*10)+temp1;
        printf("\n  %d",temp1);
    //berekning två
        temp3 = tal3*tal2;
        temp4 = tal3*tal1;
        temp4 = temp4+(temp3/10);
        temp3 = temp3%10;
        temp3 = (temp4*10)+temp3;
        printf("\n %d",temp3);

        printf("\n___________________");
        svar = (temp3*10)+temp1;
        printf("\n%d",svar);
        printf("\nVill du sluta (0/1): ");
        scanf("%d",&varv);
    }
}
