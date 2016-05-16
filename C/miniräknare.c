#include <stdio.h>
#include <math.h>

int main()
{
    float tal1 = 0, tal2 =0, svar =0;
    int val=0, pa = 1, varv =0;

        printf("1.Addition\n");
        printf("2.Subtraktion\n");
        printf("3.multipiktion\n");
        printf("4.Division\n");
        printf("ange val\n");
        scanf("%d",&val);
        if(val<1 || val>4)
        {
            printf("odefinderat val valj igen\n");
            printf("1.Addition\n");
            printf("2.Subtraktion\n");
            printf("3.multipiktion\n");
            printf("4.Division\n");
            printf("ange val\n");
            scanf("%d",&val);
        }
        printf("ange tal 1\n");
        scanf("%f",&tal1);
        printf("ange tal 2\n");
        scanf("%f",&tal2);

    while(pa==1)
    {
        if(varv==1)
        {
            printf("1.Addition\n");
            printf("2.Subtraktion\n");
            printf("3.multipiktion\n");
            printf("4.Division\n");
            printf("ange val\n");
            scanf("%d",&val);
            if(val<1 || val>4)
            {
                printf("odefinderat val valj igen\n");
                printf("1.Addition\n");
                printf("2.Subtraktion\n");
                printf("3.multipiktion\n");
                printf("4.Division\n");
                printf("ange val\n");
                scanf("%d",&val);
            }
            printf("ange tal 2\n");
            scanf("%f",&tal2);
        }

        if(val<5 && val>0)
        {

           if(val==1)
            {
                svar = tal1+tal2;
            }
            else if(val==2)
            {
                svar = tal1-tal2;
            }
            else if(val==3)
            {
                svar=tal1*tal2;
            }
           else if(val==4)
            {
                if(tal2 != 0)
                {
                   svar = tal1/tal2;
                }
                else
                {
                    printf("Error");
                    break;
                }
            }



                printf("svar = %f\n", svar);
                printf("pa 1 av 0\n");
                scanf("%d",&pa);
                tal1 = svar;
                varv = 1;

        }
    }
}
