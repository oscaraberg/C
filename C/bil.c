#include <stdio.h>
#include <string.h>
#define ORDLANGD 30
struct bil
{
char marke[ORDLANGD];
int arsmodell;
int mil;
}; //OBS semikolon glömmer man alltid! Ger svårtolkade fel.
typedef struct bil Bil;
int main()
{
Bil b1, b2={"volvo",2033,234444}; //b1 är variabel av datatypen struct bil
strcpy(b1.marke,"Volvo");
b1.arsmodell=1971;
b1.mil=21000;
printf("Bil: %s, Arsmodell: %d, Mil: %d",b1.marke,b1.arsmodell,b1.mil);
printf("\nBil: %s, Arsmodell: %d, Mil: %d",b2.marke,b2.arsmodell,b2.mil);
return 0;
}
