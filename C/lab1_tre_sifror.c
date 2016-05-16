#include <stdio.h>
#include <math.h>

int main()
{
    int in1=0,in2=0,tal1=0, tal2=0, tal3=0, tal4=0, tal5=0, tal6=0, temp1 =0, temp2 =0, temp3 =0, temp4 =0,temp5=0,temp6=0, svar =0, varv =1;
    int l1[3],l2[3];

    while(varv==1)
    {
        printf("Ange ena 2-siffriga eller 3-siffrigr talet (blanka mellan): ");
        scanf("%d",&in1);

        printf("Ange anat 2-siffriga eller 3-siffrigr talet (blanka mellan): ");
        scanf("%d",&in2);
        if(in1<100 && in2<100)
        {
            tal1=in1/10;
            tal2=in1%10;
            tal3=in2/10;
            tal4=in2%10;
            printf("%d %d %d %d",tal1,tal2,tal3,tal4);
        //beeräkning ett
            temp1 = tal4*tal2;
            temp2 = tal4*tal1;
            temp2 = temp2+(temp1/10);
            temp1 = temp1%10;
            temp1 = (temp2*10)+temp1;

        //berekning två
            temp3 = tal3*tal2;
            temp4 = tal3*tal1;
            temp4 = temp4+(temp3/10);
            temp3 = temp3%10;
            temp3 = (temp4*10)+temp3;

            svar = (temp3*10)+temp1;
            printf("\nResultatet blir exakt %d%d*%d%d=%d",tal1,tal2,tal3,tal4,svar);
            printf("\nVill du sluta (0/1): ");
            scanf("%d",&varv);
        }
        if(in1>=100 && in2>=100)
        {
            tal1=in1/100;
            tal2=(in1/10)%10;
            tal3=in1%10;
            tal4=in2/100;
            tal5=(in2/10)%10;
            tal6=in2%10;
             printf("%d %d %d %d %d %d",tal1,tal2,tal3,tal4,tal5,tal6);

            temp1 = tal6*tal3;
            temp2 = tal6*tal2;
            temp3 = tal6*tal1;

            temp1 = temp1*100+ temp2*10+temp3;

            temp2 = tal5*tal3;



            svar = (temp3*10)+temp1;
            printf("\nResultatet blir exakt %d%d*%d%d=%d",tal1,tal2,tal3,tal4,svar);
            printf("\nVill du sluta (0/1): ");
            scanf("%d",&varv);
        }
    }
}
