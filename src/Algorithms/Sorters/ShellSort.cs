using System.Collections.Generic;


namespace AD
{
    public partial class ShellSort : Sorter
    {
        public override void Sort(List<int> list)
        {
            int i, j, position, temp;
            position = 3; //this determines howmany iterations it sorts

            //Keep looping until position = 0
            while (position > 0)
            {
                //Loop through list
                for (i = 0; i < list.Count; i++)
                {
                    j = i;
                    temp = list[i]; //This item gets compared

                    //j is bigger or equal to position
                    //compare temp with item before it
                    while((j >= position) && (list[j-position] > temp))
                    {
                        //replace item in list
                        list[j] = list[j - position];
                        j -= position;
                    }
                    //
                    list[j] = temp;
                }

                //Positioner gets halved (starts with 3)
                if (position / 2 != 0)
                    position /= 2;
                else if (position == 1)
                    position = 0;
                else
                    position = 1;
            }
        }

    }
}
