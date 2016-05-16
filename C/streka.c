#include <stdio.h>

int main(void)
{
    int streka, hastighet, tid;
    hastighet = 25;

    printf("Hur lång tid? ");
    scanf("%d", &tid);

    streka = hastighet * tid;

    printf("med 25 m/s kommer du att fördas %d m \n", streka);
    printf("lycka till på färden\n");
    return 0;
}
