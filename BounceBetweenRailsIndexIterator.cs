internal class BounceBetweenRailsIndexIterator
{
    private int nextIndex = -1;
    private bool isInreasingIndex = true;
    private readonly int numberOfRails;

    public BounceBetweenRailsIndexIterator(int numberOfRails) => this.numberOfRails = numberOfRails;

    public int next
    {
        get
        {
            if (isInreasingIndex)
            {
                nextIndex++;
            }
            else
            {
                nextIndex--;
            }

            if (nextIndex == numberOfRails)
            {
                isInreasingIndex = !isInreasingIndex;
                nextIndex = numberOfRails - 2;
            }
            if (nextIndex == -1)
            {
                isInreasingIndex = !isInreasingIndex;
                nextIndex = 1;
            }
            return nextIndex;
        }
    }
}